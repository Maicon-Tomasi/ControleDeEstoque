using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class alterandoLogicaNaEntradaDeProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeEntrada_Produto_ProdutoId",
                table: "ItemDeEntrada");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ItemDeEntrada",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDeEntrada_ProdutoId",
                table: "ItemDeEntrada",
                newName: "IX_ItemDeEntrada_IdProduto");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "EstoqueProduto",
                newName: "IdItemDeEntrada");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdProduto",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdItemDeEntrada");

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "ItemDeEntrada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeEntrada_IdFornecedor",
                table: "ItemDeEntrada",
                column: "IdFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_ItemDeEntrada_IdItemDeEntrada",
                table: "EstoqueProduto",
                column: "IdItemDeEntrada",
                principalTable: "ItemDeEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeEntrada_Fornecedor_IdFornecedor",
                table: "ItemDeEntrada",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeEntrada_Produto_IdProduto",
                table: "ItemDeEntrada",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_ItemDeEntrada_IdItemDeEntrada",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeEntrada_Fornecedor_IdFornecedor",
                table: "ItemDeEntrada");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeEntrada_Produto_IdProduto",
                table: "ItemDeEntrada");

            migrationBuilder.DropIndex(
                name: "IX_ItemDeEntrada_IdFornecedor",
                table: "ItemDeEntrada");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "ItemDeEntrada");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "ItemDeEntrada",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDeEntrada_IdProduto",
                table: "ItemDeEntrada",
                newName: "IX_ItemDeEntrada_ProdutoId");

            migrationBuilder.RenameColumn(
                name: "IdItemDeEntrada",
                table: "EstoqueProduto",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdItemDeEntrada",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeEntrada_Produto_ProdutoId",
                table: "ItemDeEntrada",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
