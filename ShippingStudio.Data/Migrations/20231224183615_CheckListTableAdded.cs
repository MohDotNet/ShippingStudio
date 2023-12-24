using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckListTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Status",
            //    table: "OrderLines");

            //migrationBuilder.InsertData(
            //    table: "Products",
            //    columns: new[] { "Id", "Description", "IsDisabled" },
            //    values: new object[] { 1, "Admin Test Product", false });

            //migrationBuilder.InsertData(
            //    table: "ShippingPorts",
            //    columns: new[] { "Id", "Country", "IsDisabled", "Port" },
            //    values: new object[] { 1, "South Africa", false, "Cape Town" });

            //migrationBuilder.InsertData(
            //    table: "Suppliers",
            //    columns: new[] { "Id", "Company", "ContactPerson", "CurrencyId", "Email", "ShippingPortId", "TelephoneNumebr" },
            //    values: new object[] { 1, "Admin Company Ltd.", "Mohamed", 1, "Ameerodien@outlook.com", 1, "0837985535" });
        }

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DeleteData(
        //        table: "Products",
        //        keyColumn: "Id",
        //        keyValue: 1);

        //    migrationBuilder.DeleteData(
        //        table: "Suppliers",
        //        keyColumn: "Id",
        //        keyValue: 1);

        //    migrationBuilder.DeleteData(
        //        table: "ShippingPorts",
        //        keyColumn: "Id",
        //        keyValue: 1);

        //    migrationBuilder.AddColumn<int>(
        //        name: "Status",
        //        table: "OrderLines",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);
        //}
    }
}
