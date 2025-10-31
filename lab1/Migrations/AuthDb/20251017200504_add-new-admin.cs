using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab1.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addnewadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b79364d-5ceb-4aed-b902-891dc5b93d9a", null, "Admin", "ADMIN" },
                    { "9917a874-002a-4516-b2ba-e98f366f272d", null, "Instractour", "INSTRACTOUR" },
                    { "fee63abc-148a-4186-95e6-98148c044eb4", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7f081f5-45bf-465c-a700-5d2d04da465b", 0, "8b2e5ba2-8012-4f63-927c-188321e3398d", "admin@iti.gov", false, false, null, "ADMIN@ITI.GOV", "ADMIN@ITI.GOV", "AQAAAAIAAYagAAAAEJzWV5q1aBJi9heYjw8kFIxJ7QtvJSeA1a2HlS84sTf6Ee0MOA4LtBZoXl5KratA3Q==", null, false, "d2982df6-f235-49e2-a52d-15326b6d1aac", false, "admin@iti.gov" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b79364d-5ceb-4aed-b902-891dc5b93d9a", "f7f081f5-45bf-465c-a700-5d2d04da465b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9917a874-002a-4516-b2ba-e98f366f272d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fee63abc-148a-4186-95e6-98148c044eb4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b79364d-5ceb-4aed-b902-891dc5b93d9a", "f7f081f5-45bf-465c-a700-5d2d04da465b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b79364d-5ceb-4aed-b902-891dc5b93d9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7f081f5-45bf-465c-a700-5d2d04da465b");
        }
    }
}
