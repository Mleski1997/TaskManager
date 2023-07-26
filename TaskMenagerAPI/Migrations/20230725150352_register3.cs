using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class register3 : Migration
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
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserIsActive", "UserName" },
                values: new object[,]
                {
                    { "84d85e76-a987-4b86-8de0-40ae75724922", 0, "c49f8e26-daef-4192-affa-2b808c582fba", "User", null, false, "Test", "Test", false, null, null, null, null, null, false, "338b71b8-a09f-4129-b55c-e74e467d0a90", false, false, null },
                    { "dbec1502-d0c3-44a4-a866-18db91b37fe2", 0, "175fbeaf-de97-464a-9b84-f276bf08d318", "User", null, false, "Test2", "Test2", false, null, null, null, null, null, false, "ebe58338-317b-4372-9bf4-712c6b9acc5a", false, false, null }
                });

            migrationBuilder.UpdateData(
                table: "ToDoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d85e76-a987-4b86-8de0-40ae75724922");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbec1502-d0c3-44a4-a866-18db91b37fe2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserIsActive", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "bdf22dd7-b7bb-4c9e-b8c4-ff601a33656b", "User", null, false, "Test", "Test", false, null, null, null, null, null, false, "5988d43c-6a44-4c28-b40f-cf307523c1de", false, false, null },
                    { "2", 0, "8fbe60ed-2576-49b2-9ec9-3ad80efd3bf6", "User", null, false, "Test2", "Test2", false, null, null, null, null, null, false, "26af1cd2-b138-4eea-bcbf-beea77c216b1", false, false, null }
                });

            migrationBuilder.UpdateData(
                table: "ToDoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "1");
        }
    }
}
