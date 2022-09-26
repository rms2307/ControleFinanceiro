using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFinanceiro.Infra.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixedCostCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedCostCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VariedCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DebitDay = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariedCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariedCost_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLog = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    DateLog = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    FixedCostCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DebitDay = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedCost_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixedCost_FixedCostCategory_FixedCostCategoryId",
                        column: x => x.FixedCostCategoryId,
                        principalTable: "FixedCostCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FixedCost_CategoryId",
                table: "FixedCost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedCost_FixedCostCategoryId",
                table: "FixedCost",
                column: "FixedCostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedCost_Id",
                table: "FixedCost",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FixedCostCategory_Id",
                table: "FixedCostCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VariedCost_CategoryId",
                table: "VariedCost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VariedCost_Id",
                table: "VariedCost",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedCost");

            migrationBuilder.DropTable(
                name: "VariedCost");

            migrationBuilder.DropTable(
                name: "FixedCostCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
