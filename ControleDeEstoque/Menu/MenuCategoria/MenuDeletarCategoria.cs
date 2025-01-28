using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuDeletarCategoria : Menu
{
    private DAL<Categoria> CategoriaDal;

    public MenuDeletarCategoria(ControleDeEstoqueContext context, DAL<Categoria> categoriaDal) : base(context)
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
            Console.WriteLine("{0,-3} | {1,-20} ",
                categoria.Id,
                categoria.Descricao
             );
        }

        Console.WriteLine("Digite o id da categoria que voce deseja deletar");
        string idCategoria = Console.ReadLine();
        int idCategoriaConvertido = Convert.ToInt32(idCategoria);

        var categoriaSelecionada = CategoriaDal.GetFor(e => e.Id.Equals(idCategoriaConvertido));

        if (categoriaSelecionada == null)
        {
            Console.WriteLine("Categoria não encontrada!");
            return;
        }

        try
        {
            CategoriaDal.Delete(categoriaSelecionada);
            Console.WriteLine("Categoria deletada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar o categoria: {ex.Message}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
