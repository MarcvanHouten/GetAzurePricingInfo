using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PricingItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tierMinimumUnits = table.Column<float>(type: "real", nullable: true),
                    retailPrice = table.Column<float>(type: "real", nullable: true),
                    unitPrice = table.Column<float>(type: "real", nullable: true),
                    armRegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    effectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    meterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    skuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    skuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPrimaryMeterRegion = table.Column<bool>(type: "bit", nullable: true),
                    armSkuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reservationTerm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingItems", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricingItems");
        }
    }
}
