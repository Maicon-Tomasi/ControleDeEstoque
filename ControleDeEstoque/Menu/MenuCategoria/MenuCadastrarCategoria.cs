using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuCadastrarCategoria : Menu
{
    private DAL<Categoria> CategoriaDal;

    public MenuCadastrarCategoria(ControleDeEstoqueContext context, DAL<Categoria> categoriaDal) : base(context)
    {
        CategoriaDal = categoriaDal;
    }

    public override void Executar()
    {
        base.Executar();
        Console.WriteLine("Cadastre a categoria que voce deseja!");
        Console.WriteLine("Digite a categoria:");
        string nomeCategoria = Console.ReadLine();
        while (string.IsNullOrEmpty(nomeCategoria))
        {
            Console.WriteLine("Digite o nome da cidade:");
            nomeCategoria = Console.ReadLine();
        }

        Categoria categoria = new Categoria
        (
            nomeCategoria
        );

        CategoriaDal.Create(categoria);

        Console.WriteLine("Categoria cadastrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();

    }

}
