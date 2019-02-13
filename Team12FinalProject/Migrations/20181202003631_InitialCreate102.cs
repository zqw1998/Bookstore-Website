using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Coupons");

            migrationBuilder.RenameColumn(
                name: "MinimumTotal",
                table: "Coupons",
                newName: "Amount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcurementDate",
                table: "Procurements",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcurementStatus",
                table: "Procurements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardID",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreditCardID",
                table: "Orders",
                column: "CreditCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CreditCards_CreditCardID",
                table: "Orders",
                column: "CreditCardID",
                principalTable: "CreditCards",
                principalColumn: "CreditCardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CreditCards_CreditCardID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreditCardID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProcurementStatus",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "CreditCardID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Coupons",
                newName: "MinimumTotal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcurementDate",
                table: "Procurements",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Coupons",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
