using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListarCategorias : Menu
{
    private DAL<Categoria> CategoriaDal;

    public MenuListarCategorias(ControleDeEstoqueContext context, DAL<Categoria> categoriaDal) : base(context)
    {
        CategoriaDal = categoriaDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Listando Todos as categorias cadastradas\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-3} | {1,-20} ",
            "Id", "Decrição");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var categorias = CategoriaDal.List();

        foreach (var categoria in categorias)
        {
            Console.WriteLine("{0,-3} | {1,-20}",
                categoria.Id,
                categoria.Descricao
             );
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

