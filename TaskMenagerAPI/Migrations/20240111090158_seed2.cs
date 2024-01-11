using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMenagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToDoes_AspNetUsers_UserId",
                table: "UserToDoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToDoes_ToDoes_ToDoId",
                table: "UserToDoes");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToDoes_AspNetUsers_UserId",
                table: "UserToDoes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToDoes_ToDoes_ToDoId",
                table: "UserToDoes",
                column: "ToDoId",
                principalTable: "ToDoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToDoes_AspNetUsers_UserId",
                table: "UserToDoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToDoes_ToDoes_ToDoId",
                table: "UserToDoes");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToDoes_AspNetUsers_UserId",
                table: "UserToDoes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToDoes_ToDoes_ToDoId",
                table: "UserToDoes",
                column: "ToDoId",
                principalTable: "ToDoes",
                principalColumn: "Id");
        }
    }
}
