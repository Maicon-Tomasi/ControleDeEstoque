﻿// <auto-generated />
using System;
using ControleDeEstoque.BancoDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    [DbContext(typeof(ControleDeEstoqueContext))]
    [Migration("20250204020015_adicionarQuantidade")]
    partial class adicionarQuantidade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeEstoque.Modelos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumNotaFiscal")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("TransportadoraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportadoraId");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Estoque", b =>
                {
                    b.Property<int>("IdEstoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstoque"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstoque");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.EstoqueProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEstoque")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdEstoque");

                    b.HasIndex("IdProduto");

                    b.ToTable("EstoqueProduto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<int?>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.FornecedorProdutos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdFornecedor");

                    b.HasIndex("IdProduto");

                    b.ToTable("FornecedorProdutos");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.ItemDeEntrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemDeEntrada");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.ItemDeSaida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemDeSaida");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Perdas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Perdas");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescricoDoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCategoriaProduto")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempoDeVencimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeDeMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoProduto")
                        .IsUnique();

                    b.HasIndex("IdCategoriaProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Saida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Frete")
                        .HasColumnType("real");

                    b.Property<float>("Imposto")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("TransportadoraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportadoraId");

                    b.ToTable("Saida");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Transportadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCidade")
                        .HasColumnType("int");

                    b.Property<string>("NomeTransportadora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Cliente", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Entrada", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Transportadora", "Transportadora")
                        .WithMany()
                        .HasForeignKey("TransportadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transportadora");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.EstoqueProduto", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Estoque", "Estoque")
                        .WithMany("Produtos")
                        .HasForeignKey("IdEstoque")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoque.Modelos.Produto", "Produto")
                        .WithMany("Estoques")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Fornecedor", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Cidade", "Cidade")
                        .WithMany("Fornecedores")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.FornecedorProdutos", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoque.Modelos.Produto", "Produto")
                        .WithMany("Fornecedores")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.ItemDeEntrada", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.ItemDeSaida", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Perdas", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Produto", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoriaProduto")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Saida", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Transportadora", "Transportadora")
                        .WithMany()
                        .HasForeignKey("TransportadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transportadora");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Transportadora", b =>
                {
                    b.HasOne("ControleDeEstoque.Modelos.Cidade", "Cidade")
                        .WithMany("Transportadoras")
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Cidade", b =>
                {
                    b.Navigation("Fornecedores");

                    b.Navigation("Transportadoras");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Estoque", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeEstoque.Modelos.Produto", b =>
                {
                    b.Navigation("Estoques");

                    b.Navigation("Fornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
