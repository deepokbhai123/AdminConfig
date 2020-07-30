using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class Addednewerrorlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogSystem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorRaisedClass = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ErrorRaisedMethod = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogSystem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogSystem");
        }
    }
}
