using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;
internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasIndex(p => p.CodigoProduto).IsUnique();
        builder.HasOne(p => p.Categoria)           
           .WithMany(c => c.Produtos)             
           .HasForeignKey(p => p.IdCategoriaProduto) 
           .OnDelete(DeleteBehavior.SetNull);

    }
}
