using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "6f88fc58-0f43-4988-a37d-cce71c8dd4fc", "User", "Michal12op.pl", false, true, false, null, null, null, null, null, false, "576355c1-64a7-4185-9d46-c3a980da60f6", false, "Test1" },
                    { "2", 0, "b3aee494-7e0d-4a67-8c52-3e934896aa2b", "User", "Michal31vp.pl", false, true, false, null, null, null, null, null, false, "16b64bdf-7592-4d19-8e4a-11210013d096", false, "test2" },
                    { "3", 0, "b56a46e6-8d8f-4ef9-b30f-46eb4acc43a0", "User", "Pioterk@ds.pl", false, true, false, null, null, null, null, null, false, "a21dd19e-58c7-4c03-9352-d26dde7713ee", false, "test3" },
                    { "4", 0, "a2e24b2c-1dc7-4c07-ae56-aeaeded39e38", "User", "test@gmail.com", false, true, false, null, null, null, null, null, false, "b46da866-e573-499c-b886-8cf741df7dfd", false, "test4" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
