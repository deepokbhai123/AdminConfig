using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class addedforeginkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ATMenuToUser_MenuId",
                table: "ATMenuToUser",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATMenuToUser_ATMenu_MenuId",
                table: "ATMenuToUser",
                column: "MenuId",
                principalTable: "ATMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATMenuToUser_ATMenu_MenuId",
                table: "ATMenuToUser");

            migrationBuilder.DropIndex(
                name: "IX_ATMenuToUser_MenuId",
                table: "ATMenuToUser");
        }
    }
}
