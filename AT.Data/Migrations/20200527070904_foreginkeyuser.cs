using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class foreginkeyuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ATMenuToUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ATMenuToUser_UserId",
                table: "ATMenuToUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATMenuToUser_ATUser_UserId",
                table: "ATMenuToUser",
                column: "UserId",
                principalTable: "ATUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATMenuToUser_ATUser_UserId",
                table: "ATMenuToUser");

            migrationBuilder.DropIndex(
                name: "IX_ATMenuToUser_UserId",
                table: "ATMenuToUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ATMenuToUser",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
