using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoboxPersistence.Migrations
{
    public partial class qwerwer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "AspNetUserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9020afb4-27e6-4e17-b926-37482dc2ba8c", "AQAAAAEAACcQAAAAEPbiV2I/7cy0qhzSrge7CIj2kA+rSIBjAZGtJf6yTu8u/QUyRinBQzByywzMT8TqpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a602af6-b6a0-4f41-9cea-9997693184fe", "AQAAAAEAACcQAAAAEMLcGpNOgImIxUVpFQYpy4V9qM11iegPxx2qXHRpZu3ei+vMQkFTcVinnKbEM9vh2A==" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c0716e2-735b-4d2f-95cb-d9bb62108950", "AQAAAAEAACcQAAAAEKd0aHa9sZmxxM4l9ocZGwdWEILkkVlr2VoQ2alLghtzOPmQXzZGvThv80DJ+IVeFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e88cd634-7984-48cc-81db-e0e6f7bfd7ca", "AQAAAAEAACcQAAAAEPGWSmv7BnrzToC6QnYHGLsTLrlkbYauvxAGLc8JcNYDbAC4FXBhzqDOh1Bm5HxOgg==" });
        }
    }
}
