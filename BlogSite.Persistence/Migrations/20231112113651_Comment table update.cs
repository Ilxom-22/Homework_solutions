using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Commenttableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 11, 36, 51, 804, DateTimeKind.Unspecified).AddTicks(2921), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 11, 36, 51, 804, DateTimeKind.Unspecified).AddTicks(2928), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 11, 36, 51, 804, DateTimeKind.Unspecified).AddTicks(2926), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 31, 35, 801, DateTimeKind.Unspecified).AddTicks(7152), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 31, 35, 801, DateTimeKind.Unspecified).AddTicks(7159), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 31, 35, 801, DateTimeKind.Unspecified).AddTicks(7157), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
