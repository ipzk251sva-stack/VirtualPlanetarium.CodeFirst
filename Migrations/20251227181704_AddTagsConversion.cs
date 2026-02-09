using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPlanetarium.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "CelestialObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "");

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "");

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tags",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "CelestialObjects");
        }
    }
}
