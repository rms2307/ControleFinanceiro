using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class UpdateTableCreditCardSpend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CreditCardSpend",
                newName: "InstallmentAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDay",
                table: "CreditCardSpend",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDay",
                table: "CreditCardSpend");

            migrationBuilder.RenameColumn(
                name: "InstallmentAmount",
                table: "CreditCardSpend",
                newName: "Amount");
        }
    }
}
