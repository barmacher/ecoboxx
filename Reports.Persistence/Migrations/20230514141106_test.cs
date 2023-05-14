using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Applications.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 4, "Admin", "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eaaebc82-917b-4471-ab0c-a5270fd44022", "AQAAAAEAACcQAAAAELqGUz1QNLEf+xwoEv0PSW93b8Dz/mkxQksyF2xTALOmIpBawNb19PYD8wXkpdYh3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2ced44f-d65d-49e0-a7b0-f153b104d72f", "AQAAAAEAACcQAAAAEH/0cY+/0ou8rlbsRGH21pXMON3KBSW5RIq3XMOegzOfGSUFrdJ9bEp5x/L3U0gQsw==" });
        }
    }
}
