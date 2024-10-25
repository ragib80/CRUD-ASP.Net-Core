using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetailerAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameVendorsToRetailers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Retailers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers");

            migrationBuilder.RenameTable(
                name: "Retailers",
                newName: "Vendors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");
        }
    }
}
