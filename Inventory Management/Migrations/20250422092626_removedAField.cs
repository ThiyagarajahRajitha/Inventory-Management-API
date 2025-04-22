using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class removedAField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "InventoryItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
