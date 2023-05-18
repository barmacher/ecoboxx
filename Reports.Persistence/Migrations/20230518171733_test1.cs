using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoboxPersistence.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ea563a57-96c1-4655-8131-3116aa952d0f", "InitManager@gmail.com", "InitManager@gmail.com", "AQAAAAEAACcQAAAAEJbFSoXAu1sE5BWChc0DhRA8SSEH2ya/Yf0yfIEG60oxQ2eVmTFyz/H4QDpdaUtNlA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "d2ef1121-2cd5-4cc6-b79f-fecf546a6fc8", null, null, "AQAAAAEAACcQAAAAEECY/TKyz9EMqGAJ5Yl41622zylvjOt3F7C1S3SkrrwNXAALO7LKTKHNLikp51IZLg==" });
        }
    }
}
