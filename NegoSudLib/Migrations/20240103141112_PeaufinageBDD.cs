using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class PeaufinageBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FournisseurId",
                table: "Produits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurId",
                table: "Produits",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Fournisseurs_FournisseurId",
                table: "Produits",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Fournisseurs_FournisseurId",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_FournisseurId",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "FournisseurId",
                table: "Produits");
        }
    }
}
