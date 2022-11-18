using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDashboard.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date_Preview",
                table: "TB_Card",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "TB_Card",
                columns: new[] { "Id", "Date_Preview", "Description", "Title" },
                values: new object[] { 1, "2022-11-18 00:00:00", "Usar a branch master, fazer pull e iniciar a migração.", "Criar Migration" });

            migrationBuilder.InsertData(
                table: "TB_Card",
                columns: new[] { "Id", "Date_Preview", "Description", "Title" },
                values: new object[] { 2, "14/11/2022 12:40:19", "Colunas utilizadas: Código, Nome e Descrição do cliente.", "Listagem Clientes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_Card",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_Card",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Preview",
                table: "TB_Card",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
