using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostelManagementSystem.Data.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    BreakFastItem1 = table.Column<string>(nullable: true),
                    BreakFastItem2 = table.Column<string>(nullable: true),
                    BreakFastItem3 = table.Column<string>(nullable: true),
                    LunchItem1 = table.Column<string>(nullable: true),
                    LunchItem2 = table.Column<string>(nullable: true),
                    LunchItem3 = table.Column<string>(nullable: true),
                    LunchItem4 = table.Column<string>(nullable: true),
                    LunchItem5 = table.Column<string>(nullable: true),
                    LunchItem6 = table.Column<string>(nullable: true),
                    DinnerItem1 = table.Column<string>(nullable: true),
                    DinnerItem2 = table.Column<string>(nullable: true),
                    DinnerItem3 = table.Column<string>(nullable: true),
                    DinnerItem4 = table.Column<string>(nullable: true),
                    DinnerItem5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
