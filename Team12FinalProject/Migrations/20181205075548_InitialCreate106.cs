using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InitialCopies",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialCost",
                table: "Books",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "myReviews",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialCopies",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "InitialCost",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "myReviews",
                table: "AspNetUsers");
        }
    }
}
