using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarEstoque : Menu
{
    private DAL<Estoque> EstoqueDal;

    public MenuEditarEstoque(ControleDeEstoqueContext context, DAL<Estoque> estoqueDal) : base(context)
    {
        EstoqueDal = estoqueDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Digite o ID do estoque que voce deseja editar");
        if (!int.TryParse(Console.ReadLine(), out int idEstoque))
        {
            Console.WriteLine("ID inválido! Digite um número.");
            return;
        }

        var estoque = EstoqueDal.GetFor(e => e.IdEstoque.Equals(idEstoque));

        if (estoque == null)
        {
            Console.WriteLine("Estoque não encontrado!");
            return;
        }

        Console.WriteLine($"Estoque atual: {estoque.Nome}");

        Console.WriteLine("Digite o novo nome do estoque:");
        string novoNome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(novoNome))
        {
            Console.WriteLine("O nome não pode estar vazio!");
            return;
        }

        estoque.Nome = novoNome;

        try
        {
            EstoqueDal.Update(estoque);
            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o estoque: {ex.Message}");
        }
         Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

