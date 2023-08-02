using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class active : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIsActive",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fac6c0b2-a862-4ff4-aedf-bf99d3414ec1", "d9f2cdff-b8f8-45a2-81cb-5063c39e89a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53b1520e-f22d-4e38-b677-28416ffa329f", "d18fa7ac-db21-40ed-802a-1f7cf2b01f3e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "UserIsActive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d81bb2d-a5ef-4e0c-8c3d-a1c5df396c68", "7f6fb2f8-db21-4d11-9c0f-b1cbef48dda3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fec05217-c852-44c0-9f34-8c26ff51b39b", "bf7da99f-5e1d-4c36-90e0-96aaf64ce008" });
        }
    }
}
