using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Applications.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _20230424042824_addedBrigade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InformalName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrigadeId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BrigadeMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BrigadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrigadeMembers_AspNetUsers_BrigadeId",
                        column: x => x.BrigadeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "Manager", "Manager", "Manager" },
                    { 2, "BrigadeAccount", "BrigadeAccount", "BrigadeAccount" },
                    { 3, "Client", "Client", "Client" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "b2ced44f-d65d-49e0-a7b0-f153b104d72f", "User", "InitManager@gmail.com", false, false, null, null, null, null, "AQAAAAEAACcQAAAAEH/0cY+/0ou8rlbsRGH21pXMON3KBSW5RIq3XMOegzOfGSUFrdJ9bEp5x/L3U0gQsw==", null, false, null, false, "InitManager@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_BrigadeId",
                table: "Applications",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeMembers_BrigadeId",
                table: "BrigadeMembers",
                column: "BrigadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_BrigadeId",
                table: "Applications",
                column: "BrigadeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_BrigadeId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "BrigadeMembers");

            migrationBuilder.DropIndex(
                name: "IX_Applications_BrigadeId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InformalName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BrigadeId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Applications");
        }
    }
}
