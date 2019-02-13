using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
