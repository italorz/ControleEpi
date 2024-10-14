using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEpi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbEpiColaboradorList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "colaboradors",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColaboradorNome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataAdmissao = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDemissao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaboradors", x => x.ColaboradorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "epis",
                columns: table => new
                {
                    EpiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EpiName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EpiDescricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EpiValidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_epis", x => x.EpiId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListaEpi",
                columns: table => new
                {
                    ListaEpiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EpiId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaEpi", x => x.ListaEpiId);
                    table.ForeignKey(
                        name: "FK_ListaEpi_colaboradors_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "colaboradors",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaEpi_epis_EpiId",
                        column: x => x.EpiId,
                        principalTable: "epis",
                        principalColumn: "EpiId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListaEpi_ColaboradorId",
                table: "ListaEpi",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaEpi_EpiId",
                table: "ListaEpi",
                column: "EpiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaEpi");

            migrationBuilder.DropTable(
                name: "colaboradors");

            migrationBuilder.DropTable(
                name: "epis");
        }
    }
}
