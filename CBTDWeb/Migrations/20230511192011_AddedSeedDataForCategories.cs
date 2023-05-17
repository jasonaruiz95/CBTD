using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CBTDWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateModified", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6674), 1, "Beverages" },
                    { 2, new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6719), 2, "Wine" },
                    { 3, new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6721), 3, "Books" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
