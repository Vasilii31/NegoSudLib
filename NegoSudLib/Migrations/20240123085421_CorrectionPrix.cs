using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionPrix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrixVentes_Produits_ProduitId",
                table: "PrixVentes");

            migrationBuilder.DropTable(
                name: "PrixAchats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrixVentes",
                table: "PrixVentes");

            migrationBuilder.RenameTable(
                name: "PrixVentes",
                newName: "Prix");

            migrationBuilder.RenameIndex(
                name: "IX_PrixVentes_ProduitId",
                table: "Prix",
                newName: "IX_Prix_ProduitId");

            migrationBuilder.AlterColumn<float>(
                name: "Taxe",
                table: "Prix",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Promotion",
                table: "Prix",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Prix",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FournisseurId",
                table: "Prix",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prix",
                table: "Prix",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prix_FournisseurId",
                table: "Prix",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prix_Fournisseurs_FournisseurId",
                table: "Prix",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prix_Produits_ProduitId",
                table: "Prix",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prix_Fournisseurs_FournisseurId",
                table: "Prix");

            migrationBuilder.DropForeignKey(
                name: "FK_Prix_Produits_ProduitId",
                table: "Prix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prix",
                table: "Prix");

            migrationBuilder.DropIndex(
                name: "IX_Prix_FournisseurId",
                table: "Prix");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Prix");

            migrationBuilder.DropColumn(
                name: "FournisseurId",
                table: "Prix");

            migrationBuilder.RenameTable(
                name: "Prix",
                newName: "PrixVentes");

            migrationBuilder.RenameIndex(
                name: "IX_Prix_ProduitId",
                table: "PrixVentes",
                newName: "IX_PrixVentes_ProduitId");

            migrationBuilder.AlterColumn<float>(
                name: "Taxe",
                table: "PrixVentes",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Promotion",
                table: "PrixVentes",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrixVentes",
                table: "PrixVentes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PrixAchats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FournisseurId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PrixCarton = table.Column<float>(type: "float", nullable: false),
                    PrixUnite = table.Column<float>(type: "float", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrixAchats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrixAchats_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrixAchats_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PrixAchats_FournisseurId",
                table: "PrixAchats",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_PrixAchats_ProduitId",
                table: "PrixAchats",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrixVentes_Produits_ProduitId",
                table: "PrixVentes",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
