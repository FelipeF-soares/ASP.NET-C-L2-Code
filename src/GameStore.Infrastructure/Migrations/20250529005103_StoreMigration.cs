using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensions_Width = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Height = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Depth = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Volume = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Width = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Height = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Depth = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Volume = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Dimensions_Width = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Height = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Depth = table.Column<int>(type: "int", nullable: true),
                    Dimensions_Volume = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Caixa 1" },
                    { 2, "Caixa 2" },
                    { 3, "Caixa 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BoxId",
                table: "Orders",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Boxes");
        }
    }
}
