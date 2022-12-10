using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Data.Migrations
{
    public partial class MigracionInicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tarjeta",
                table: "Cuenta",
                type: "numeric(20,0)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tarjeta",
                table: "Cuenta",
                type: "numeric",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)",
                oldMaxLength: 16);
        }
    }
}
