using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPlanetarium.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintsAndSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "ObjectGroups",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            // Сценарій 5: Custom SQL для генерації коду (перші 3 літери назви капсом)
            migrationBuilder.Sql("UPDATE ObjectGroups SET GroupCode = UPPER(LEFT(Name, 3))");

            migrationBuilder.UpdateData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "GroupCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "ObjectGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "GroupCode",
                value: null);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reviews_Rating",
                table: "Reviews",
                sql: "[Rating] >= 1 AND [Rating] <= 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Reviews_Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "ObjectGroups");
        }
    }
}
