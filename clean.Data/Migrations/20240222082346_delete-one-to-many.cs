using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clean.Data.Migrations
{
    public partial class deleteonetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerId",
                table: "Orders",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
