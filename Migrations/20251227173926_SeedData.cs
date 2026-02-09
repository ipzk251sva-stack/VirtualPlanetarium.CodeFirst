using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VirtualPlanetarium.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ObjectGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Solar System" },
                    { 2, "Local Group" },
                    { 3, "Deep Space" }
                });

            migrationBuilder.InsertData(
                table: "ObjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Star" },
                    { 2, "Planet" },
                    { 3, "Galaxy" },
                    { 4, "Nebula" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[] { 1, "admin@planetarium.com", "admin" });

            migrationBuilder.InsertData(
                table: "CelestialObjects",
                columns: new[] { "Id", "Declination", "Description", "DiscoveryDate", "GroupId", "Name", "RightAscension", "TypeId" },
                values: new object[,]
                {
                    { 1, null, "The star at the center of the Solar System", null, 1, "Sun", null, 1 },
                    { 2, null, "Our home planet", null, 1, "Earth", null, 2 },
                    { 3, null, "Nearest major galaxy", null, 2, "Andromeda", null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjectTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
