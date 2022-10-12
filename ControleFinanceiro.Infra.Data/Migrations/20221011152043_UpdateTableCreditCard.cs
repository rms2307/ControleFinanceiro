using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class UpdateTableCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "RemainingLimit",
                table: "CreditCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
