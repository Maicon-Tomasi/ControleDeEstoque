using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Dados.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoColunasNaTabelaProdutoTransportadoraeFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Cidade_CidadeId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportadora_Cidade_CidadeId",
                table: "Transportadora");

            migrationBuilder.DropIndex(
                name: "IX_Transportadora_CidadeId",
                table: "Transportadora");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Transportadora");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Transportadora",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Transportadora",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoProduto",
                table: "Produto",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaProduto",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Fornecedor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CidadeId",
                table: "Fornecedor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_IdCidade",
                table: "Transportadora",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CodigoProduto",
                table: "Produto",
                column: "CodigoProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCategoriaProduto",
                table: "Produto",
                column: "IdCategoriaProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Cidade_CidadeId",
                table: "Fornecedor",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_IdCategoriaProduto",
                table: "Produto",
                column: "IdCategoriaProduto",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Produto_Fornecedor_FornecedorId",
            //    table: "Produto",
            //    column: "FornecedorId",
            //    principalTable: "Fornecedor",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportadora_Cidade_IdCidade",
                table: "Transportadora",
                column: "IdCidade",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Cidade_CidadeId",
                table: "Fornecedor");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Produto_Categoria_IdCategoriaProduto",
            //    table: "Produto");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Produto_Fornecedor_FornecedorId",
            //    table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportadora_Cidade_IdCidade",
                table: "Transportadora");

            migrationBuilder.DropIndex(
                name: "IX_Transportadora_IdCidade",
                table: "Transportadora");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CodigoProduto",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdCategoriaProduto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Transportadora");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdCategoriaProduto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Transportadora",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Transportadora",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoProduto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Fornecedor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CidadeId",
                table: "Fornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_CidadeId",
                table: "Transportadora",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Cidade_CidadeId",
                table: "Fornecedor",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportadora_Cidade_CidadeId",
                table: "Transportadora",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
