using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileStatusesId",
                table: "Filing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Incoterms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InctermName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IncotermSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incoterms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InternalOrderReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierOrderReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PortOfOrigin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PortDestination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IncotermId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Incoterms_IncotermId",
                        column: x => x.IncotermId,
                        principalTable: "Incoterms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    LineTotal = table.Column<double>(type: "float", nullable: false),
                    TotalShipped = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LineStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_LineStatuses_LineStatusId",
                        column: x => x.LineStatusId,
                        principalTable: "LineStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CurrencyCode", "CurrencyName", "IsDisabled" },
                values: new object[,]
                {
                    { 1, "ZAR", "South African Rand", false },
                    { 2, "USD", "United States Dollar", false }
                });

            migrationBuilder.InsertData(
                table: "FileStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Open" },
                    { 3, "OnHold" },
                    { 4, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Incoterms",
                columns: new[] { "Id", "IncotermSymbol", "InctermName" },
                values: new object[,]
                {
                    { 1, "CIF", "Cost Insurance Freight" },
                    { 2, "CFR", "Carriage Frieght" },
                    { 3, "FOB", "Free On Board" },
                    { 4, "FAS", "Free Alongside Ship" },
                    { 5, "DDP", "Delviered Duty Paid" },
                    { 6, "CIP", "Carriage Insurance Paid To" }
                });

            migrationBuilder.InsertData(
                table: "LineStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "InProgress" },
                    { 3, "Complete" },
                    { 4, "OnHold" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "In Progress" },
                    { 3, "Complete" },
                    { 4, "Onhold" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filing_FileStatusesId",
                table: "Filing",
                column: "FileStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LineStatusId",
                table: "OrderLines",
                column: "LineStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrencyId",
                table: "Orders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IncotermId",
                table: "Orders",
                column: "IncotermId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierId",
                table: "Orders",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filing_FileStatuses_FileStatusesId",
                table: "Filing",
                column: "FileStatusesId",
                principalTable: "FileStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filing_FileStatuses_FileStatusesId",
                table: "Filing");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "LineStatuses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Incoterms");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Filing_FileStatusesId",
                table: "Filing");

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "FileStatusesId",
                table: "Filing");
        }
    }
}
