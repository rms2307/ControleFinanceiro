using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class AddTableCreditCardSpendInstallment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDay",
                table: "CreditCardSpend");

            migrationBuilder.RenameColumn(
                name: "InstallmentAmount",
                table: "CreditCardSpend",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfInstallments",
                table: "CreditCardSpend",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCardSpendInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    InstallmentDueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "integer", nullable: false),
                    CreditCardSpendId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardSpendInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardSpendInstallment_CreditCardSpend_CreditCardSpendId",
                        column: x => x.CreditCardSpendId,
                        principalTable: "CreditCardSpend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSpendInstallment_CreditCardSpendId",
                table: "CreditCardSpendInstallment",
                column: "CreditCardSpendId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSpendInstallment_Id",
                table: "CreditCardSpendInstallment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardSpendInstallment");

            migrationBuilder.DropColumn(
                name: "NumberOfInstallments",
                table: "CreditCardSpend");

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
    }
}
