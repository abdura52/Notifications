using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationHistoryConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsHistories",
                table: "SmsHistories");

            migrationBuilder.DropColumn(
                name: "SendedTime",
                table: "SmsHistories");

            migrationBuilder.RenameTable(
                name: "SmsHistories",
                newName: "NotificationHistory");

            migrationBuilder.AddColumn<int>(
                name: "NotificationType",
                table: "NotificationHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmailAddress",
                table: "NotificationHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverPhoneNumber",
                table: "NotificationHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderEmailAddress",
                table: "NotificationHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPhoneNumber",
                table: "NotificationHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "NotificationHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "NotificationHistory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationHistory",
                table: "NotificationHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistory_TemplateId",
                table: "NotificationHistory",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHistory_NotificationTemplate_TemplateId",
                table: "NotificationHistory",
                column: "TemplateId",
                principalTable: "NotificationTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHistory_NotificationTemplate_TemplateId",
                table: "NotificationHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationHistory",
                table: "NotificationHistory");

            migrationBuilder.DropIndex(
                name: "IX_NotificationHistory_TemplateId",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "ReceiverEmailAddress",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "ReceiverPhoneNumber",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "SenderEmailAddress",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "SenderPhoneNumber",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "NotificationHistory");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "NotificationHistory");

            migrationBuilder.RenameTable(
                name: "NotificationHistory",
                newName: "SmsHistories");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendedTime",
                table: "SmsHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsHistories",
                table: "SmsHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmailHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SendedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailHistories", x => x.Id);
                });
        }
    }
}
