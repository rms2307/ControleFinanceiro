using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class AddTablesAboutCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastFourDigits = table.Column<int>(type: "integer", nullable: false),
                    InvoiceClosingDay = table.Column<int>(type: "integer", nullable: false),
                    InvoiceDueDay = table.Column<int>(type: "integer", nullable: false),
                    LimitAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    RemainingLimit = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardSpend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreditCardId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    BuyDay = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NumberInstallments = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardSpend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardSpend_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditCardSpend_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_Id",
                table: "CreditCard",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSpend_CategoryId",
                table: "CreditCardSpend",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSpend_CreditCardId",
                table: "CreditCardSpend",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardSpend_Id",
                table: "CreditCardSpend",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardSpend");

            migrationBuilder.DropTable(
                name: "CreditCard");
        }
    }
}
