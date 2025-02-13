using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaDataSaidaEmItemSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeSaida",
                table: "ItemDeSaida",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "ItemDeSaida",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeSaida",
                table: "ItemDeSaida");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "ItemDeSaida");
        }
    }
}
