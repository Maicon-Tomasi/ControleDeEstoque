using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu.MenuOperacoes;

internal class EntradaDeProduto : Menu
{
    private DAL<ItemDeEntrada> EntradaDeProdutoDal;

    public EntradaDeProduto(ControleDeEstoqueContext context, DAL<ItemDeEntrada> entradaDeProdutoDal) : base(context)
    {
        EntradaDeProdutoDal = entradaDeProdutoDal;
    }

    public override void Executar()
    {
        var produtoDal = new DAL<Produto>(Context);
        var estoqueDal = new DAL<Estoque>(Context);
        var estoqueProdutoDal = new DAL<EstoqueProduto>(Context);
        var fornecedorDal = new DAL<Fornecedor>(Context);

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
        Console.WriteLine("Digite o código do produto que deseja realizar a entrada: ");
        string codigoProduto = Console.ReadLine();

        var produto = produtoDal.GetFor(e => e.CodigoProduto.Equals(codigoProduto));

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
        Console.WriteLine("Digite o id do estoque onde o produto vai ser armazenado: ");
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

        var fornecedores = (
            from frp in Context.FornecedorProdutos
            join p in Context.Produto on frp.IdProduto equals p.Id
            join f in Context.Fornecedor on frp.IdFornecedor equals f.Id
            where p.CodigoProduto == codigoProduto
            select new
            {
                Id = f.Id,
                NomeFornecedor = f.NomeFornecedor
            }
        ).ToList();

        Console.WriteLine("Digite o lote do produto: ");
        string lote = Console.ReadLine();
        while (lote == null)
        {
            Console.WriteLine("o Lote não pode ser nulo");
            Console.WriteLine("Digite o lote do produto: ");
            lote = Console.ReadLine();
        }

        Console.WriteLine("Digite o valor: ");
        float valor = float.Parse(Console.ReadLine());

        Console.WriteLine("{0,-15} | {1,-20} |",
            "Id", "Nome");
        Console.WriteLine(new string('-', 110));

        foreach (var fornecedor in fornecedores)
        {
            Console.WriteLine("{0,-15} | {1,-20} | ",
                fornecedor.Id,
                fornecedor.NomeFornecedor
            );

        }

        Console.WriteLine("Digite o Id de quem forneceu o produto:");
        int idFornecedor = Convert.ToInt32(Console.ReadLine());

        var fornecedorRecuperado = fornecedorDal.GetFor(f => f.Id.Equals(idFornecedor));

        while(idFornecedor == null)
        {
            Console.WriteLine("Id inválido");
            Console.WriteLine("Digite o Id de quem forneceu o produoto:");
            idFornecedor = Convert.ToInt32(Console.ReadLine());

            fornecedorRecuperado = fornecedorDal.GetFor(f => f.Id.Equals(idFornecedor));
        }

        ItemDeEntrada itemDeEntrada = new ItemDeEntrada()
        {
            Lote = lote,
            Quantidade = quantidadeConvertida,
            QuantidadeOriginal = quantidadeConvertida,
            Valor = valor,
            IdProduto = produto.Id,
            IdFornecedor = fornecedorRecuperado!.Id,
            DataEntrada = DateTime.Now,
        };

        EntradaDeProdutoDal.Create(itemDeEntrada);

        EstoqueProduto estoqueProduto = new EstoqueProduto()
        {
            IdEstoque = estoqueRecuperado.IdEstoque,
            IdItemDeEntrada = itemDeEntrada.Id
        };

        estoqueProdutoDal.Create(estoqueProduto);

        Console.WriteLine("Armazenado com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
