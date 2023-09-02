using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_App.Migrations
{
    /// <inheritdoc />
    public partial class orderitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderID",
                table: "OrdersItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "OrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrdersItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "OrdersItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderID",
                table: "OrdersItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderID",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "OrdersItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "OrdersItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderID",
                table: "OrdersItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
