using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "b14a7ffe-7dc3-42a6-95c8-31644c721fc7", "Michal12op.pl", "c19824cd-0abd-4143-8c69-f769a6e6864c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "e1e5ceaa-9f92-44df-816d-41a2913556da", "Michal31vp.pl", "6d06be29-4993-45b1-9913-77bad0e96843" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "5df42681-cd14-4481-a57f-e1dcbdd99d26", "Pioterk@ds.pl", "cb9b9fcd-1948-46ce-b5b5-394c8af61f68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "1b697c78-0228-47a3-bade-9157b94c0faf", "test@gmail.com", "9b269795-b55b-4b16-9f56-cca6ed382638" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "61bfbddf-f0d8-4d5e-bfe7-c9d1d136a316", null, "4d6aa058-9885-44d3-90b6-a9bfced26951" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "76377f27-efbe-4643-9aa5-ee5bf1b095b4", null, "a19ad917-26e7-461e-8954-1f4ece74713a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "f38df26a-a5cb-4b8b-ba60-aa7dbb499c0e", null, "1b781e24-284f-436c-9fbc-328864590661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "12c2a3d2-020d-4132-9482-9949c67fcbb7", null, "b166d10f-6f12-473b-b2ad-8491990d0786" });
        }
    }
}
