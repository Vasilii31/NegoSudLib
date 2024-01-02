using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class ModifMvtStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsMouvementStock_MouvementsStocks_MouvementStockId",
                table: "DetailsMouvementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementsStocks_Clients_ClientId",
                table: "MouvementsStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementsStocks_Employes_EmployeId",
                table: "MouvementsStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementsStocks_Fournisseurs_FournisseurId",
                table: "MouvementsStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MouvementsStocks_TypesMouvement_TypeMouvementId",
                table: "MouvementsStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MouvementsStocks",
                table: "MouvementsStocks");

            migrationBuilder.RenameTable(
                name: "MouvementsStocks",
                newName: "MouvementStock");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementsStocks_TypeMouvementId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_TypeMouvementId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementsStocks_FournisseurId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementsStocks_EmployeId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_EmployeId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementsStocks_ClientId",
                table: "MouvementStock",
                newName: "IX_MouvementStock_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeMouvementId",
                table: "MouvementStock",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MouvementStock",
                table: "MouvementStock",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_MouvementStock",
                table: "MouvementStock");

            migrationBuilder.RenameTable(
                name: "MouvementStock",
                newName: "MouvementsStocks");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_TypeMouvementId",
                table: "MouvementsStocks",
                newName: "IX_MouvementsStocks_TypeMouvementId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_FournisseurId",
                table: "MouvementsStocks",
                newName: "IX_MouvementsStocks_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_EmployeId",
                table: "MouvementsStocks",
                newName: "IX_MouvementsStocks_EmployeId");

            migrationBuilder.RenameIndex(
                name: "IX_MouvementStock_ClientId",
                table: "MouvementsStocks",
                newName: "IX_MouvementsStocks_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeMouvementId",
                table: "MouvementsStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MouvementsStocks",
                table: "MouvementsStocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsMouvementStock_MouvementsStocks_MouvementStockId",
                table: "DetailsMouvementStock",
                column: "MouvementStockId",
                principalTable: "MouvementsStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementsStocks_Clients_ClientId",
                table: "MouvementsStocks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementsStocks_Employes_EmployeId",
                table: "MouvementsStocks",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementsStocks_Fournisseurs_FournisseurId",
                table: "MouvementsStocks",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouvementsStocks_TypesMouvement_TypeMouvementId",
                table: "MouvementsStocks",
                column: "TypeMouvementId",
                principalTable: "TypesMouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
