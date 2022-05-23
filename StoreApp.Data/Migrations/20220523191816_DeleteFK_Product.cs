using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Data.Migrations
{
    public partial class DeleteFK_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversionRates_Products_ProductId",
                table: "ConversionRates");

            migrationBuilder.DropIndex(
                name: "IX_ConversionRates_ProductId",
                table: "ConversionRates");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ConversionRates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ConversionRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConversionRates_ProductId",
                table: "ConversionRates",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversionRates_Products_ProductId",
                table: "ConversionRates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
