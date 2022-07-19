using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftMake.Migrations
{
    /// <inheritdoc />
    public partial class approve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsApproved",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Product");
        }
    }
}
