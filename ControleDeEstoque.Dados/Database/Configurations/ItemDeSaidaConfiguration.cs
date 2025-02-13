using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;

internal class ItemDeSaidaConfiguration : IEntityTypeConfiguration<ItemDeSaida>
{
    public void Configure(EntityTypeBuilder<ItemDeSaida> builder)
    {
        builder.HasOne(p => p.Produto)
           .WithMany(c => c.ProdutosSaida)
           .HasForeignKey(p => p.IdProduto)
           .OnDelete(DeleteBehavior.Cascade);

    }
}
