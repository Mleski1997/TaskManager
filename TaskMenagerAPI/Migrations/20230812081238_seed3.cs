using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "eef803b0-85b3-4682-902c-a6a34010cf7e", "2495ced9-2078-42aa-9b11-7c9722aa1e2f", "Test1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "684b0b3b-74b1-47fc-8396-abdc8188d94e", "db531363-19e7-419b-afdf-a6316f9e5c80", "test2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "f29dc870-a6aa-4e23-9da5-0fb1434d8214", "50c60b96-818d-4f4a-8f42-110365006c26", "test3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "0fb50468-70ee-4b25-94ad-2a668d5b0150", "ba89a4b7-0126-46ef-a09d-03a05ef13ef0", "test4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "12b0d1ff-7fd4-42bb-9a5c-e9a6b74e42b1", "9ad8e7f3-42f1-4da6-847d-6a2a6f78c4ec", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "6a1f586e-6174-43f7-8f03-8830a2d0036a", "e8365a2c-7e72-4bbc-a4f5-79f56236e48d", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "7bd0a8c2-4d90-42ac-a606-6d96d99a1742", "8c69d213-d53d-4a58-a9fc-77c3bc111b8a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "09c843d5-5943-4917-86e5-bd444ac6f8d3", "2744a73a-a2f0-48db-9f9e-03d4d848a702", null });
        }
    }
}
