using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Blogandcommentrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 23, 35, 220, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 23, 35, 220, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 12, 14, 23, 35, 220, DateTimeKind.Unspecified).AddTicks(7993), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlogId1",
                table: "Comments",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id");
        }
    }
}
