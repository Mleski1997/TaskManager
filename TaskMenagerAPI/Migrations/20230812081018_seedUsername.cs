using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "b5fe5cc2-86d2-4d34-bd88-39f209c4b369", "85fdaced-c1f0-4bc0-9a7f-4952a6e976e3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "b430be6c-a438-4418-bda0-446d290366c0", "c03cdbd3-b5d2-436f-942f-4f2b920f2553", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "6363cebe-54af-4c19-8d14-397f495e098c", "fe6738f3-efcf-48fa-b38f-41b2dbd19d91", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "58ea4d5d-a3a7-4f20-b158-14c851fb3b30", "3f46d870-8ed5-48a7-8293-3ad009393e3e", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "b14a7ffe-7dc3-42a6-95c8-31644c721fc7", "c19824cd-0abd-4143-8c69-f769a6e6864c", "Test" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "e1e5ceaa-9f92-44df-816d-41a2913556da", "6d06be29-4993-45b1-9913-77bad0e96843", "test2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "5df42681-cd14-4481-a57f-e1dcbdd99d26", "cb9b9fcd-1948-46ce-b5b5-394c8af61f68", "test3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "1b697c78-0228-47a3-bade-9157b94c0faf", "9b269795-b55b-4b16-9f56-cca6ed382638", "test4" });
        }
    }
}
