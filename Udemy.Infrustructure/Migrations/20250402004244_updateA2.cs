using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CourseRequirements",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CourseGoals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e98ecc46-9929-4619-8178-48d9bb09416d", new DateTime(2025, 4, 2, 2, 42, 43, 712, DateTimeKind.Local).AddTicks(1509), false, "AQAAAAIAAYagAAAAELBFbuD14Bf+Prynqv/T7R/H5MbXh9s9MQTIQi9AG8P9d7+w3YZNcgcMcQMs4Df0EA==", "bf5a85e7-bc34-423b-921a-bb8a06b599b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978acd43-df3f-4d6f-a7e4-65e1f72c139d", new DateTime(2025, 4, 2, 2, 42, 43, 752, DateTimeKind.Local).AddTicks(8655), false, "AQAAAAIAAYagAAAAEPc/mKbYJRazOHTU0A4CqkrazuVwrajJoGUQZKYEr61qUkT74O+Sh6gVTNPUAkrJEQ==", "d97e5410-0095-4103-a06a-eb14986b79a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a11288-a6be-4b0c-8d38-d9d87e053ed6", new DateTime(2025, 4, 2, 2, 42, 43, 794, DateTimeKind.Local).AddTicks(2120), false, "AQAAAAIAAYagAAAAEAIkqTp4LA1lD0Jgu7AWY293M60GIDwQKpYmqYc9i3mNzeJjxCEdthodBP+lh8v2AQ==", "b37c8bad-cc24-4dc4-b61e-00a11795ca15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Enrollments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CourseRequirements",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CourseGoals",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8fed8d-5b3e-449a-9786-2c2507a2176f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AQAAAAIAAYagAAAAELptlHr87XOMNoUOJ6H28Y9Y5c6NqvZlWF/bRw9599tRCWK8f0TrZ8N/bBki96qA3w==", "d59f451d-b9a2-4533-8b5f-ab00240ec1cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9eda82e-332f-4c92-9326-cc2044b76e9b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AQAAAAIAAYagAAAAEBThkFxhSwiCmSD3glkmsvGjtEoYzYMZoVXnW8kQtFOqb7lOcO9nMNihbWbsD/Ziqw==", "5afa2791-5ba6-496e-bd26-0658089cc99c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bdffd32-3985-4d5c-9ad9-4d1dcdb46570", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AQAAAAIAAYagAAAAEJnuytiMsa4IfZtbl3tBVPPtnceUGkiIMw544KG5g3xh06ygipSZWgn2As1u+ATl/g==", "8d49504d-ea9d-44a9-b707-50f7bd1d96f7" });
        }
    }
}
