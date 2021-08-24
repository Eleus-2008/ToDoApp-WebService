using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RenameEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ToDoLists_ToDoListId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_AspNetUsers_UserId",
                table: "ToDoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RepeatingConditions_SerializedDaysOfWeek",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "ToDoLists",
                newName: "Todolists");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TodolistItems");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoLists_UserId",
                table: "Todolists",
                newName: "IX_Todolists_UserId");

            migrationBuilder.RenameColumn(
                name: "ToDoListId",
                table: "TodolistItems",
                newName: "TodolistId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ToDoListId",
                table: "TodolistItems",
                newName: "IX_TodolistItems_TodolistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todolists",
                table: "Todolists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodolistItems",
                table: "TodolistItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodolistItems_Todolists_TodolistId",
                table: "TodolistItems",
                column: "TodolistId",
                principalTable: "Todolists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todolists_AspNetUsers_UserId",
                table: "Todolists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodolistItems_Todolists_TodolistId",
                table: "TodolistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Todolists_AspNetUsers_UserId",
                table: "Todolists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todolists",
                table: "Todolists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodolistItems",
                table: "TodolistItems");

            migrationBuilder.RenameTable(
                name: "Todolists",
                newName: "ToDoLists");

            migrationBuilder.RenameTable(
                name: "TodolistItems",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Todolists_UserId",
                table: "ToDoLists",
                newName: "IX_ToDoLists_UserId");

            migrationBuilder.RenameColumn(
                name: "TodolistId",
                table: "Tasks",
                newName: "ToDoListId");

            migrationBuilder.RenameIndex(
                name: "IX_TodolistItems_TodolistId",
                table: "Tasks",
                newName: "IX_Tasks_ToDoListId");

            migrationBuilder.AddColumn<string>(
                name: "RepeatingConditions_SerializedDaysOfWeek",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ToDoLists_ToDoListId",
                table: "Tasks",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_AspNetUsers_UserId",
                table: "ToDoLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
