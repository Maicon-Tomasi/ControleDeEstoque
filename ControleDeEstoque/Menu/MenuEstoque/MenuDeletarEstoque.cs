using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuDeletarEstoque : Menu
{
    private DAL<Estoque> EstoqueDal;

    public MenuDeletarEstoque(ControleDeEstoqueContext context, DAL<Estoque> estoqueDal) : base(context)
    {
        EstoqueDal = estoqueDal;
    }
    public override void Executar()
    {
        Console.WriteLine("Digite o ID do estoque que voce deseja deletar");
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

        try
        {
            EstoqueDal.Delete(estoque);
            Console.WriteLine("Estoque deletado com sucesso!");
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

