using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu.MenuOperacoes;

internal class MenuExibirEntradaDeProdutos : Menu
{
    private DAL<ItemDeEntrada> ItemDeEntradaDal;

    public MenuExibirEntradaDeProdutos(ControleDeEstoqueContext context, DAL<ItemDeEntrada> itemDeEntradaDal) : base(context)
    {
        ItemDeEntradaDal = itemDeEntradaDal;
    }

    public override void Executar()
    {

        var itensDeEntrada = (
            from ie in Context.ItemDeEntrada
            join p in Context.Produto on ie.IdProduto equals p.Id
            join f in Context.Fornecedor on ie.IdFornecedor equals f.Id
            orderby ie.DataEntrada
            select new
            {
                CodigoProduto = p.CodigoProduto,
                NomeProduto = p.NomeProduto,
                Lote = ie.Lote,
                Quatidade = ie.QuantidadeOriginal,
                DataDeEntrada = ie.DataEntrada,
                Fornecedor = f.NomeFornecedor

                // Nome da cidade
            }
        ).ToList();

        Console.WriteLine("Exibindo produtos que deram entrada");

        Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}",
            "Código Do Produto", "Nome", "Lote", "Quantidade", "Data De Entrada", "Fornecedor");
        Console.WriteLine(new string('-', 110));

        foreach (var item in itensDeEntrada)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}",
                item.CodigoProduto,
                item.NomeProduto,
                item.Lote,
                item.Quatidade,
                item.DataDeEntrada,
                item.Fornecedor
            );

        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
