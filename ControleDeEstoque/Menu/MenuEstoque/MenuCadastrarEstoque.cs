using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuCadastrarEstoque : Menu
{

    private DAL<Estoque> EstoqueDal;

    public MenuCadastrarEstoque(ControleDeEstoqueContext context, DAL<Estoque> estoqueDal) : base(context)
    {
        EstoqueDal = estoqueDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Digite o nome que você deseja dar ao estoque");
        string nomeDoEstoque = Console.ReadLine();
        var estoque = new Estoque(nomeDoEstoque);
        EstoqueDal.Create(estoque);
        Console.WriteLine("Estoque cadastrado com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
