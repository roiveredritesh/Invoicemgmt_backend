using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_Inventory_mgmt.Migrations
{
    /// <inheritdoc />
    public partial class businessregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessContactNo",
                table: "BusinessRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessContactNo",
                table: "BusinessRegistrations");
        }
    }
}
