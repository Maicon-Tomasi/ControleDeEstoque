using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Produto_Fornecedor_FornecedorId",
            //    table: "Produto");

            //migrationBuilder.DropIndex(
            //    name: "IX_Produto_FornecedorId",
            //    table: "Produto");

            //migrationBuilder.DropColumn(
            //    name: "FornecedorId",
            //    table: "Produto");

            //migrationBuilder.DropColumn(
            //    name: "IdFornecedor",
            //    table: "Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "FornecedorId",
            //    table: "Produto",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdFornecedor",
            //    table: "Produto",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Produto_FornecedorId",
            //    table: "Produto",
            //    column: "FornecedorId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Produto_Fornecedor_FornecedorId",
            //    table: "Produto",
            //    column: "FornecedorId",
            //    principalTable: "Fornecedor",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
