using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;

internal class MenuCadastrarProduto : Menu
{
    private DAL<Produto> ProdutoDal;

    public MenuCadastrarProduto(ControleDeEstoqueContext context, DAL<Produto> produtoDal) : base(context)
    {
        ProdutoDal = produtoDal;
    }
    public override void Executar()
    {

        var categoriaDal = new DAL<Categoria>(Context);
        var fornecedorDal = new DAL<Fornecedor>(Context);
        var fornecedorProdutoDal = new DAL<FornecedorProdutos>(Context);

        Console.WriteLine("Cadastre o produto que voce deseja!");
        Console.WriteLine("Digite o código do produto: Ex(1234Madeira)");
        string codigoProduto = Console.ReadLine();
        Console.WriteLine("Digite o nome do produto: Ex(Madeira)");
        string nomeProduto = Console.ReadLine();
        Console.WriteLine("Digite a descrição do produto: Ex(Madeira)");
        string descricaoProduto = Console.ReadLine();
        Console.WriteLine("Digite a unidade de medida do produto: Ex(Madeira)");
        string unidadeMedidaProduto = Console.ReadLine();
        Console.WriteLine("Digite o tempo de vencimento produto: Ex(6 meses ou 6 dias)");
        string tempoDeVencimentoProduto = Console.ReadLine();

        var categorias = categoriaDal.List();

        foreach (var categoria in categorias)
        {
            Console.WriteLine("{0,-3} | {1,-20}",
                categoria.Id,
                categoria.Descricao
             );
        }

        Console.WriteLine("Digite o id da categoria do produto: ");
        string categoriaProduto = Console.ReadLine();
        int idCategoria;

        while (categoriaProduto is null)
        {
            Console.WriteLine("Digite o id da categoria: ");
            categoriaProduto = Console.ReadLine();
        }

        try
        {
            int.TryParse(categoriaProduto, out int categoriaProdutoId);
            if (categoriaDal.GetFor(c => c.Id.Equals(categoriaProdutoId)) is null)
            {
                Console.WriteLine("Categoria não encontrada");
                return;
            }
            idCategoria = categoriaProdutoId;
        }
        catch (Exception ex) {
            Console.WriteLine("Id inválido");
            return;
        }




        Produto produto = new Produto()
        {
            CodigoProduto = codigoProduto,
            NomeProduto = nomeProduto,
            DescricoDoProduto = descricaoProduto,
            UnidadeDeMedida = unidadeMedidaProduto,
            TempoDeVencimento = tempoDeVencimentoProduto,
            IdCategoriaProduto = Convert.ToInt32(idCategoria)
        };

        ProdutoDal.Create(produto);

        Console.WriteLine("Este produto possui fornecedores? (Digite 1 para sim e 2 para não");
        string respostaPerguntaFornecedor = Console.ReadLine();

        switch (respostaPerguntaFornecedor)
        {
            case "1":
                
                var fornecedores = fornecedorDal.List();

                foreach (var fornecedor in fornecedores)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} ",
                        fornecedor.Id,
                        fornecedor.NomeFornecedor,
                        fornecedor.Documento
                     );
                }

                Console.WriteLine("Digite o id do fornecedor: (digite 'sair' para cancelar");
                string idFornecedor = Console.ReadLine();

                while (idFornecedor.ToLower() != "sair")
                {
                    if (int.TryParse(idFornecedor, out int fornecedorId))
                    {
                        var fornecedorExiste = fornecedores.Any(f => f.Id == fornecedorId);
                        if (fornecedorExiste)
                        {
                            // Criar a associação
                            FornecedorProdutos fornecedorProdutoCriado = new FornecedorProdutos()
                            {
                                IdFornecedor = fornecedorId,
                                IdProduto = produto.Id // Agora o Id do produto está disponível
                            };

                            // Salvar no banco
                            fornecedorProdutoDal.Create(fornecedorProdutoCriado);
                            Console.WriteLine("Fornecedor associado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Tente novamente.");
                    }

                    Console.WriteLine("Digite o ID do fornecedor para associar ao produto (ou 'sair' para finalizar):");
                    idFornecedor = Console.ReadLine();
                }

                Console.WriteLine("Produto cadastrado com fornecedores!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();

                break;
            case "2":
                Console.WriteLine("Produto Cadastrado sem fornecedor");
                Console.WriteLine("Produto cadastrado com sucesso!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                return;
                break;
        }

        

        Console.WriteLine("Produto cadastrado com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
