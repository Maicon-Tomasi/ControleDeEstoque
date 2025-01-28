using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;
internal class TransportadoraConfiguration : IEntityTypeConfiguration<Transportadora>
{
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.HasOne(t => t.Cidade)
            .WithMany(c => c.Transportadoras)
            .HasForeignKey(t => t.IdCidade)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
