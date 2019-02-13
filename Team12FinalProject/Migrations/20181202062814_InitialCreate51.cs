using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Procurements",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Procurements");
        }
    }
}
