using ControleDeEstoque.BancoDeDados;

namespace ControleDeEstoque.Menu;
internal class MenuSair : Menu
{
    public MenuSair(ControleDeEstoqueContext context) : base(context)
    {
    }

    public override void Executar()
    {
        Console.WriteLine("Tchau Tchau");
    }
}
