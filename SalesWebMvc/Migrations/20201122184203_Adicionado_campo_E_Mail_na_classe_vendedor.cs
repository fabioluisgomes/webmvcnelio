using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class Adicionado_campo_E_Mail_na_classe_vendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "E_mail",
                table: "Vendedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "E_mail",
                table: "Vendedor");

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
