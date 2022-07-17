using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftMake.Migrations
{
    /// <inheritdoc />
    public partial class uploadimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "Product");
        }
    }
}
