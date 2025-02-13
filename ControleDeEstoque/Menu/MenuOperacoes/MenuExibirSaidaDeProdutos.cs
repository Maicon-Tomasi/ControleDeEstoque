using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu.MenuOperacoes;

internal class MenuExibirSaidaDeProdutos : Menu
{
    private DAL<ItemDeSaida> ItemDeSaidaDal;

    public MenuExibirSaidaDeProdutos(ControleDeEstoqueContext context, DAL<ItemDeSaida> itemDeSaidaDal) : base(context)
    {
        ItemDeSaidaDal = itemDeSaidaDal;
    }

    public override void Executar()
    {

        var itensDeSaida = (
            from ie in Context.ItemDeSaida
            join p in Context.Produto on ie.IdProduto equals p.Id
            orderby ie.DataDeSaida
            select new
            {
                CodigoProduto = p.CodigoProduto,
                NomeProduto = p.NomeProduto,
                Lote = ie.Lote,
                Quatidade = ie.Quantidade,
                DataDeSaida = ie.DataDeSaida
                // Nome da cidade
            }
        ).ToList();

        Console.WriteLine("Exibindo produtos que deram saida");

        Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} | {4,-20} ",
            "Código Do Produto", "Nome", "Lote", "Quantidade", "Data De Saida");
        Console.WriteLine(new string('-', 110));

        foreach (var item in itensDeSaida)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} | {4,-20} ",
                item.CodigoProduto,
                item.NomeProduto,
                item.Lote,
                item.Quatidade,
                item.DataDeSaida
            );

        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
