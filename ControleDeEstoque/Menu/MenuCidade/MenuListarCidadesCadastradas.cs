using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListarCidadesCadastradas : Menu
{
    private DAL<Cidade> CidadeDal;

    public MenuListarCidadesCadastradas(ControleDeEstoqueContext context, DAL<Cidade> cidadeDal) : base(context)
    {
        CidadeDal = cidadeDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Listando Todos as cidades cadastradas\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-3} | {1,-20} | {2,-20} |",
            "Id", "Cidade", "Estado");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var cidades = CidadeDal.List();

        foreach (var cidade in cidades)
        {
            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} ",
                cidade.Id,
                cidade.NomeCidade,
                cidade.Estado
             );
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

