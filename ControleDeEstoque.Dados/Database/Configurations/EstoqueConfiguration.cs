using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;
public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
{
    public void Configure(EntityTypeBuilder<Estoque> builder)
    {
        builder.HasKey(e => e.IdEstoque);
        builder.Property(e => e.IdEstoque)
          .ValueGeneratedOnAdd();
        builder.Property(e => e.Nome).IsRequired();
    }
}

