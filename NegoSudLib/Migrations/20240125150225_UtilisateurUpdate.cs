using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class UtilisateurUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gerant",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "HMotDePasse",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "MailUtilisateur",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Utilisateurs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_UserId",
                table: "Utilisateurs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_AspNetUsers_UserId",
                table: "Utilisateurs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_AspNetUsers_UserId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_UserId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Utilisateurs");

            migrationBuilder.AddColumn<bool>(
                name: "Gerant",
                table: "Utilisateurs",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HMotDePasse",
                table: "Utilisateurs",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MailUtilisateur",
                table: "Utilisateurs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
