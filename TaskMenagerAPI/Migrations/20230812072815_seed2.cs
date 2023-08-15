using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61bfbddf-f0d8-4d5e-bfe7-c9d1d136a316", "4d6aa058-9885-44d3-90b6-a9bfced26951" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76377f27-efbe-4643-9aa5-ee5bf1b095b4", "a19ad917-26e7-461e-8954-1f4ece74713a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3", 0, "f38df26a-a5cb-4b8b-ba60-aa7dbb499c0e", "User", null, false, true, false, null, null, null, null, null, false, "1b781e24-284f-436c-9fbc-328864590661", false, "test3" },
                    { "4", 0, "12c2a3d2-020d-4132-9482-9949c67fcbb7", "User", null, false, true, false, null, null, null, null, null, false, "b166d10f-6f12-473b-b2ad-8491990d0786", false, "test4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d0f8fb42-52d4-43ec-b5b1-862859feb987", "dae14413-a737-4ec4-b6b4-a7df9bec480f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b495324-9047-4e78-a5a5-517489224bae", "9a2756bf-98ad-4501-8a04-5e1ebdd62747" });
        }
    }
}
