using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor.", "iPhone X", 650m, 8.2f },
                    { 2, "Summary ; performanceCore i3 2nd Gen, 2.4 Ghz, 4 GB RAM ; design15.6 inches, 1366 x 768 , 2.7 Kg, 34.3 mm thick ; storage320 GB HDD, SATA, 5400 RPM.", "Lenovo G580", 200m, 6.5f },
                    { 3, "LG's Monitor allows you to maximize work efficiency and bring other practical benefits to your workplace with advanced and unique solutions. Learn more now.", "Monitor LG G6", 440m, 7.7f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 15, 35, 59, 856, DateTimeKind.Local).AddTicks(447), "rejv434@gmail.com", "Vlad", "Tymo" },
                    { 2, new DateTime(2022, 7, 15, 15, 35, 59, 858, DateTimeKind.Local).AddTicks(3598), "super4344@gmail.com", "Bob", "Bobovich" },
                    { 3, new DateTime(2022, 7, 15, 15, 35, 59, 858, DateTimeKind.Local).AddTicks(3633), "hgkkkkff@gmail.com", "Igor", "Rufer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
