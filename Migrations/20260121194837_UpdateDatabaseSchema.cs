using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPlanetarium.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Перевіряємо, чи існує колонка Color перед її видаленням
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'CelestialObjects' AND COLUMN_NAME = 'Color')
                BEGIN
                    DECLARE @var nvarchar(max);
                    SELECT @var = QUOTENAME([d].[name])
                    FROM [sys].[default_constraints] [d]
                    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
                    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CelestialObjects]') AND [c].[name] = N'Color');
                    IF @var IS NOT NULL EXEC(N'ALTER TABLE [CelestialObjects] DROP CONSTRAINT ' + @var + ';');
                    ALTER TABLE [CelestialObjects] DROP COLUMN [Color];
                END
            ");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "CelestialObjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: null);

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: null);

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tags",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "CelestialObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CelestialObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Tags" },
                values: new object[] { null, "" });

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Tags" },
                values: new object[] { null, "" });

            migrationBuilder.UpdateData(
                table: "CelestialObjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Tags" },
                values: new object[] { null, "" });
        }
    }
}
