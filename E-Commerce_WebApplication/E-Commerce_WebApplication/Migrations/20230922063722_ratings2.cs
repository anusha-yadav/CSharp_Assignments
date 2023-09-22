using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ratings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRated",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "HasRated",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRated",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "HasRated",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
