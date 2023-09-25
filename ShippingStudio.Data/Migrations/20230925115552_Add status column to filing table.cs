using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addstatuscolumntofilingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileStatus",
                table: "Filing",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileStatus",
                table: "Filing");
        }
    }
}
