using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team12FinalProject.Migrations
{
    public partial class InitialCreate333k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Shipping",
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

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    ShippingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShippingBase = table.Column<decimal>(nullable: false),
                    ShippingAddition = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.ShippingID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Shippings");

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
                name: "Shipping",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
