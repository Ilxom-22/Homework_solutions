using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotificationHistoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "NotificationsHistory",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NotificationType",
                table: "NotificationsHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "NotificationsHistory",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "NotificationsHistory");
        }
    }
}
