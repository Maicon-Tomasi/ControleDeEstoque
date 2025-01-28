using ControleDeEstoque.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Dados.Database.Configurations;
internal class ProdutosFornecedoresConfiguration : IEntityTypeConfiguration<FornecedorProdutos>
{
    public void Configure(EntityTypeBuilder<FornecedorProdutos> builder)
    {
        builder.HasIndex(p => p.Id).IsUnique();
        builder.HasOne(fp => fp.Produto)
            .WithMany(p => p.Fornecedores) // Supondo que Produto tenha uma coleção de FornecedorProdutos
            .HasForeignKey(fp => fp.IdProduto)
            .OnDelete(DeleteBehavior.Cascade); // Altere o DeleteBehavior conforme sua regra de negócio

        // Configuração do relacionamento com a entidade Fornecedor
        builder.HasOne(fp => fp.Fornecedor)
            .WithMany(f => f.Produtos) // Supondo que Fornecedor tenha uma coleção de FornecedorProdutos
            .HasForeignKey(fp => fp.IdFornecedor)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
