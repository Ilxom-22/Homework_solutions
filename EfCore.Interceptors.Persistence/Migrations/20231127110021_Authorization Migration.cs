using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Interceptors.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthorizationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cbb0a46-7023-440f-8df6-11bcaf59fba6"),
                columns: new[] { "CreatedTime", "Password", "Role", "UserName" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 11, 27, 11, 0, 20, 457, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 0, 0, 0, 0)), "admin", 0, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cbb0a46-7023-440f-8df6-11bcaf59fba6"),
                columns: new[] { "CreatedTime", "FirstName" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 11, 24, 10, 42, 13, 868, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 0, 0, 0, 0)), "Admin" });
        }
    }
}
