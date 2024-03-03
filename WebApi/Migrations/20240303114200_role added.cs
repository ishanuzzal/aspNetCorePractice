using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class roleadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f1cd4a4-dc61-4403-be13-e6e6ae9b4d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fe5ab5c-afac-46b7-9f65-21748c34a0c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aceec53d-eeb3-4d9c-8f8b-dac4a2d5e3ec", null, "admin", "ADMIN" },
                    { "ed1ea9fa-c9ea-41bc-b2ca-292246c1c65b", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aceec53d-eeb3-4d9c-8f8b-dac4a2d5e3ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1ea9fa-c9ea-41bc-b2ca-292246c1c65b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f1cd4a4-dc61-4403-be13-e6e6ae9b4d4e", null, "user", "USER" },
                    { "8fe5ab5c-afac-46b7-9f65-21748c34a0c1", null, "admin", "ADMIN" }
                });
        }
    }
}
