using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;
internal class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasOne(f => f.Cidade)
            .WithMany(f => f.Fornecedores)
            .HasForeignKey(f => f.CidadeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

