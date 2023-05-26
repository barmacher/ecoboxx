using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoboxPersistence.Migrations
{
    public partial class NewInitForAzureSqlTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52a5e70f-56d7-4e1d-9edb-05dfec6136cb", "AQAAAAEAACcQAAAAEFkaRePIGovxhg2aiqWtEjld2Q6xqXXMfMJyQHLZXG6HxdAMelvy5yK80EduzXPmTw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed58b4ec-fb5f-421d-a79d-f241b2efd681", "AQAAAAEAACcQAAAAEMeb7xhwdYaFPj7IGcZFr9uaA30RPlt+7a9tqG2q479CnrfbcSvgs1xsuThKF3GYRQ==" });
        }
    }
}
