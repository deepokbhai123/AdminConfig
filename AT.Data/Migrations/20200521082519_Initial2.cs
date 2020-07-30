using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MenuUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ParentMenuId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Visible = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MenuOrder = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATMenuToUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MenuId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMenuToUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATMenu");

            migrationBuilder.DropTable(
                name: "ATMenuToUser");
        }
    }
}
