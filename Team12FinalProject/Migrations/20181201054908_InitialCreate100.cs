using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookInProgress",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Books",
                newName: "QuantityOnOrder");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcurementDate",
                table: "Procurements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CheckOutStatus",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcurementDate",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "CheckOutStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "QuantityOnOrder",
                table: "Books",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "BookInProgress",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
