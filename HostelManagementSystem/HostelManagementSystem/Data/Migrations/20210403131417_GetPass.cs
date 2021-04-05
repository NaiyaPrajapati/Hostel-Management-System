using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostelManagementSystem.Data.Migrations
{
    public partial class GetPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetPass",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Dept_date = table.Column<DateTime>(nullable: false),
                    Arrival_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPass", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetPass");
        }
    }
}
