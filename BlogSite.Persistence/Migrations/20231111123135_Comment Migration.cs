using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CommentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 21, 36, 299, DateTimeKind.Unspecified).AddTicks(4805), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 21, 36, 299, DateTimeKind.Unspecified).AddTicks(4810), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 12, 21, 36, 299, DateTimeKind.Unspecified).AddTicks(4809), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
