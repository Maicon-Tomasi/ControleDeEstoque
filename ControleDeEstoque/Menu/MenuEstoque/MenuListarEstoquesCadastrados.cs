using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListarEstoquesCadastrados : Menu
{
    private DAL<Estoque> EstoqueDal;

    public MenuListarEstoquesCadastrados(ControleDeEstoqueContext context, DAL<Estoque> estoqueDal) : base(context)
    {
        EstoqueDal = estoqueDal;
    }
    public override void Executar()
    {
        Console.WriteLine("Todos os estoque cadastrados");
        foreach (var estoque in EstoqueDal.List())
        {
            Console.WriteLine($"{estoque.Nome}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}

