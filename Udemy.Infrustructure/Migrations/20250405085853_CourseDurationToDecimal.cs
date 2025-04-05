using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CourseDurationToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "453f648a-42ae-4210-8743-95ba05666ebf", new DateTime(2025, 4, 5, 10, 58, 53, 406, DateTimeKind.Local).AddTicks(2075), "AQAAAAIAAYagAAAAECj35H0Jq1Hk4RdvG2vAdYbHY9wyj2URKsi24sLJG8RnAIeZwkJ6OPEl9qw0tgC0Bw==", "bf334339-6ef2-414e-b3e4-d50a51c4ca16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dd42961-7ff3-4194-b153-d59b716fb359", new DateTime(2025, 4, 5, 10, 58, 53, 442, DateTimeKind.Local).AddTicks(9417), "AQAAAAIAAYagAAAAEFGzQgrtBxR6fkCO28JEYNHud/v7ZjPFICNGzKhrN7jAnox/qxz8j1bAA79R1bo7Vw==", "fb86bdfd-2804-4897-9c4a-47492272aafa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc89b2fe-1f81-4478-a7e5-6781425b110c", new DateTime(2025, 4, 5, 10, 58, 53, 479, DateTimeKind.Local).AddTicks(7000), "AQAAAAIAAYagAAAAEMInA2fTMomaMr3jHCVwBecU1uKHzukWtaYnbWRCj2yLPdFmWq4nvipIoy1CCOAOsg==", "2ceabe2e-89be-4d20-98df-0fb605e34f3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e98ecc46-9929-4619-8178-48d9bb09416d", new DateTime(2025, 4, 2, 2, 42, 43, 712, DateTimeKind.Local).AddTicks(1509), "AQAAAAIAAYagAAAAELBFbuD14Bf+Prynqv/T7R/H5MbXh9s9MQTIQi9AG8P9d7+w3YZNcgcMcQMs4Df0EA==", "bf5a85e7-bc34-423b-921a-bb8a06b599b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978acd43-df3f-4d6f-a7e4-65e1f72c139d", new DateTime(2025, 4, 2, 2, 42, 43, 752, DateTimeKind.Local).AddTicks(8655), "AQAAAAIAAYagAAAAEPc/mKbYJRazOHTU0A4CqkrazuVwrajJoGUQZKYEr61qUkT74O+Sh6gVTNPUAkrJEQ==", "d97e5410-0095-4103-a06a-eb14986b79a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a11288-a6be-4b0c-8d38-d9d87e053ed6", new DateTime(2025, 4, 2, 2, 42, 43, 794, DateTimeKind.Local).AddTicks(2120), "AQAAAAIAAYagAAAAEAIkqTp4LA1lD0Jgu7AWY293M60GIDwQKpYmqYc9i3mNzeJjxCEdthodBP+lh8v2AQ==", "b37c8bad-cc24-4dc4-b61e-00a11795ca15" });
        }
    }
}
