using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalAdopcjiZwierzat.Migrations
{
    public partial class dodaniepolaPlec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plec",
                table: "Zwierze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plec",
                table: "Zwierze");
        }
    }
}
