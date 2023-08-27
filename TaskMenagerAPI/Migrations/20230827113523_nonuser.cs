using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class nonuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "eef803b0-85b3-4682-902c-a6a34010cf7e", "User", "Michal12op.pl", false, true, false, null, null, null, null, null, false, "2495ced9-2078-42aa-9b11-7c9722aa1e2f", false, "Test1" },
                    { "2", 0, "684b0b3b-74b1-47fc-8396-abdc8188d94e", "User", "Michal31vp.pl", false, true, false, null, null, null, null, null, false, "db531363-19e7-419b-afdf-a6316f9e5c80", false, "test2" },
                    { "3", 0, "f29dc870-a6aa-4e23-9da5-0fb1434d8214", "User", "Pioterk@ds.pl", false, true, false, null, null, null, null, null, false, "50c60b96-818d-4f4a-8f42-110365006c26", false, "test3" },
                    { "4", 0, "0fb50468-70ee-4b25-94ad-2a668d5b0150", "User", "test@gmail.com", false, true, false, null, null, null, null, null, false, "ba89a4b7-0126-46ef-a09d-03a05ef13ef0", false, "test4" }
                });

            migrationBuilder.InsertData(
                table: "ToDoes",
                columns: new[] { "Id", "Description", "DueDate", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Test", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Test", "2" },
                    { 2, "Test2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Test2", "2" }
                });
        }
    }
}
