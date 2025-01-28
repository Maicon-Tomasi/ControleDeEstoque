using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListaProdutosCadastrados : Menu
{
    private DAL<Produto> ProdutoDal;

    public MenuListaProdutosCadastrados(ControleDeEstoqueContext context, DAL<Produto> produtoDal) : base(context)
    {
        ProdutoDal = produtoDal;
    }
    public override void Executar()
    {
        Console.WriteLine("Listando Todos os produtos cadastrados\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
            "Código", "Nome", "Descrição", "Unidade", "Vencimento");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var produtos = ProdutoDal.List();

        foreach (var produto in produtos)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
                produto.CodigoProduto,
                produto.NomeProduto,
                produto.DescricoDoProduto,
                produto.UnidadeDeMedida,
                produto.TempoDeVencimento);
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}

