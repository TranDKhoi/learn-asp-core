using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnASP.Migrations
{
    public partial class refactorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 14, 15, 37, 15, 933, DateTimeKind.Utc).AddTicks(3220)),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    totalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bill_User_buyerId",
                        column: x => x.buyerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    billId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => new { x.billId, x.productId });
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_billId",
                        column: x => x.billId,
                        principalTable: "Bill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetail_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_buyerId",
                table: "Bill",
                column: "buyerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_productId",
                table: "BillDetail",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
