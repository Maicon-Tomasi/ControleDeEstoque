using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Menu;
internal class MenuEditarProduto : Menu
{
    private DAL<Produto> ProdutoDal;

    public MenuEditarProduto(ControleDeEstoqueContext context, DAL<Produto> produtoDal) : base(context)
    {
        ProdutoDal = produtoDal;
    }

    public override void Executar()
    {
        var produtosListados = ProdutoDal.List();

        Console.WriteLine("Listando Todos os produtos cadastrados\n");

        // Cabeçalho da tabela
        Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
            "Código", "Nome", "Descrição", "Unidade", "Vencimento");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var produtos = ProdutoDal.List();

        foreach (var produtoListado in produtosListados)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-30} | {3,-15} | {4,-20}",
                produtoListado.CodigoProduto,
                produtoListado.NomeProduto,
                produtoListado.DescricoDoProduto,
                produtoListado.UnidadeDeMedida,
                produtoListado.TempoDeVencimento);
        }


        Console.WriteLine("Digite o código do produto que voce deseja editar");
        string codigoProduto = Console.ReadLine();

        var produto = ProdutoDal.GetFor(e => e.CodigoProduto.Equals(codigoProduto));

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }

        Console.WriteLine($"Código do produto: {produto.CodigoProduto}");
        Console.WriteLine($"Nome do produto: {produto.NomeProduto}");
        Console.WriteLine($"Descrição: {produto.DescricoDoProduto}");
        Console.WriteLine($"Unidade De Medida: {produto.UnidadeDeMedida}");
        Console.WriteLine($"Tempo De Vencimento: {produto.TempoDeVencimento}");


        Console.WriteLine("Digite o novo código do produto: (deixe vazio para manter o mesmo)");
        string novoCodigo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoCodigo))
        {
            produto.CodigoProduto = novoCodigo;
        }

        Console.WriteLine("Digite o novo nome do produto: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            produto.NomeProduto = novoNome;
        }

        Console.WriteLine("Digite uma nova descrição do produto: (deixe vazio para manter a mesma descrição)");
        string novaDescricao = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaDescricao))
        {
            produto.DescricoDoProduto = novaDescricao;
        }

        Console.WriteLine("Digite uma nova unidade de medida do produto: (deixe vazio para manter a mesma unidade de medida)");
        string novaUnidade = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaUnidade))
        {
            produto.UnidadeDeMedida = novaUnidade;
        }

        Console.WriteLine("Digite uma novo tempo de vencimento do produto: (deixe vazio para manter a o mesmo tempo)");
        string novoTempo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoTempo))
        {
            produto.TempoDeVencimento = novoTempo;
        }

        try
        {
            ProdutoDal.Update(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o produto: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
