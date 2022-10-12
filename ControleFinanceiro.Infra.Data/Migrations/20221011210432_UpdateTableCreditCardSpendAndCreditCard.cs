using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class UpdateTableCreditCardSpendAndCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberInstallments",
                table: "CreditCardSpend");

            migrationBuilder.DropColumn(
                name: "remaininglimit",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "totalamount",
                table: "CreditCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberInstallments",
                table: "CreditCardSpend",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingLimit",
                table: "CreditCard",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "CreditCard",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
