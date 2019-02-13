using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate300 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discontinued",
                table: "Books");
        }
    }
}
