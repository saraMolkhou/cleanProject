using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clean.Data.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderproduct",
                columns: table => new
                {
                    ordersorderNum = table.Column<int>(type: "int", nullable: false),
                    productsBarcode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderproduct", x => new { x.ordersorderNum, x.productsBarcode });
                    table.ForeignKey(
                        name: "FK_orderproduct_Orders_ordersorderNum",
                        column: x => x.ordersorderNum,
                        principalTable: "Orders",
                        principalColumn: "orderNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderproduct_Products_productsBarcode",
                        column: x => x.productsBarcode,
                        principalTable: "Products",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderproduct_productsBarcode",
                table: "orderproduct",
                column: "productsBarcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderproduct");
        }
    }
}
