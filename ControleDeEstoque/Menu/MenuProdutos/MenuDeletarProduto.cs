using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuDeletarProduto : Menu
{
    private DAL<Produto> ProdutoDal;

    public MenuDeletarProduto(ControleDeEstoqueContext context, DAL<Produto> produtoDal) : base(context)
    {
        ProdutoDal = produtoDal;
    }

    public override void Executar()
    {
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


        Console.WriteLine("Digite o código do produto que voce deseja deletar");
        string codigoProduto = Console.ReadLine();

        var produto = ProdutoDal.GetFor(e => e.CodigoProduto.Equals(codigoProduto));

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }

        try
        {
            ProdutoDal.Delete(produto);
            Console.WriteLine("Produto deletado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar o produto: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

