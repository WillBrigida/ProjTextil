using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocIndustriaTextil.Servidor.Migrations
{
    public partial class UpdateTableTCrianca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "T_crianca",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDesativacao",
                table: "T_crianca",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "T_crianca");

            migrationBuilder.DropColumn(
                name: "DataDesativacao",
                table: "T_crianca");
        }
    }
}
