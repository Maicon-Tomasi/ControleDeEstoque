using Castle.Components.DictionaryAdapter.Xml;
using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu.MenuOperacoes;

internal class VisualizarProdutosArmazenados : Menu
{
    private DAL<EstoqueProduto> EstoqueProdutoDal;

    public VisualizarProdutosArmazenados(ControleDeEstoqueContext context, DAL<EstoqueProduto> estoqueDeProdutoDal) : base(context)
    {
        EstoqueProdutoDal = estoqueDeProdutoDal;
    }

    public override void Executar()
    {
        var estoqueDal = new DAL<Estoque>(Context);
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

        Console.WriteLine("Digite o estoque que deseja visualizar");
        string entrada = Console.ReadLine();
        int idEstoque;

        if(!int.TryParse(entrada, out idEstoque))
        {
            Console.WriteLine("id inváido");
            return;
        }

        var estoqueEncontrado = estoqueDal.GetFor(e => e.IdEstoque.Equals(idEstoque));
        idEstoque = estoqueEncontrado!.IdEstoque;
        if(estoqueEncontrado == null)
        {
            Console.WriteLine("Estoque Não encontrado");
            return ;
        }

        var produtosArmazenado = (
            from ep in Context.EstoqueProduto
            join e in Context.Estoque on ep.IdEstoque equals e.IdEstoque
            join ie in Context.ItemDeEntrada on ep.IdItemDeEntrada equals ie.Id
            join p in Context.Produto on ie.IdProduto equals p.Id
            where e.IdEstoque == idEstoque
            group ie by new { p.CodigoProduto, p.NomeProduto, ie.Lote } into g
            select new
            {
                CodigoProduto = g.Key.CodigoProduto,
                NomeProduto = g.Key.NomeProduto,
                Lote = g.Key.Lote,
                Quatidade = g.Sum(ie => ie.Quantidade),
                
                // Nome da cidade
            }
        ).ToList();

        Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} |",
            "Código Do Produto", "Nome", "Lote", "Quantidade Armazenada");
        Console.WriteLine(new string('-', 110));

        foreach (var produtos in produtosArmazenado)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} |",
                produtos.CodigoProduto,
                produtos.NomeProduto,
                produtos.Lote,
                produtos.Quatidade
            );

        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
