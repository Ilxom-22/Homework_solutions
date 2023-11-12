using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Blogandcommentrelationsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 2, 27, 177, DateTimeKind.Unspecified).AddTicks(137), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 2, 27, 177, DateTimeKind.Unspecified).AddTicks(142), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 2, 27, 177, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 13, 28, 12, 233, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 13, 28, 12, 233, DateTimeKind.Unspecified).AddTicks(4006), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 13, 28, 12, 233, DateTimeKind.Unspecified).AddTicks(4004), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
