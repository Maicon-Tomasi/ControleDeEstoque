using ControleDeEstoque.BancoDeDados;
using ControleDeEstoque.Database;
using ControleDeEstoque.Modelos;

namespace ControleDeEstoque.Menu;
internal class MenuEditarCidade : Menu
{
    private DAL<Cidade> CidadeDal;

    public MenuEditarCidade(ControleDeEstoqueContext context, DAL<Cidade> cidadeDal) : base(context)
    {
        CidadeDal = cidadeDal;
    }
    public override void Executar()
    {
        // Cabeçalho da tabela
        Console.WriteLine("{0,-3} | {1,-20} | {2,-20} |",
            "Id", "Cidade", "Estado");
        Console.WriteLine(new string('-', 110));

        // Listar os produtos
        var cidades = CidadeDal.List();

        foreach (var cidade in cidades)
        {
            Console.WriteLine("{0,-3} | {1,-20} | {2,-20}",
                cidade.Id,
                cidade.NomeCidade,
                cidade.Estado
             );
        }

        Console.WriteLine("Digite o id da cidade que voce deseja editar");
        string idCidade = Console.ReadLine();
        if (string.IsNullOrEmpty(idCidade))
        {
            Console.WriteLine("ID não pode ser nulo ou vazio.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            return; // Sai do método atual
        }

        if (!int.TryParse(idCidade, out int idCiadadeConvertido))
        {
            Console.WriteLine("ID deve ser um número válido.");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            return; // Sai do método atualq
        }

        var cidadeSelecionada = CidadeDal.GetFor(e => e.Id.Equals(idCiadadeConvertido));

        if (cidadeSelecionada == null)
        {
            Console.WriteLine("Cidade não encontrado!");
            return;
        }

        Console.WriteLine($"Id da cidade: {cidadeSelecionada.Id}");
        Console.WriteLine($"Nome da cidade: {cidadeSelecionada.NomeCidade}");
        Console.WriteLine($"Estado: {cidadeSelecionada.Estado}");

        Console.WriteLine("Digite o novo nome da cidade: (deixe vazio para manter o mesmo nome)");
        string novoNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            cidadeSelecionada.NomeCidade = novoNome;
        }

        Console.WriteLine("Digite o novo estado da cidade: (deixe vazio para manter o mesmo nome)");
        string novoEstado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novoEstado))
        {
            cidadeSelecionada.Estado = novoEstado;
        }

        try
        {
            CidadeDal.Update(cidadeSelecionada);
            Console.WriteLine("Cidade atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o cidade: {ex.Message}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}

