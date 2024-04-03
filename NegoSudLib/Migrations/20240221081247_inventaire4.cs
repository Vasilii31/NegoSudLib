using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class inventaire4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInventaire",
                table: "LignesInventaires",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInventaire",
                table: "LignesInventaires");
        }
    }
}
