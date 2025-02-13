using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;

internal class ItemDeEntradaConfiguration : IEntityTypeConfiguration<ItemDeEntrada>
{
    public void Configure(EntityTypeBuilder<ItemDeEntrada> builder)
    {
        builder.HasOne(p => p.Produto)
           .WithMany(c => c.ProdutosEntrada)
           .HasForeignKey(p => p.IdProduto)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Fornecedor)
           .WithMany(c => c.FornecedorEntrada)
           .HasForeignKey(p => p.IdFornecedor)
           .OnDelete(DeleteBehavior.SetNull);

    }
}
