using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class configurationItemDeSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeSaida_Produto_ProdutoId",
                table: "ItemDeSaida");

            migrationBuilder.DropIndex(
                name: "IX_ItemDeSaida_ProdutoId",
                table: "ItemDeSaida");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemDeSaida");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeSaida_IdProduto",
                table: "ItemDeSaida",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeSaida_Produto_IdProduto",
                table: "ItemDeSaida",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeSaida_Produto_IdProduto",
                table: "ItemDeSaida");

            migrationBuilder.DropIndex(
                name: "IX_ItemDeSaida_IdProduto",
                table: "ItemDeSaida");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItemDeSaida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeSaida_ProdutoId",
                table: "ItemDeSaida",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeSaida_Produto_ProdutoId",
                table: "ItemDeSaida",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
