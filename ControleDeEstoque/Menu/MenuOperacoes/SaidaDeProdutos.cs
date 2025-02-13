using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu.MenuOperacoes; 

internal class SaidaDeProdutos : Menu
{
    private DAL<ItemDeSaida> SaidaDeProdutoDal;

    public SaidaDeProdutos(ControleDeEstoqueContext context, DAL<ItemDeSaida> saideDeProdutoDal) : base(context)
    {
        SaidaDeProdutoDal = saideDeProdutoDal;
    }

    public override void Executar()
    {
        var produtoDal = new DAL<Produto>(Context);
        var estoqueDal = new DAL<Estoque>(Context);
        var itemDeEntradaDal = new DAL<ItemDeEntrada>(Context);
        var produtosListados = produtoDal.List();

        Console.WriteLine("Listando Todos os produtos cadastrados\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
            "Código", "Nome", "Descrição", "Unidade", "Vencimento");
        Console.WriteLine(new string('-', 110));

        foreach (var produtoListado in produtosListados)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
                produtoListado.CodigoProduto,
                produtoListado.NomeProduto,
                produtoListado.DescricoDoProduto,
                produtoListado.UnidadeDeMedida,
                produtoListado.TempoDeVencimento);
        }
        Console.WriteLine("Digite o código do produto que deseja realizar a saida: ");
        string codigoProduto = Console.ReadLine();

        var produto = produtoDal.GetFor(e => e.CodigoProduto.Equals(codigoProduto));
        int idProduto = produto!.Id;

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }

        var estouquesListados = estoqueDal.List();

        // Cabeçalho da tabela
        Console.WriteLine("{0,-15} | {1,-20} |",
            "Id", "Nome");
        Console.WriteLine(new string('-', 110));

        foreach (var estoque in estouquesListados)
        {
            Console.WriteLine("{0,-15} | {1,-20} | ",
                estoque.IdEstoque,
                estoque.Nome
            );

        }
        Console.WriteLine("Digite o id do estoque onde o produto vai ser retirado: ");
        int idEstoque = Convert.ToInt32(Console.ReadLine());

        var estoqueRecuperado = estoqueDal.GetFor(e => e.IdEstoque.Equals(idEstoque));

        if (estoqueRecuperado == null)
        {
            Console.WriteLine("Estoque não encontrado!");
            return;
        }

        Console.WriteLine("Digite a quantidade de produto: ");
        string quantidade = Console.ReadLine();
        float quantidadeConvertida = float.Parse(quantidade);

        while (quantidadeConvertida <= 0 && quantidade is null)
        {
            Console.WriteLine("Digite a quantidade de produto: (precisa ser maior que 0)");
            quantidade = Console.ReadLine();
            quantidadeConvertida = float.Parse(quantidade);
        }

        Console.WriteLine("Deseja utilizar FIFO ou LIFO? (1 para sim e 2 para não ");
        string opcaoEscolhida = Console.ReadLine();

        switch (opcaoEscolhida)
        {
            case "1":
                Console.WriteLine("Qual metódo deseja? 1 para FIFO e 2 para LIFO");
                string metodoEscolhido = Console.ReadLine();

                switch (metodoEscolhido)
                {
                    case "1":
                        realizarMetodoFifo(produto, idProduto, quantidadeConvertida, idEstoque);
                        break;
                    case "2":
                        realizarMetodoLifo(produto, idProduto, quantidadeConvertida, idEstoque);
                        break;
                }

                break;
            case "2":
                Console.WriteLine("Digite o lote que deseja usar:");
                string loteEscolhido = Console.ReadLine();

                float valor;
                Console.WriteLine("Digite o valor que foi vendido: ");
                while (!float.TryParse(Console.ReadLine(), out valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite um valor positivo:");
                }

                bool loteValido = false;


                while (!loteValido)
                {
                    var produtosArmazenados = (
                        from esp in Context.EstoqueProduto
                        join e in Context.Estoque on esp.IdEstoque equals e.IdEstoque
                        join ie in Context.ItemDeEntrada on esp.IdItemDeEntrada equals ie.Id
                        join p in Context.Produto on ie.IdProduto equals p.Id
                        where p.Id == produto.Id && ie.Lote == loteEscolhido
                        group ie by new { p.CodigoProduto, p.NomeProduto, ie.Lote } into g
                        select new
                        {
                            CodigoDoProduto = g.Key.CodigoProduto,
                            QuantidadeArmazenada = g.Sum(ie => ie.Quantidade),
                            Lote = g.Key.Lote
                        }
                    ).FirstOrDefault();

                    if (produtosArmazenados == null || produtosArmazenados.QuantidadeArmazenada <= 0)
                    {
                        Console.WriteLine("Este lote está vazio. Buscando outro lote disponível...");

                        // Tenta encontrar outro lote disponível
                        var outroLote = (
                            from esp in Context.EstoqueProduto
                            join e in Context.Estoque on esp.IdEstoque equals e.IdEstoque
                            join ie in Context.ItemDeEntrada on esp.IdItemDeEntrada equals ie.Id
                            join p in Context.Produto on ie.IdProduto equals p.Id
                            where p.Id == produto.Id && ie.Quantidade > 0
                            orderby ie.DataEntrada // FIFO: Ordena pelo mais antigo
                            select ie.Lote
                        ).FirstOrDefault();

                        if (string.IsNullOrEmpty(outroLote))
                        {
                            Console.WriteLine("Nenhum lote disponível com estoque suficiente!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Utilizando o lote {outroLote}.");
                            loteEscolhido = outroLote;
                        }
                    }
                    else
                    {
                        loteValido = true;
                    }
                }

                // Criar o item de saída com o lote válido
                 ItemDeSaida itemDeSaida = new ItemDeSaida()
                {
                    Lote = loteEscolhido!,
                    Quantidade = quantidadeConvertida,
                    Valor = valor,
                    IdProduto =  idProduto,
                    DataDeSaida = DateTime.Now
                };

                SaidaDeProdutoDal.Create(itemDeSaida);

                // Recuperar o item de estoque correspondente ao lote utilizado
                var estoqueProduto = Context.EstoqueProduto
                    .FirstOrDefault(ep => ep.IdEstoque == idEstoque &&
                                          Context.ItemDeEntrada
                                            .Any(ie => ie.Id == ep.IdItemDeEntrada && ie.Lote == loteEscolhido));

                if (estoqueProduto != null)
                {
                    // Buscar a entrada do item para reduzir a quantidade
                    var itemEntrada = Context.ItemDeEntrada.FirstOrDefault(ie => ie.Id == estoqueProduto.IdItemDeEntrada);

                    if (itemEntrada != null)
                    {
                        // Verificar se há quantidade suficiente
                        if (itemEntrada.Quantidade >= quantidadeConvertida)
                        {
                            itemEntrada.Quantidade -= quantidadeConvertida;
                            itemDeEntradaDal.Update(itemEntrada);
                            Console.WriteLine("Estoque atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro: A quantidade disponível no lote é insuficiente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erro: Item de entrada não encontrado no estoque.");
                    }
                }
                else
                {
                    Console.WriteLine("Erro: Estoque do produto não encontrado.");
                }

                Console.WriteLine($"Saída registrada com sucesso! Lote utilizado: {loteEscolhido}");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();

                break;

            default:
                Console.WriteLine("Opção inválida");
                return;
                break;
        }

        
    }

    private void realizarMetodoFifo(Produto produto, int idProduto, float quantidade, int idEstoque)
    {
        float valor;
        Console.WriteLine("Digite o valor que foi vendido: ");
        while (!float.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.WriteLine("Valor inválido. Digite um valor positivo:");
        }

        var loteFifo = (
            from esp in Context.EstoqueProduto
            join e in Context.Estoque on esp.IdEstoque equals e.IdEstoque
            join ie in Context.ItemDeEntrada on esp.IdItemDeEntrada equals ie.Id
            join p in Context.Produto on ie.IdProduto equals p.Id
            where p.Id == produto.Id && ie.Quantidade > 0
            orderby ie.DataEntrada // FIFO: Ordena pelo mais antigo
            select ie.Lote
        ).FirstOrDefault();

        if (string.IsNullOrEmpty(loteFifo))
        {
            Console.WriteLine("Nenhum lote disponível com estoque suficiente!");
            return;
        }
        else
        {
            Console.WriteLine($"Utilizando o lote {loteFifo}.");
        }

        ItemDeSaida itemDeSaida = new ItemDeSaida()
        {
            Lote = loteFifo,
            Quantidade = quantidade,
            Valor = valor,
            IdProduto = idProduto,
            DataDeSaida = DateTime.Now
        };

        SaidaDeProdutoDal.Create(itemDeSaida);

        var estoqueProduto = Context.EstoqueProduto
                    .FirstOrDefault(ep => ep.IdEstoque == idEstoque &&
                                          Context.ItemDeEntrada
                                            .Any(ie => ie.Id == ep.IdItemDeEntrada && ie.Lote == loteFifo));

        if (estoqueProduto != null)
        {
            // Buscar a entrada do item para reduzir a quantidade
            var itemEntrada = Context.ItemDeEntrada.FirstOrDefault(ie => ie.Id == estoqueProduto.IdItemDeEntrada);

            if (itemEntrada != null)
            {
                // Verificar se há quantidade suficiente
                if (itemEntrada.Quantidade >= quantidade)
                {
                    itemEntrada.Quantidade -= quantidade;
                    Context.SaveChanges();
                    Console.WriteLine("Estoque atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro: A quantidade disponível no lote é insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Erro: Item de entrada não encontrado no estoque.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Estoque do produto não encontrado.");
        }

        Console.WriteLine($"Saída registrada com sucesso! Lote utilizado: {loteFifo}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

    private void realizarMetodoLifo(Produto produto, int idProduto, float quantidade, int idEstoque)
    {
        float valor;
        Console.WriteLine("Digite o valor que foi vendido: ");
        while (!float.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.WriteLine("Valor inválido. Digite um valor positivo:");
        }

        var loteLifo = (
            from esp in Context.EstoqueProduto
            join e in Context.Estoque on esp.IdEstoque equals e.IdEstoque
            join ie in Context.ItemDeEntrada on esp.IdItemDeEntrada equals ie.Id
            join p in Context.Produto on ie.IdProduto equals p.Id
            where p.Id == produto.Id && ie.Quantidade > 0
            orderby ie.DataEntrada descending // FIFO: Ordena pelo mais antigo
            select ie.Lote 
        ).FirstOrDefault();

        if (string.IsNullOrEmpty(loteLifo))
        {
            Console.WriteLine("Nenhum lote disponível com estoque suficiente!");
            return;
        }
        else
        {
            Console.WriteLine($"Utilizando o lote {loteLifo}.");
        }

        ItemDeSaida itemDeSaida = new ItemDeSaida()
        {
            Lote = loteLifo,
            Quantidade = quantidade,
            Valor = valor,
            IdProduto = idProduto,
            DataDeSaida = DateTime.Now
        };

        SaidaDeProdutoDal.Create(itemDeSaida);

        var estoqueProduto = Context.EstoqueProduto
                    .FirstOrDefault(ep => ep.IdEstoque == idEstoque &&
                                          Context.ItemDeEntrada
                                            .Any(ie => ie.Id == ep.IdItemDeEntrada && ie.Lote == loteLifo));

        if (estoqueProduto != null)
        {
            // Buscar a entrada do item para reduzir a quantidade
            var itemEntrada = Context.ItemDeEntrada.FirstOrDefault(ie => ie.Id == estoqueProduto.IdItemDeEntrada);

            if (itemEntrada != null)
            {
                // Verificar se há quantidade suficiente
                if (itemEntrada.Quantidade >= quantidade)
                {
                    itemEntrada.Quantidade -= quantidade;
                    Context.SaveChanges();
                    Console.WriteLine("Estoque atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro: A quantidade disponível no lote é insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Erro: Item de entrada não encontrado no estoque.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Estoque do produto não encontrado.");
        }

        Console.WriteLine($"Saída registrada com sucesso! Lote utilizado: {loteLifo}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
