using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarTransportadoras : Menu
{
    private DAL<Transportadora> TransportadoraDal;

    public MenuEditarTransportadoras(ControleDeEstoqueContext context, DAL<Transportadora> transportadoraDal) : base(context)
    {
        TransportadoraDal = transportadoraDal;
    }

    public override void Executar()
    {
        var transportadorasListados = TransportadoraDal.List();

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

        foreach (var transportadoraList in transportadoras)
        {

            //string nomeCidade = cidades.TryGetValue(transportadora.IdCidade, out var cidade) ? cidade : "Cidade não encontrada";

            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5, -15} | {6,-15} | {7, -15} | {8, -20}",
                transportadoraList.Id,
                transportadoraList.NomeTransportadora,
                transportadoraList.Endereco,
                transportadoraList.Numero,
                transportadoraList.Bairro,
                transportadoraList.Cep,
                transportadoraList.Documento,
                transportadoraList.Contato,
                transportadoraList.NomeCidade
                );
        }


        Console.WriteLine("Digite o id da transportadora que voce deseja editar");
        string idTransportadora = Console.ReadLine();
        if (string.IsNullOrEmpty(idTransportadora))
        {
            Console.WriteLine("ID não pode ser nulo ou vazio.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();        
            return; // Sai do método atual
        }

        if (!int.TryParse(idTransportadora, out int idTransportadoraConvertido))
        {
            Console.WriteLine("ID deve ser um número válido.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            return; // Sai do método atualq
        }


        var transportadora = TransportadoraDal.GetFor(e => e.Id.Equals(idTransportadoraConvertido));

        if (transportadora == null)
        {
            Console.WriteLine("transportadora não encontrado!");
            return;
        }

        Console.WriteLine($"Id do transportadora: {transportadora.Id}");
        Console.WriteLine($"Nome do transportadora: {transportadora.NomeTransportadora}");
        Console.WriteLine($"Endereço: {transportadora.Endereco}");
        Console.WriteLine($"Número: {transportadora.Numero}");
        Console.WriteLine($"Bairro: {transportadora.Bairro}");
        Console.WriteLine($"Cep: {transportadora.Cep}");
        Console.WriteLine($"CNPJ: {transportadora.Documento}");
        Console.WriteLine($"Telefone: {transportadora.Contato}");


        Console.WriteLine("Digite o novo nome do transportadora: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            transportadora.NomeTransportadora = novoNome;
        }

        Console.WriteLine("Digite um novo endereço: (deixe vazio para manter o mesmo)");
        string novoEndereco = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoEndereco))
        {
            transportadora.Endereco = novoEndereco;
        }

        Console.WriteLine("Digite um novo número: (deixe vazio para manter o mesmo)");
        string novaNumero = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaNumero))
        {
            transportadora.Numero = novaNumero;
        }

        Console.WriteLine("Digite um novo bairro: (deixe vazio para manter a o mesmo tempo)");
        string novoBairro = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoBairro))
        {
            transportadora.Bairro = novoBairro;
        }

        Console.WriteLine("Digite um novo cep: (deixe vazio para manter o mesmo )");
        string novoCep = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCep))
        {
            if (novoCep.Length > 8)
            {
                Console.WriteLine("Digite um novo cep: (deixe vazio para manter o mesmo )");
                novoCep = Console.ReadLine();
            }
            transportadora.Cep = Convert.ToInt32(novoCep);
        }

        Console.WriteLine("Digite um novo CNPJ: (deixe vazio para manter o mesmo)");
        string novoCnpj = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCnpj))
        {
            transportadora.Documento = novoCnpj;
        }

        Console.WriteLine("Digite um novo telefone: (deixe vazio para manter o mesmo)");
        string novoTelefone = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoTelefone))
        {
            transportadora.Contato = novoTelefone;
        }

        Console.WriteLine("Digite um o id da cidade: (deixe vazio para manter o mesmo)");
        string idCidade = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idCidade))
        {
            transportadora.IdCidade = Convert.ToInt32(idCidade);
        }


        try
        {
            TransportadoraDal.Update(transportadora);
            Console.WriteLine("Transportadora atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o transportadora: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
