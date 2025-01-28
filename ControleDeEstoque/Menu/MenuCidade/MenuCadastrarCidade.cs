using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuCadastrarCidade : Menu
{
    private DAL<Cidade> CidadeDal;

    public MenuCadastrarCidade(ControleDeEstoqueContext context, DAL<Cidade> cidadeDal) : base(context)
    {
        CidadeDal = cidadeDal;
    }

    public override void Executar()
    {
        base.Executar();
        Console.WriteLine("Cadastre a cidade que voce deseja!");
        Console.WriteLine("Digite o nome da cidade:");
        string nomeCidade = Console.ReadLine();
        while (string.IsNullOrEmpty(nomeCidade))
        {
            Console.WriteLine("Digite o nome da cidade:");
            nomeCidade = Console.ReadLine();
        }

        Console.WriteLine("Digite o estado que a cidade pertence:");
        string estadoCidade = Console.ReadLine();
        while (string.IsNullOrEmpty(estadoCidade))
        {
            Console.WriteLine("Digite o nome ou sigla do estado:");
            estadoCidade = Console.ReadLine();
        }

        Cidade cidade = new Cidade
        {
            NomeCidade = nomeCidade,
            Estado = estadoCidade,
        };

        CidadeDal.Create(cidade);

        Console.WriteLine("Cidade cadastrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();

    }
}

