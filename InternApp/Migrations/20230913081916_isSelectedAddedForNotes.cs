using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternApp.Migrations
{
    public partial class isSelectedAddedForNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Notes");
        }
    }
}
