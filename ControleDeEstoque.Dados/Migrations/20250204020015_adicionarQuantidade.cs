using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class adicionarQuantidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque1",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProdutoId",
                table: "EstoqueProduto");

            migrationBuilder.RenameColumn(
                name: "IdProdutoId",
                table: "EstoqueProduto",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "IdEstoque1",
                table: "EstoqueProduto",
                newName: "IdEstoque");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdProdutoId",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdEstoque1",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdEstoque");

            migrationBuilder.AddColumn<float>(
                name: "Quantidade",
                table: "EstoqueProduto",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProduto_Id",
                table: "EstoqueProduto",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque",
                table: "EstoqueProduto",
                column: "IdEstoque",
                principalTable: "Estoque",
                principalColumn: "IdEstoque",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueProduto_Id",
                table: "EstoqueProduto");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "EstoqueProduto");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "EstoqueProduto",
                newName: "IdProdutoId");

            migrationBuilder.RenameColumn(
                name: "IdEstoque",
                table: "EstoqueProduto",
                newName: "IdEstoque1");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdProduto",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdEstoque",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdEstoque1");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque1",
                table: "EstoqueProduto",
                column: "IdEstoque1",
                principalTable: "Estoque",
                principalColumn: "IdEstoque",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProdutoId",
                table: "EstoqueProduto",
                column: "IdProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
