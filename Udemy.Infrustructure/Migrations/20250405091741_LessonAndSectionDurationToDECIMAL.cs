using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LessonAndSectionDurationToDECIMAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Sections",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Lessons",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd408e24-9a96-435b-a089-aaaa34666cf5", new DateTime(2025, 4, 5, 11, 17, 41, 137, DateTimeKind.Local).AddTicks(7538), "AQAAAAIAAYagAAAAEH+/SI88UEGlRMVewBGHcuNw4O3GXjFiZrTgF1hk9YxBrHYS1GEemgwmiJMiqO7fTA==", "ce225559-737f-49a4-8a03-f6a5be7a7ea1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35dea37c-2341-4c85-ac91-3d2b9a4d6379", new DateTime(2025, 4, 5, 11, 17, 41, 176, DateTimeKind.Local).AddTicks(1959), "AQAAAAIAAYagAAAAEHVFW/EH8tl12MdJsXAPhU7Vkv2w+ffxrwlNxIZO/2k8X8HTtNry/9JxH0dx88cJPQ==", "472ec43a-f580-4c4d-8d31-fc34331bd368" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97000016-5666-4da7-9815-bf28038a0a95", new DateTime(2025, 4, 5, 11, 17, 41, 212, DateTimeKind.Local).AddTicks(9768), "AQAAAAIAAYagAAAAEBqemBSQhD9rXAvjbMJOoO787mJ1dB+/GPE24eyAWJ3iIBh0d/GUvF2HBbI3Vu+Iag==", "9231be1b-a644-4b82-84a9-bdc02a0ee062" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Sections",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Lessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
