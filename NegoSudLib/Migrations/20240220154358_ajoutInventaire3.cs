using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegoSudLib.Migrations
{
    /// <inheritdoc />
    public partial class ajoutInventaire3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumInventaire",
                table: "Inventaires");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumInventaire",
                table: "Inventaires",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
