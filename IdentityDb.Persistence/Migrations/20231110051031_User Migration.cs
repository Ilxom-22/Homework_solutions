using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityDb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 5, 10, 31, 378, DateTimeKind.Utc).AddTicks(8425), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 5, 10, 31, 378, DateTimeKind.Utc).AddTicks(8429), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 5, 10, 31, 378, DateTimeKind.Utc).AddTicks(8431), null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "IsEmailVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("cefdf4ea-215b-45cb-8069-40455d1c8336"), "", "Admin", true, "Admin", "", new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5799), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5806), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
