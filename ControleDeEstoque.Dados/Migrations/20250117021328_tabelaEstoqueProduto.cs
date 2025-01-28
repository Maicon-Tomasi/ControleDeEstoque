using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class tabelaEstoqueProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstoqueProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstoque1 = table.Column<int>(type: "int", nullable: false),
                    IdProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueProduto_Estoque_IdEstoque1",
                        column: x => x.IdEstoque1,
                        principalTable: "Estoque",
                        principalColumn: "IdEstoque",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstoqueProduto_Produto_IdProdutoId",
                        column: x => x.IdProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProduto_IdEstoque1",
                table: "EstoqueProduto",
                column: "IdEstoque1");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProduto_IdProdutoId",
                table: "EstoqueProduto",
                column: "IdProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueProduto");
        }
    }
}
