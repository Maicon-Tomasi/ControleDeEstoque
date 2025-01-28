using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarFornecedores : Menu
{
    private DAL<Fornecedor> FornecedorDal;

    public MenuEditarFornecedores(ControleDeEstoqueContext context, DAL<Fornecedor> fornecedorDal) : base(context)
    {
        FornecedorDal = fornecedorDal;
    }

    public override void Executar()
    {

        var cidadeDal = new DAL<Cidade>(Context);

        Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5, -15} | {6,-15} | {7, -15} | {8, -15}",
           "Id", "Nome", "Endereco", "Numero", "Bairro", "Cep", "Documento", "Telefone", "Cidade");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var fornecedores = (
            from fr in Context.Fornecedor
            join c in Context.Cidade on fr.CidadeId equals c.Id
            select new
            {
                fr.Id,
                fr.NomeFornecedor,
                fr.Endereco,
                fr.Numero,
                fr.Bairro,
                fr.Cep,
                fr.Documento,
                fr.Telefone,
                NomeCidade = c.NomeCidade // Nome da cidade
            }
        ).ToList();


        foreach (var fornecedorList in fornecedores)
        {
            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5, -15} | {6,-15} | {7, -15} | {8, -15}",
                fornecedorList.Id,
                fornecedorList.NomeFornecedor,
                fornecedorList.Endereco,
                fornecedorList.Numero,
                fornecedorList.Bairro,
                fornecedorList.Cep,
                fornecedorList.Documento,
                fornecedorList.Telefone,
                fornecedorList.NomeCidade
                );
        }


        Console.WriteLine("Digite o id do fornecedor que voce deseja editar");
        string idFornecedor = Console.ReadLine();
        int idFornecedorConvertido = Convert.ToInt32(idFornecedor);

        var fornecedor = FornecedorDal.GetFor(e => e.Id.Equals(idFornecedorConvertido));

        if (fornecedor == null)
        {
            Console.WriteLine("fornecedor não encontrado!");
            return;
        }

        Console.WriteLine($"Id do fornecedor: {fornecedor.Id}");
        Console.WriteLine($"Nome do fornecedor: {fornecedor.NomeFornecedor}");
        Console.WriteLine($"Endereço: {fornecedor.Endereco}");
        Console.WriteLine($"Número: {fornecedor.Numero}");
        Console.WriteLine($"Bairro: {fornecedor.Bairro}");
        Console.WriteLine($"Cep: {fornecedor.Cep}");
        Console.WriteLine($"CNPJ: {fornecedor.Documento}");
        Console.WriteLine($"Telefone: {fornecedor.Telefone}");


        Console.WriteLine("Digite o novo nome do fornecedor: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            fornecedor.NomeFornecedor = novoNome;
        }

        Console.WriteLine("Digite um novo endereço: (deixe vazio para manter o mesmo)");
        string novoEndereco = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoEndereco))
        {
            fornecedor.Endereco = novoEndereco;
        }

        Console.WriteLine("Digite um novo número: (deixe vazio para manter o mesmo)");
        string novaNumero = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaNumero))
        {
            fornecedor.Numero = novaNumero;
        }

        Console.WriteLine("Digite um novo bairro: (deixe vazio para manter a o mesmo tempo)");
        string novoBairro = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoBairro))
        {
            fornecedor.Bairro = novoBairro;
        }

        Console.WriteLine("Digite um novo cep: (deixe vazio para manter o mesmo )");
        string novoCep = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCep))
        {
            if(novoCep.Length > 8)
            {
                Console.WriteLine("Digite um novo cep: (deixe vazio para manter o mesmo )");
                novoCep = Console.ReadLine();
            }
            fornecedor.Cep = Convert.ToInt32(novoCep);
        }

        Console.WriteLine("Digite um novo CNPJ: (deixe vazio para manter o mesmo)");
        string novoCnpj = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCnpj))
        {
            fornecedor.Documento= novoCnpj;
        }

        Console.WriteLine("Digite um novo telefone: (deixe vazio para manter o mesmo)");
        string novoTelefone = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoTelefone))
        {
            fornecedor.Telefone = novoTelefone;
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

        Console.WriteLine("Digite um o id da cidade: (deixe vazio para manter o mesmo)");
        string idCidade = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idCidade))
        {
            fornecedor.CidadeId = Convert.ToInt32(idCidade);
        }


        try
        {
            FornecedorDal.Update(fornecedor);
            Console.WriteLine("Fornecedor atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o fornecedor: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

