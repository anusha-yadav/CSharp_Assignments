using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class buynowCheckout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyNowCheckout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddressAddressID = table.Column<int>(type: "int", nullable: false),
                    BuyNowItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyNowCheckout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyNowCheckout_Addresses_ShippingAddressAddressID",
                        column: x => x.ShippingAddressAddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyNowCheckout_BuyNowItems_BuyNowItemId",
                        column: x => x.BuyNowItemId,
                        principalTable: "BuyNowItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyNowCheckout_BuyNowItemId",
                table: "BuyNowCheckout",
                column: "BuyNowItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyNowCheckout_ShippingAddressAddressID",
                table: "BuyNowCheckout",
                column: "ShippingAddressAddressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyNowCheckout");
        }
    }
}
