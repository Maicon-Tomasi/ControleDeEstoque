using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.BancoDeDados;
 public class ControleDeEstoqueContext: DbContext
{
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Cidade> Cidade { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Estoque> Estoque { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<ItemDeEntrada> ItemDeEntrada { get; set; }
    public DbSet<ItemDeSaida> ItemDeSaida { get; set; }
    public DbSet<Perdas> Perdas { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Saida> Saida { get; set; }
    public DbSet<Transportadora> Transportadora { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<EstoqueProduto> EstoqueProduto { get; set; }
    public DbSet<FornecedorProdutos> FornecedorProdutos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ControleDeEstoque;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleDeEstoqueContext).Assembly);            
    }

}
