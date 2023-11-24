using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Interceptors.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "DeletedByUserId", "DeletedTime", "FirstName", "IsDeleted", "ModifiedByUserId", "ModifiedTime" },
                values: new object[] { new Guid("4cbb0a46-7023-440f-8df6-11bcaf59fba6"), new DateTimeOffset(new DateTime(2023, 11, 24, 10, 42, 13, 868, DateTimeKind.Unspecified).AddTicks(8852), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Admin", false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cbb0a46-7023-440f-8df6-11bcaf59fba6"));
        }
    }
}
