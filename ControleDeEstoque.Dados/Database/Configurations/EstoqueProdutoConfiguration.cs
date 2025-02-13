using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;

internal class EstoqueProdutoConfiguration : IEntityTypeConfiguration<EstoqueProduto>
{
    public void Configure(EntityTypeBuilder<EstoqueProduto> builder)
    {
        builder.HasIndex(p => p.Id).IsUnique();
        builder.HasOne(p => p.ItemDeEntrada)
            .WithMany(e => e.Estoques) // Supondo que Produto tenha uma coleção de FornecedorProdutos
            .HasForeignKey(fp => fp.IdItemDeEntrada)
            .OnDelete(DeleteBehavior.Cascade); // Altere o DeleteBehavior conforme sua regra de negócio

        builder.HasOne(es => es.Estoque)
            .WithMany(f => f.Produtos) 
            .HasForeignKey(fp => fp.IdEstoque)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
