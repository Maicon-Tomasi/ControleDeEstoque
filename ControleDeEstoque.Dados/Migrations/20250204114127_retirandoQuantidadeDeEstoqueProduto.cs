using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class retirandoQuantidadeDeEstoqueProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "EstoqueProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantidade",
                table: "EstoqueProduto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
