using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CouponApplied",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingApplied",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingID",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmt",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingAmt",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAmt",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "CouponApplied",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShippingApplied",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShippingID",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingID",
                table: "Orders",
                column: "ShippingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "Shippings",
                principalColumn: "ShippingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
