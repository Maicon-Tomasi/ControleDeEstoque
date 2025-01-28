using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListarTransportadoras : Menu
{
    private DAL<Transportadora> TransportadoraDal;

    public MenuListarTransportadoras(ControleDeEstoqueContext context, DAL<Transportadora> transportadoraDal) : base(context)
    {
        TransportadoraDal = transportadoraDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Listando Todos as transportadoras cadastradas\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5,-15} | {6,-15} | {7,-15} | {8, -15}",
        "Id", "Nome", "Endereco", "Numero", "Bairro", "Cep", "Documento", "Telefone", "Cidade");

        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var transportadoras = (
            from tr in Context.Transportadora
            join c in Context.Cidade on tr.IdCidade equals c.Id
            select new
            {
                tr.Id,
                tr.NomeTransportadora,
                tr.Endereco,
                tr.Numero,
                tr.Bairro,
                tr.Cep,
                tr.Documento,
                tr.Contato,
                NomeCidade = c.NomeCidade // Nome da cidade
            }
        ).ToList();

        foreach (var transportadora in transportadoras)
        {

            //string nomeCidade = cidades.TryGetValue(transportadora.IdCidade, out var cidade) ? cidade : "Cidade não encontrada";

            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5, -15} | {6,-15} | {7, -15} | {8, -20}",
                transportadora.Id,
                transportadora.NomeTransportadora,
                transportadora.Endereco,
                transportadora.Numero,
                transportadora.Bairro,
                transportadora.Cep,
                transportadora.Documento,
                transportadora.Contato,
                transportadora.NomeCidade
                );
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

