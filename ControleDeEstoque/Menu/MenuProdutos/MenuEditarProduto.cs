using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarProduto : Menu
{
    private DAL<Produto> ProdutoDal;

    public MenuEditarProduto(ControleDeEstoqueContext context, DAL<Produto> produtoDal) : base(context)
    {
        ProdutoDal = produtoDal;
    }

    public override void Executar()
    {

        var categoriaDal = new DAL<Categoria>(Context);
        var fornecedorDal = new DAL<Fornecedor>(Context);
        var fornecedorProdutoDal = new DAL<FornecedorProdutos>(Context);

        var produtosListados = ProdutoDal.List();

        Console.WriteLine("Listando Todos os produtos cadastrados\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
            "Código", "Nome", "Descrição", "Unidade", "Vencimento");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var produtos = ProdutoDal.List();

        foreach (var produtoListado in produtosListados)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
                produtoListado.CodigoProduto,
                produtoListado.NomeProduto,
                produtoListado.DescricoDoProduto,
                produtoListado.UnidadeDeMedida,
                produtoListado.TempoDeVencimento);
        }


        Console.WriteLine("Digite o código do produto que voce deseja editar");
        string codigoProduto = Console.ReadLine();

        var produto = ProdutoDal.GetFor(e => e.CodigoProduto.Equals(codigoProduto));

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }

        Console.WriteLine($"Código do produto: {produto.CodigoProduto}");
        Console.WriteLine($"Nome do produto: {produto.NomeProduto}");
        Console.WriteLine($"Descrição: {produto.DescricoDoProduto}");
        Console.WriteLine($"Unidade De Medida: {produto.UnidadeDeMedida}");
        Console.WriteLine($"Tempo De Vencimento: {produto.TempoDeVencimento}");


        Console.WriteLine("Digite o novo código do produto: (deixe vazio para manter o mesmo)");
        string novoCodigo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCodigo))
        {
            produto.CodigoProduto = novoCodigo;
        }

        Console.WriteLine("Digite o novo nome do produto: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            produto.NomeProduto = novoNome;
        }

        Console.WriteLine("Digite uma nova descrição do produto: (deixe vazio para manter a mesma descrição)");
        string novaDescricao = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaDescricao))
        {
            produto.DescricoDoProduto = novaDescricao;
        }

        Console.WriteLine("Digite uma nova unidade de medida do produto: (deixe vazio para manter a mesma unidade de medida)");
        string novaUnidade = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaUnidade))
        {
            produto.UnidadeDeMedida = novaUnidade;
        }

        Console.WriteLine("Digite uma novo tempo de vencimento do produto: (deixe vazio para manter o mesmo tempo)");
        string novoTempo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoTempo))
        {
            produto.TempoDeVencimento = novoTempo;
        }

        var categorias = categoriaDal.List();

        foreach (var categoria in categorias)
        {
            Console.WriteLine("{0,-3} | {1,-20}",
                categoria.Id,
                categoria.Descricao
             );
        }

        Console.WriteLine("Digite o id da categoria do produto: (deixe vazio para manter o mesmo)");
        string categoriaProduto = Console.ReadLine();
        int idCategoria;

        try
        {
            if (!string.IsNullOrWhiteSpace(categoriaProduto))
            {
                int.TryParse(categoriaProduto, out int categoriaProdutoId);
                if (categoriaDal.GetFor(c => c.Id.Equals(categoriaProdutoId)) is null)
                {
                    Console.WriteLine("Categoria não encontrada");
                    return;
                }
                idCategoria = categoriaProdutoId;
                produto.IdCategoriaProduto = Convert.ToInt32(idCategoria);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Id inválido");
            return;
        }

        try
        {
            ProdutoDal.Update(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o produto: {ex.Message}");
        }

        Console.WriteLine("Deseja editar os fornecedores? (Digite 1 para adicionar e 2 para remover e 3 para ignorar");
        string respostaPerguntaFornecedor = Console.ReadLine();

        switch (respostaPerguntaFornecedor)
        {
            case "1":

                var fornecedores = fornecedorDal.List();

                foreach (var fornecedor in fornecedores)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} ",
                        fornecedor.Id,
                        fornecedor.NomeFornecedor,
                        fornecedor.Documento
                     );
                }

                Console.WriteLine("Digite o id do fornecedor para adiciona-lo: (digite 'sair' para cancelar");
                string idFornecedor = Console.ReadLine();

                while (idFornecedor.ToLower() != "sair")
                {
                    if (int.TryParse(idFornecedor, out int fornecedorId))
                    {
                        var fornecedorExiste = fornecedores.Any(f => f.Id == fornecedorId);
                        if (fornecedorExiste)
                        {
                            // Criar a associação
                            FornecedorProdutos fornecedorProdutoCriado = new FornecedorProdutos()
                            {
                                IdFornecedor = fornecedorId,
                                IdProduto = produto.Id // Agora o Id do produto está disponível
                            };

                            // Salvar no banco
                            fornecedorProdutoDal.Create(fornecedorProdutoCriado);
                            Console.WriteLine("Fornecedor associado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Tente novamente.");
                    }

                    Console.WriteLine("Digite o ID do fornecedor para associar ao produto (ou 'sair' para finalizar):");
                    idFornecedor = Console.ReadLine();
                }

                Console.WriteLine("Produto atualizado!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();

                break;
            case "2":
                var fornecedoreRemover = (
                    from frp in Context.FornecedorProdutos
                    join fr in Context.Fornecedor on frp.IdFornecedor equals fr.Id
                    select new
                    {
                        fr.Id,
                        fr.NomeFornecedor,
                        fr.Documento
                    }
                ).ToList();

                foreach (var fornecedor in fornecedoreRemover)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} ",
                        fornecedor.Id,
                        fornecedor.NomeFornecedor,
                        fornecedor.Documento
                     );
                }

                Console.WriteLine("Digite o id do fornecedor para remove-lo: (digite 'sair' para cancelar");
                string idFornecedorRemover = Console.ReadLine();

                while (idFornecedorRemover.ToLower() != "sair")
                {
                    if (int.TryParse(idFornecedorRemover, out int fornecedorIdRemover))
                    {
                        var fornecedorExiste = fornecedoreRemover.Any(f => f.Id == fornecedorIdRemover);
                        if (fornecedorExiste)
                        {

                            var fornecedorSelecionadoParaRemocao = fornecedorProdutoDal.GetFor(f => f.Id.Equals(fornecedorIdRemover));

                            // Salvar no banco
                            fornecedorProdutoDal.Delete(fornecedorSelecionadoParaRemocao!);
                            Console.WriteLine("Fornecedor removido deste produto com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Tente novamente.");
                    }

                    Console.WriteLine("Digite o ID do fornecedor para associar ao produto (ou 'sair' para finalizar):");
                    idFornecedor = Console.ReadLine();
                }

                Console.WriteLine("Produto atualizado!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                break;
            case "3":
                Console.WriteLine("Produto atualizado com sucesso!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                return;
                break;
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
