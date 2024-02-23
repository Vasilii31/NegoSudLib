using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class ajoutInventaire2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateInventaire = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumInventaire = table.Column<int>(type: "int", nullable: false),
                    IsValidated = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaires", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LignesInventaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantiteAvantInventaire = table.Column<int>(type: "int", nullable: false),
                    QuantiteApresInventaire = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesInventaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignesInventaires_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LignesInventaires_IdProduit",
                table: "LignesInventaires",
                column: "IdProduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventaires");

            migrationBuilder.DropTable(
                name: "LignesInventaires");
        }
    }
}
