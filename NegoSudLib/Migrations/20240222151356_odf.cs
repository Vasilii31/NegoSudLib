using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class odf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdInventaire",
                table: "LignesInventaires",
                newName: "InventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesInventaires_InventaireId",
                table: "LignesInventaires",
                column: "InventaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesInventaires_Inventaires_InventaireId",
                table: "LignesInventaires",
                column: "InventaireId",
                principalTable: "Inventaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesInventaires_Inventaires_InventaireId",
                table: "LignesInventaires");

            migrationBuilder.DropIndex(
                name: "IX_LignesInventaires_InventaireId",
                table: "LignesInventaires");

            migrationBuilder.RenameColumn(
                name: "InventaireId",
                table: "LignesInventaires",
                newName: "IdInventaire");
        }
    }
}
