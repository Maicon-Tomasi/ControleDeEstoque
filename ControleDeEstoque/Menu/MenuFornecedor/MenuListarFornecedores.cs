using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuListarFornecedores : Menu
{
    private DAL<Fornecedor> FornecedorDal;

    public MenuListarFornecedores(ControleDeEstoqueContext context, DAL<Fornecedor> fornecedorDal) : base(context)
    {
        FornecedorDal = fornecedorDal;
    }

    public override void Executar()
    {
        Console.WriteLine("Listando Todos os fornecedores cadastrados\n");

        // Cabeçalho da tabela
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


        foreach (var fornecedor in fornecedores)
        {
            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-7} | {4,-10} | {5, -15} | {6,-15} | {7, -15} | {8, -15}",
                fornecedor.Id,
                fornecedor.NomeFornecedor,
                fornecedor.Endereco,
                fornecedor.Numero,
                fornecedor.Bairro,
                fornecedor.Cep,
                fornecedor.Documento,
                fornecedor.Telefone,
                fornecedor.NomeCidade
                );
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

