using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderProcessing.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    PreferredCurrency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5fcd497b-9de7-4a63-b0f4-e63e7b87816f"), "Alice" },
                    { new Guid("933eea88-ab28-4797-9446-3cbd50bdf05f"), "John" },
                    { new Guid("b03d1a25-3837-4082-baa8-f1931ec3ec7f"), "Bob" },
                    { new Guid("c0a4584a-d12d-49b4-9d76-e09edd0b452e"), "Jack" },
                    { new Guid("dafe1ed5-a965-4505-a349-c79c68a760c7"), "Natalie" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrice", "ProductName", "Stock" },
                values: new object[,]
                {
                    { new Guid("03f35600-36e7-44f4-9306-1e80101cb205"), 800m, "Display", 50 },
                    { new Guid("14bd35e6-80ac-492d-a009-7368c364c120"), 700m, "Tablet", 80 },
                    { new Guid("91c0c49b-7ea8-49bd-8122-873e9a5566ec"), 1200m, "Laptop", 100 },
                    { new Guid("f2096cd3-7a0c-41da-b6cb-4f46f6ebccba"), 50m, "Mouse", 40 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsPaid", "OrderDate", "PreferredCurrency", "Status", "Total" },
                values: new object[,]
                {
                    { new Guid("0e8397b4-51fa-4367-8bf5-349b8952fb76"), new Guid("dafe1ed5-a965-4505-a349-c79c68a760c7"), false, new DateTime(2025, 3, 15, 20, 48, 5, 666, DateTimeKind.Utc).AddTicks(2966), "USD", 1, 0m },
                    { new Guid("3d971473-a1ae-49ef-a9c1-4fc2545045a0"), new Guid("b03d1a25-3837-4082-baa8-f1931ec3ec7f"), true, new DateTime(2025, 3, 8, 20, 48, 5, 666, DateTimeKind.Utc).AddTicks(2963), "USD", 1, 0m },
                    { new Guid("85bc0711-e992-4034-97f3-f03f7374efad"), new Guid("5fcd497b-9de7-4a63-b0f4-e63e7b87816f"), true, new DateTime(2025, 3, 13, 20, 48, 5, 666, DateTimeKind.Utc).AddTicks(2952), "USD", 1, 0m },
                    { new Guid("93867435-f157-4b9f-adb5-cf3a4ef8f63d"), new Guid("c0a4584a-d12d-49b4-9d76-e09edd0b452e"), false, new DateTime(2025, 3, 17, 20, 48, 5, 666, DateTimeKind.Utc).AddTicks(2965), "USD", 1, 0m },
                    { new Guid("eb882a41-2fb8-492c-8749-5584c2abdfc2"), new Guid("933eea88-ab28-4797-9446-3cbd50bdf05f"), false, new DateTime(2025, 3, 18, 20, 48, 5, 666, DateTimeKind.Utc).AddTicks(2968), "USD", 1, 0m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("54d1315e-5566-405c-831c-45486ea94088"), new Guid("0e8397b4-51fa-4367-8bf5-349b8952fb76"), 50m, new Guid("f2096cd3-7a0c-41da-b6cb-4f46f6ebccba"), 10 },
                    { new Guid("854b011e-f18e-49d7-9a6f-7054d77d324f"), new Guid("3d971473-a1ae-49ef-a9c1-4fc2545045a0"), 800m, new Guid("03f35600-36e7-44f4-9306-1e80101cb205"), 2 },
                    { new Guid("9844b83e-5115-4286-8569-5d86c9a87db1"), new Guid("93867435-f157-4b9f-adb5-cf3a4ef8f63d"), 1200m, new Guid("91c0c49b-7ea8-49bd-8122-873e9a5566ec"), 3 },
                    { new Guid("abd40453-d7c3-4fed-bd27-5bbae08d3df4"), new Guid("eb882a41-2fb8-492c-8749-5584c2abdfc2"), 800m, new Guid("03f35600-36e7-44f4-9306-1e80101cb205"), 5 },
                    { new Guid("b3e34d68-1a79-4066-bdd1-2eca599067df"), new Guid("85bc0711-e992-4034-97f3-f03f7374efad"), 1200m, new Guid("91c0c49b-7ea8-49bd-8122-873e9a5566ec"), 20 },
                    { new Guid("cb70d6ed-ba07-46f2-b4e8-a15e336ad13f"), new Guid("3d971473-a1ae-49ef-a9c1-4fc2545045a0"), 700m, new Guid("14bd35e6-80ac-492d-a009-7368c364c120"), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
