using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BlogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Type",
                table: "Roles",
                newName: "IX_Roles_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_AuthorId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Type",
                table: "Role",
                newName: "IX_Role_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("07ae0fb2-3609-4365-abb9-38541e516326"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 8, 13, 26, 932, DateTimeKind.Unspecified).AddTicks(7075), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9601306c-a04d-4241-9d70-7f4f73868eeb"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 8, 13, 26, 932, DateTimeKind.Unspecified).AddTicks(7080), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eb45fd2b-c31a-4af1-9d2d-0bef2b94f54a"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 11, 8, 13, 26, 932, DateTimeKind.Unspecified).AddTicks(7078), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
