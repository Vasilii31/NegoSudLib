using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class AjoutClassesAbstraites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsMouvementStock_MouvementStock_MouvementStockId",
                table: "DetailsMouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStock_Clients_ClientId",
                table: "MouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStock_Employes_EmployeId",
                table: "MouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStock_Fournisseurs_FournisseurId",
                table: "MouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStock_TypesMouvement_TypeMouvementId",
                table: "MouvementStock");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MouvementStock",
                table: "MouvementStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employes",
                table: "Employes");

            migrationBuilder.RenameTable(
                name: "MouvementStock",
                newName: "MouvementStocks");

            migrationBuilder.RenameTable(
                name: "Employes",
                newName: "Utilisateurs");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_TypeMouvementId",
                table: "MouvementStocks",
                newName: "IX_MouvementStocks_TypeMouvementId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_FournisseurId",
                table: "MouvementStocks",
                newName: "IX_MouvementStocks_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_EmployeId",
                table: "MouvementStocks",
                newName: "IX_MouvementStocks_EmployeId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_ClientId",
                table: "MouvementStocks",
                newName: "IX_MouvementStocks_ClientId");

            migrationBuilder.AlterColumn<bool>(
                name: "Gerant",
                table: "Utilisateurs",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Utilisateurs",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumClient",
                table: "Utilisateurs",
                type: "varchar(80)",
                maxLength: 80,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MouvementStocks",
                table: "MouvementStocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsMouvementStock_MouvementStocks_MouvementStockId",
                table: "DetailsMouvementStock",
                column: "MouvementStockId",
                principalTable: "MouvementStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStocks_Fournisseurs_FournisseurId",
                table: "MouvementStocks",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStocks_TypesMouvement_TypeMouvementId",
                table: "MouvementStocks",
                column: "TypeMouvementId",
                principalTable: "TypesMouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStocks_Utilisateurs_ClientId",
                table: "MouvementStocks",
                column: "ClientId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStocks_Utilisateurs_EmployeId",
                table: "MouvementStocks",
                column: "EmployeId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsMouvementStock_MouvementStocks_MouvementStockId",
                table: "DetailsMouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStocks_Fournisseurs_FournisseurId",
                table: "MouvementStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStocks_TypesMouvement_TypeMouvementId",
                table: "MouvementStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStocks_Utilisateurs_ClientId",
                table: "MouvementStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementStocks_Utilisateurs_EmployeId",
                table: "MouvementStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MouvementStocks",
                table: "MouvementStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "NumClient",
                table: "Utilisateurs");

            migrationBuilder.RenameTable(
                name: "MouvementStocks",
                newName: "MouvementStock");

            migrationBuilder.RenameTable(
                name: "Utilisateurs",
                newName: "Employes");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStocks_TypeMouvementId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_TypeMouvementId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStocks_FournisseurId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStocks_EmployeId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_EmployeId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStocks_ClientId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_ClientId");

            migrationBuilder.AlterColumn<bool>(
                name: "Gerant",
                table: "Employes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MouvementStock",
                table: "MouvementStock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employes",
                table: "Employes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdresseUtilisateur = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HMotDePasse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MailUtilisateur = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomUtilisateur = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumClient = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumTelUtilisateur = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrenomUtilisateur = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsMouvementStock_MouvementStock_MouvementStockId",
                table: "DetailsMouvementStock",
                column: "MouvementStockId",
                principalTable: "MouvementStock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStock_Clients_ClientId",
                table: "MouvementStock",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStock_Employes_EmployeId",
                table: "MouvementStock",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStock_Fournisseurs_FournisseurId",
                table: "MouvementStock",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementStock_TypesMouvement_TypeMouvementId",
                table: "MouvementStock",
                column: "TypeMouvementId",
                principalTable: "TypesMouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
