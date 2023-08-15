using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "IsActive", "SecurityStamp" },
                values: new object[] { "d0f8fb42-52d4-43ec-b5b1-862859feb987", true, "dae14413-a737-4ec4-b6b4-a7df9bec480f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "IsActive", "SecurityStamp" },
                values: new object[] { "1b495324-9047-4e78-a5a5-517489224bae", true, "9a2756bf-98ad-4501-8a04-5e1ebdd62747" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "IsActive", "SecurityStamp" },
                values: new object[] { "9a75e8dc-f4e4-4c4e-95aa-ef61924e9a49", false, "76d403d3-5acf-426e-9f90-1027da869ac4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "IsActive", "SecurityStamp" },
                values: new object[] { "e25e5d29-ab42-4da4-a96f-347fbf07b8aa", false, "b500efe7-b6a9-4143-a19b-cfdbee9fdfa3" });
        }
    }
}
