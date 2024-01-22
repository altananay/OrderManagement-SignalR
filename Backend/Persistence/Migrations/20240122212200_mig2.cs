using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BasketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductCount",
                table: "Baskets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BasketDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketDetail_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetail_BasketId",
                table: "BasketDetail",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetail_ProductId",
                table: "BasketDetail",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDetail");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Baskets");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketId",
                table: "Products",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
