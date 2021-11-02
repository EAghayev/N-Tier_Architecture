using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterApp.Data.Migrations
{
    public partial class FileNameAddedIntoPropertiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Properties",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Properties");
        }
    }
}
