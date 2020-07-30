using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class addednewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATRoleToPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRoleToPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATRoleToPermission_ATRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ATRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATRoleToPermission_RoleId",
                table: "ATRoleToPermission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATPermission");

            migrationBuilder.DropTable(
                name: "ATRoleToPermission");
        }
    }
}
