using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddDescriptionToTheProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A T-shirt, or tee, is a style of fabric shirt named after the T shape of its body and sleeves.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 39, 11, 369, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 39, 11, 372, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 39, 11, 372, DateTimeKind.Local).AddTicks(1874));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 36, 56, 975, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 36, 56, 978, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2022, 7, 22, 15, 36, 56, 978, DateTimeKind.Local).AddTicks(6352));
        }
    }
}
