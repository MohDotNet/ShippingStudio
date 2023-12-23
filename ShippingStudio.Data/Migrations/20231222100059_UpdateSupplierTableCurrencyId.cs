using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierTableCurrencyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "OrderLinesId",
                table: "PackingList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackingList_OrderLinesId",
                table: "PackingList",
                column: "OrderLinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackingList_OrderLines_OrderLinesId",
                table: "PackingList",
                column: "OrderLinesId",
                principalTable: "OrderLines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackingList_OrderLines_OrderLinesId",
                table: "PackingList");

            migrationBuilder.DropIndex(
                name: "IX_PackingList_OrderLinesId",
                table: "PackingList");

            migrationBuilder.DropColumn(
                name: "OrderLinesId",
                table: "PackingList");

            migrationBuilder.AddColumn<int>(
                name: "DefaultCurrency",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
