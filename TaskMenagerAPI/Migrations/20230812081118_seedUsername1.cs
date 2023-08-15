using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedUsername1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12b0d1ff-7fd4-42bb-9a5c-e9a6b74e42b1", "9ad8e7f3-42f1-4da6-847d-6a2a6f78c4ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a1f586e-6174-43f7-8f03-8830a2d0036a", "e8365a2c-7e72-4bbc-a4f5-79f56236e48d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7bd0a8c2-4d90-42ac-a606-6d96d99a1742", "8c69d213-d53d-4a58-a9fc-77c3bc111b8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09c843d5-5943-4917-86e5-bd444ac6f8d3", "2744a73a-a2f0-48db-9f9e-03d4d848a702" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b5fe5cc2-86d2-4d34-bd88-39f209c4b369", "85fdaced-c1f0-4bc0-9a7f-4952a6e976e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b430be6c-a438-4418-bda0-446d290366c0", "c03cdbd3-b5d2-436f-942f-4f2b920f2553" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6363cebe-54af-4c19-8d14-397f495e098c", "fe6738f3-efcf-48fa-b38f-41b2dbd19d91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58ea4d5d-a3a7-4f20-b158-14c851fb3b30", "3f46d870-8ed5-48a7-8293-3ad009393e3e" });
        }
    }
}
