using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixCurrentPriceCompoutedFormula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Price] - [Price] * ([Discount]/100)",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[Price] * ([Discount]/100)",
                oldStored: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dc140cc-c1d8-4108-9c7b-c98cbe332d74", new DateTime(2025, 3, 13, 0, 40, 18, 12, DateTimeKind.Local).AddTicks(8096), "AQAAAAIAAYagAAAAEG2h70G1HPNV2JsADAGwrE1qhOjnxnBfvc0fw7/t1QG3DDeditoB1QXUt9f9CAwiiw==", "d8cd9c35-5d9e-469e-a3d1-e1794c1f9e64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bce17d3f-68aa-42c6-b817-005366a2491f", new DateTime(2025, 3, 13, 0, 40, 18, 105, DateTimeKind.Local).AddTicks(4996), "AQAAAAIAAYagAAAAEJMxa1BtVy+T09uj7pfdrFc/lInzgePm/T9M9rPt1k1ckEwryikwBGPY4ejtuZyNdA==", "d23a452a-8513-4320-a8a4-8e42640621a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4e729eb-0b9d-4cdf-8f25-7b613ad2ba55", new DateTime(2025, 3, 13, 0, 40, 18, 197, DateTimeKind.Local).AddTicks(2945), "AQAAAAIAAYagAAAAEKBUoRbI9bxnpNdDlQATCUD5DOM/Sp00CwIxwopBlZ/lgZMkQ7izxlYfx0XVJedmaQ==", "cf909af8-c018-455d-befa-dbe589eb626e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Price] * ([Discount]/100)",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[Price] - [Price] * ([Discount]/100)",
                oldStored: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c3df827-a0b9-40d7-9bea-1c3ed6f51528", new DateTime(2025, 3, 12, 18, 28, 9, 395, DateTimeKind.Local).AddTicks(3980), "AQAAAAIAAYagAAAAEBWpB1Tvz7ph8kuyWb4brzUQZLcrEiXlYJtfMHUv5JBQGmSknyV1B7fPQUo1k3S1Ww==", "76dc839c-0095-458d-a5dc-9fde92cb8a0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a51fbaef-e7b8-48b1-a14f-1bed4995c88a", new DateTime(2025, 3, 12, 18, 28, 9, 489, DateTimeKind.Local).AddTicks(5210), "AQAAAAIAAYagAAAAEBXh1YcWd/2vw2ME+1ZBzUI7gtqZAyIbk2Fp/BUVGD7euOKSH6EQdMB/tJ0yEP3vwA==", "63b84041-6779-400f-90ec-84665177453d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c2ec0a5-07cc-4b8c-8018-5a6c8e5a62a5", new DateTime(2025, 3, 12, 18, 28, 9, 583, DateTimeKind.Local).AddTicks(6063), "AQAAAAIAAYagAAAAEGICxeleKBzqukH7bgYFAOCCrNbTd2vk2BkhX4KulFNWfY3eBGCJaapWotlt+dQL1g==", "0cc49928-910e-4b3b-a922-05c00534b98e" });
        }
    }
}
