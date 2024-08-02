using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_Inventory_mgmt.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessRegistrations",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessStateId = table.Column<int>(type: "int", nullable: false),
                    BusinessCityId = table.Column<int>(type: "int", nullable: false),
                    BusinessPincode = table.Column<int>(type: "int", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAltContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessGSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessGSTScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRegistrations", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ProductCategory_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory_CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductCategory_UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryMasters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessRegistrations");

            migrationBuilder.DropTable(
                name: "ProductCategoryMasters");
        }
    }
}
