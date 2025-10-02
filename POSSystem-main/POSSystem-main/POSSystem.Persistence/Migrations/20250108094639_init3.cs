using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_InventoryItem_ProductId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Inventory_InventoryId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_InventoryId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "InventoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_InventoryItem_InventoryItemId",
                table: "OrderItem",
                column: "InventoryItemId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_InventoryItem_InventoryItemId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_InventoryItemId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_InventoryId",
                table: "OrderItem",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_InventoryItem_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Inventory_InventoryId",
                table: "OrderItem",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
