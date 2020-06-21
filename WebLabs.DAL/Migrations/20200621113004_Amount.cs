using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLabs.DAL.Migrations
{
    public partial class Amount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Tehniks");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Tehniks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Tehniks");

            migrationBuilder.AddColumn<int>(
                name: "ArendaDays",
                table: "Tehniks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
