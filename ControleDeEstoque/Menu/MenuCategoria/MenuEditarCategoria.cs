using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarCategoria : Menu
{
    private DAL<Categoria> CategoriaDal;

    public MenuEditarCategoria(ControleDeEstoqueContext context, DAL<Categoria> categoriaDal) : base(context)
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

        Console.WriteLine("Digite o id da categoria que voce deseja editar");
        string idCategoria = Console.ReadLine();
        if (string.IsNullOrEmpty(idCategoria))
        {
            Console.WriteLine("ID não pode ser nulo ou vazio.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            return; // Sai do método atual
        }

        if (!int.TryParse(idCategoria, out int idCategoriaConvertido))
        {
            Console.WriteLine("ID deve ser um número válido.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            return; // Sai do método atualq
        }

        var categoriaSelecionada = CategoriaDal.GetFor(e => e.Id.Equals(idCategoriaConvertido));

        if (categoriaSelecionada == null)
        {
            Console.WriteLine("Cidade não encontrado!");
            return;
        }

        Console.WriteLine($"Id da categoria: {categoriaSelecionada.Id}");
        Console.WriteLine($"Nome da categoria: {categoriaSelecionada.Descricao}");

        Console.WriteLine("Digite o novo nome da categoria: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            categoriaSelecionada.Descricao = novoNome;
        }


        try
        {
            CategoriaDal.Update(categoriaSelecionada);
            Console.WriteLine("Categoria atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o cidade: {ex.Message}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

