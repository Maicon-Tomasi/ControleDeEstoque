using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuCadastrarFornecedor : Menu
{
    private DAL<Fornecedor> FornecedorDal;

    public MenuCadastrarFornecedor(ControleDeEstoqueContext context, DAL<Fornecedor> fornecedorDal) : base(context)
    {
        FornecedorDal = fornecedorDal;
    }

    public override void Executar()
    {
        var cidadeDal = new DAL<Cidade>(Context);


        Console.WriteLine("Cadastre o fornecedor que voce deseja!");
        Console.WriteLine("Digite o nome do fornecedor:");
        string nomeFornecedor = Console.ReadLine();
        while (string.IsNullOrEmpty(nomeFornecedor))
        {
            Console.WriteLine("Digite o nome do fornecedor:");
            nomeFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o endereço: Ex(Rua brasilândia)");
        string enderecoFornecedor = Console.ReadLine();
        while (string.IsNullOrEmpty(enderecoFornecedor))
        {
            Console.WriteLine("Digite o endereço: Ex(Rua brasilândia)");
            enderecoFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o número: Ex(1028)");
        string numeroFornecedor = Console.ReadLine();
        while (string.IsNullOrEmpty(numeroFornecedor))
        {
            Console.WriteLine("Digite o número: Ex(1028 ou 1028A)");
            numeroFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o bairro: Ex(Tiradentes)");
        string bairroFornecedor = Console.ReadLine();
        while (string.IsNullOrEmpty(bairroFornecedor))
        {
            Console.WriteLine("Digite o bairro: Ex(Tiradentes)");
            bairroFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o cep: (ex: apenas numeros)");
        string cepFornecedor = Console.ReadLine();
        while (cepFornecedor is null)
        {
            Console.WriteLine("Digite um cep válido: (ex: apenas numeros)");
            cepFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o cnpj: ");
        string cnpjFornecedor = Console.ReadLine();
        while (cnpjFornecedor is null)
        {
            Console.WriteLine("Digite o cnpj: ");
            cnpjFornecedor = Console.ReadLine();
        }
        Console.WriteLine("Digite o telefone de contato: ");
        string telefoneFornecedor = Console.ReadLine();
        while (telefoneFornecedor is null)
        {
            Console.WriteLine("Digite o telefone de contato: ");
            telefoneFornecedor = Console.ReadLine();
        }
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
        Fornecedor fornecedor = new Fornecedor
        {
            NomeFornecedor = nomeFornecedor,
            Endereco = enderecoFornecedor,
            Numero = numeroFornecedor,
            Bairro = bairroFornecedor,
            Cep = Convert.ToInt32(cepFornecedor),
            Documento = cnpjFornecedor,
            Telefone = telefoneFornecedor,
            CidadeId = Convert.ToInt32(idCidade)
        };
        FornecedorDal.Create(fornecedor);

        Console.WriteLine("Fornecedor cadastrado com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
