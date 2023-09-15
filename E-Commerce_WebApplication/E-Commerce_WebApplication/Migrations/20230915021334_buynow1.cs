using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class buynow1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyNowItems_Products_productID",
                table: "BuyNowItems");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "BuyNowItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "BuyNowItems",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_BuyNowItems_productID",
                table: "BuyNowItems",
                newName: "IX_BuyNowItems_ProductID");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "BuyNowItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "BuyNowItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyNowItems_Products_ProductID",
                table: "BuyNowItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyNowItems_Products_ProductID",
                table: "BuyNowItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "BuyNowItems");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "BuyNowItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BuyNowItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "BuyNowItems",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "IX_BuyNowItems_ProductID",
                table: "BuyNowItems",
                newName: "IX_BuyNowItems_productID");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyNowItems_Products_productID",
                table: "BuyNowItems",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
