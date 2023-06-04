using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoboxPersistence.Migrations
{
    public partial class addIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c0716e2-735b-4d2f-95cb-d9bb62108950", "AQAAAAEAACcQAAAAEKd0aHa9sZmxxM4l9ocZGwdWEILkkVlr2VoQ2alLghtzOPmQXzZGvThv80DJ+IVeFQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "e88cd634-7984-48cc-81db-e0e6f7bfd7ca", "User", "Admin@gmail.com", false, false, null, null, "Admin@gmail.com", "Admin@gmail.com", "AQAAAAEAACcQAAAAEPGWSmv7BnrzToC6QnYHGLsTLrlkbYauvxAGLc8JcNYDbAC4FXBhzqDOh1Bm5HxOgg==", null, false, null, false, "Admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52a5e70f-56d7-4e1d-9edb-05dfec6136cb", "AQAAAAEAACcQAAAAEFkaRePIGovxhg2aiqWtEjld2Q6xqXXMfMJyQHLZXG6HxdAMelvy5yK80EduzXPmTw==" });
        }
    }
}
