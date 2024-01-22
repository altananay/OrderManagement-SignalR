using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetail_Baskets_BasketId",
                table: "BasketDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetail_Products_ProductId",
                table: "BasketDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketDetail",
                table: "BasketDetail");

            migrationBuilder.RenameTable(
                name: "BasketDetail",
                newName: "BasketDetails");

            migrationBuilder.RenameIndex(
                name: "IX_BasketDetail_ProductId",
                table: "BasketDetails",
                newName: "IX_BasketDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketDetail_BasketId",
                table: "BasketDetails",
                newName: "IX_BasketDetails_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketDetails",
                table: "BasketDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_Baskets_BasketId",
                table: "BasketDetails",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_Products_ProductId",
                table: "BasketDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_Baskets_BasketId",
                table: "BasketDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_Products_ProductId",
                table: "BasketDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketDetails",
                table: "BasketDetails");

            migrationBuilder.RenameTable(
                name: "BasketDetails",
                newName: "BasketDetail");

            migrationBuilder.RenameIndex(
                name: "IX_BasketDetails_ProductId",
                table: "BasketDetail",
                newName: "IX_BasketDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketDetails_BasketId",
                table: "BasketDetail",
                newName: "IX_BasketDetail_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketDetail",
                table: "BasketDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetail_Baskets_BasketId",
                table: "BasketDetail",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetail_Products_ProductId",
                table: "BasketDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
