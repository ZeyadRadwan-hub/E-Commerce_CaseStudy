using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class Version_Zero_One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToatalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices", "Electronics" },
                    { 2, "Programming and technical books", "Books" },
                    { 3, "Computer accessories", "Accessories" },
                    { 4, "Gaming devices and accessories", "Gaming" },
                    { 5, "Internal computer components", "Computer Components" },
                    { 6, "Office and desk products", "Office Supplies" },
                    { 7, "Appliances for home use", "Home Appliances" },
                    { 8, "Mobile phone accessories", "Mobile Accessories" },
                    { 9, "Networking devices", "Networking" },
                    { 10, "Storage devices", "Storage" },
                    { 11, "Audio equipment", "Audio" },
                    { 12, "Photography equipment", "Photography" },
                    { 13, "Software products", "Software" },
                    { 14, "Smart home devices", "Smart Home" },
                    { 15, "Wearable technology", "Wearables" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "ahmed@example.com", "Ahmed Hassan", "Test123!", "Customer" },
                    { 2, "mona@example.com", "Mona Ali", "Test123!", "Customer" },
                    { 3, "omar@example.com", "Omar Khaled", "Test123!", "Customer" },
                    { 4, "sara@example.com", "Sara Mohamed", "Test123!", "Customer" },
                    { 5, "youssef@example.com", "Youssef Ali", "Test123!", "Customer" },
                    { 6, "nour@example.com", "Nour Ahmed", "Test123!", "Customer" },
                    { 7, "karim@example.com", "Karim Samir", "Test123!", "Customer" },
                    { 8, "malak@example.com", "Malak Hany", "Test123!", "Customer" },
                    { 9, "adam@example.com", "Adam Tarek", "Test123!", "Customer" },
                    { 10, "jana@example.com", "Jana Mostafa", "Test123!", "Customer" },
                    { 11, "ali@example.com", "Ali Hassan", "Test123!", "Customer" },
                    { 12, "farida@example.com", "Farida Amr", "Test123!", "Customer" },
                    { 13, "seif@example.com", "Seif Ashraf", "Test123!", "Customer" },
                    { 14, "laila@example.com", "Laila Adel", "Test123!", "Customer" },
                    { 15, "admin@example.com", "Store Admin", "Test123!", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderStatus", "ToatalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 900m, 1 },
                    { 2, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1200m, 2 },
                    { 3, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 1050m, 3 },
                    { 4, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 650m, 4 },
                    { 5, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 1800m, 5 },
                    { 6, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1500m, 6 },
                    { 7, new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 4200m, 7 },
                    { 8, new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 250m, 8 },
                    { 9, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 1600m, 9 },
                    { 10, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 1600m, 10 },
                    { 11, new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 1650m, 11 },
                    { 12, new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 2300m, 12 },
                    { 13, new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 3200m, 13 },
                    { 14, new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 2200m, 14 },
                    { 15, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 1200m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Wireless computer mouse", "Wireless Mouse", 450m, 25 },
                    { 2, 1, "Over-ear headphones", "Headphones", 1200m, 12 },
                    { 3, 2, "Introduction to C++ programming", "C++ Fundamentals", 350m, 30 },
                    { 4, 2, "Guide to ASP.NET Core development", "ASP.NET Core Guide", 650m, 18 },
                    { 5, 1, "Mechanical USB keyboard", "Mechanical Keyboard", 1800m, 10 },
                    { 6, 3, "Multiport USB-C hub", "USB-C Hub", 750m, 20 },
                    { 7, 1, "24-inch computer monitor", "Monitor 24 inch", 4200m, 8 },
                    { 8, 8, "Fast mobile phone charger", "Phone Charger", 250m, 40 },
                    { 9, 2, "Database programming guide", "SQL Server Guide", 800m, 15 },
                    { 10, 4, "Wireless gaming controller", "Gaming Controller", 1600m, 14 },
                    { 11, 6, "Adjustable laptop stand", "Laptop Stand", 550m, 22 },
                    { 12, 11, "USB recording microphone", "Microphone", 2300m, 9 },
                    { 13, 10, "One terabyte solid state drive", "SSD 1TB", 3200m, 11 },
                    { 14, 11, "Portable Bluetooth speaker", "Bluetooth Speaker", 1100m, 16 },
                    { 15, 9, "USB Ethernet network adapter", "Ethernet Adapter", 300m, 28 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 450m },
                    { 2, 2, 2, 1, 1200m },
                    { 3, 3, 3, 3, 350m },
                    { 4, 4, 4, 1, 650m },
                    { 5, 5, 5, 1, 1800m },
                    { 6, 6, 6, 2, 750m },
                    { 7, 7, 7, 1, 4200m },
                    { 8, 8, 8, 1, 250m },
                    { 9, 9, 9, 2, 800m },
                    { 10, 10, 10, 1, 1600m },
                    { 11, 11, 11, 3, 550m },
                    { 12, 12, 12, 1, 2300m },
                    { 13, 13, 13, 1, 3200m },
                    { 14, 14, 14, 2, 1100m },
                    { 15, 15, 15, 4, 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
