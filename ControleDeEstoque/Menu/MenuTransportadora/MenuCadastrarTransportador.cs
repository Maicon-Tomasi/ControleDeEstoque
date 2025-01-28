using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuCadastrarTransportador : Menu
{
    private readonly ControleDeEstoqueContext Context;
    private DAL<Transportadora> TransportadoraDal;

    public MenuCadastrarTransportador(ControleDeEstoqueContext context, DAL<Transportadora> transportadoraDal) : base(context)
    {
        TransportadoraDal = transportadoraDal;
        Context = context;
    }

    public override void Executar()
    {
        var cidadeDal = new DAL<Cidade>(Context);

        Console.WriteLine("Cadastre o fornecedor que voce deseja!");
        Console.WriteLine("Digite o nome da transportadora:");
        string nomeTransportadora = Console.ReadLine();
        while (string.IsNullOrEmpty(nomeTransportadora))
        {
            Console.WriteLine("Digite o nome da transportadora:");
            nomeTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o endereço: Ex(Rua brasilândia)");
        string enderecoTransportadora = Console.ReadLine();
        while (string.IsNullOrEmpty(enderecoTransportadora))
        {
            Console.WriteLine("Digite o endereço: Ex(Rua brasilândia)");
            enderecoTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o número: Ex(1028)");
        string numeroTransportadora = Console.ReadLine();
        while (string.IsNullOrEmpty(numeroTransportadora))
        {
            Console.WriteLine("Digite o número: Ex(1028 ou 1028A)");
            numeroTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o bairro: Ex(Tiradentes)");
        string bairroTransportadora = Console.ReadLine();
        while (string.IsNullOrEmpty(bairroTransportadora))
        {
            Console.WriteLine("Digite o bairro: Ex(Tiradentes)");
            bairroTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o cep: (ex: apenas numeros)");
        string cepTransportadora = Console.ReadLine();
        while (cepTransportadora is null)
        {
            Console.WriteLine("Digite um cep válido: (ex: apenas numeros)");
            cepTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o cnpj: ");
        string cnpjTransportadora = Console.ReadLine();
        while (cnpjTransportadora is null)
        {
            Console.WriteLine("Digite o cnpj: ");
            cnpjTransportadora = Console.ReadLine();
        }
        Console.WriteLine("Digite o telefone de contato: ");
        string telefoneTransportadora = Console.ReadLine();
        while (telefoneTransportadora is null)
        {
            Console.WriteLine("Digite o telefone de contato: ");
            telefoneTransportadora = Console.ReadLine();
        }
        Console.WriteLine("{0,-3} | {1,-20} | {2,-20} |",
           "Id", "Cidade", "Estado");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var cidades = cidadeDal.List();

        foreach (var cidade in cidades)
        {
            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} ",
                cidade.Id,
                cidade.NomeCidade,
                cidade.Estado
             );
        }
        Console.WriteLine("Digite o id da cidade: ");
        string idCidade = Console.ReadLine();
        while (idCidade is null)
        {
            Console.WriteLine("Digite o id da cidade: ");
            idCidade = Console.ReadLine();
        }
        Transportadora transportadora = new Transportadora
        {
            NomeTransportadora = nomeTransportadora,
            Endereco = enderecoTransportadora,
            Numero = numeroTransportadora,
            Bairro = bairroTransportadora,
            Cep = Convert.ToInt32(cepTransportadora),
            Documento = cnpjTransportadora,
            Contato = telefoneTransportadora,
            IdCidade = Convert.ToInt32(idCidade)
        };
        TransportadoraDal.Create(transportadora);

        Console.WriteLine("Transportadora cadastrado com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}
