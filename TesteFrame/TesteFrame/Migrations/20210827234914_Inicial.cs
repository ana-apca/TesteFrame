using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteFrame.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Imagem = table.Column<byte[]>(type: "longblob", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Codigo", "Descricao", "Imagem", "Nome", "Quantidade", "Valor" },
                values: new object[,]
                {
                    { 1, "Maçã", null, "Maçã", 10, 2m },
                    { 2, "Banana", null, "Banana", 10, 4m },
                    { 3, "Manga", null, "Manga", 10, 3m },
                    { 4, "Morango", null, "Morango", 10, 6m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
