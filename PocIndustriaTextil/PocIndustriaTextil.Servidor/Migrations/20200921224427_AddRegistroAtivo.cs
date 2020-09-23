using Microsoft.EntityFrameworkCore.Migrations;

namespace PocIndustriaTextil.Servidor.Migrations
{
    public partial class AddRegistroAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RegistroAtivo",
                table: "T_crianca",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistroAtivo",
                table: "T_crianca");
        }
    }
}
