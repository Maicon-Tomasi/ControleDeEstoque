using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuDeletarFornecedor : Menu
{
    private DAL<Fornecedor> FornecedorDal;

    public MenuDeletarFornecedor(ControleDeEstoqueContext context, DAL<Fornecedor> fornecedorDal) : base(context)
    {
        FornecedorDal = fornecedorDal;
    }

    public override void Executar()
    {
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


        Console.WriteLine("Digite o código do fornecedor que voce deseja deletar");
        string idFornecedor = Console.ReadLine();
        int idFornecedorConvertido = Convert.ToInt32(idFornecedor);

        var fornecedor = FornecedorDal.GetFor(e => e.Id.Equals(idFornecedorConvertido));

        if (fornecedor == null)
        {
            Console.WriteLine("Fornecedor não encontrado!");
            return;
        }

        try
        {
            FornecedorDal.Delete(fornecedor);
            Console.WriteLine("Fornecedor deletado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar o fornecedor: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
