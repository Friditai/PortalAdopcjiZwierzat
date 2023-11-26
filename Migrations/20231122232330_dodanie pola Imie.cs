using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalAdopcjiZwierzat.Migrations
{
    public partial class dodaniepolaImie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Zwierze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Zwierze");
        }
    }
}
