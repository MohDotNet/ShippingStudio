using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyFixesOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShipQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityCheckedIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContainerNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContainerType = table.Column<int>(type: "int", nullable: false),
                    PackedDated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasDeparted = table.Column<bool>(type: "bit", nullable: false),
                    HasArrived = table.Column<bool>(type: "bit", nullable: false),
                    ArrivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasDelivered = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostingDone = table.Column<bool>(type: "bit", nullable: false),
                    CostingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackingList_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PackingList_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PackingList_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackingList_OrderId",
                table: "PackingList",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingList_ProductId",
                table: "PackingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingList_SupplierId",
                table: "PackingList",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackingList");
        }
    }
}
