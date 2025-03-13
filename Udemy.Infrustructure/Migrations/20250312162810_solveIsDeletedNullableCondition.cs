using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class solveIsDeletedNullableCondition : Migration
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

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "CourseRequirements",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c3df827-a0b9-40d7-9bea-1c3ed6f51528", new DateTime(2025, 3, 12, 18, 28, 9, 395, DateTimeKind.Local).AddTicks(3980), false, "AQAAAAIAAYagAAAAEBWpB1Tvz7ph8kuyWb4brzUQZLcrEiXlYJtfMHUv5JBQGmSknyV1B7fPQUo1k3S1Ww==", "76dc839c-0095-458d-a5dc-9fde92cb8a0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a51fbaef-e7b8-48b1-a14f-1bed4995c88a", new DateTime(2025, 3, 12, 18, 28, 9, 489, DateTimeKind.Local).AddTicks(5210), false, "AQAAAAIAAYagAAAAEBXh1YcWd/2vw2ME+1ZBzUI7gtqZAyIbk2Fp/BUVGD7euOKSH6EQdMB/tJ0yEP3vwA==", "63b84041-6779-400f-90ec-84665177453d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c2ec0a5-07cc-4b8c-8018-5a6c8e5a62a5", new DateTime(2025, 3, 12, 18, 28, 9, 583, DateTimeKind.Local).AddTicks(6063), false, "AQAAAAIAAYagAAAAEGICxeleKBzqukH7bgYFAOCCrNbTd2vk2BkhX4KulFNWfY3eBGCJaapWotlt+dQL1g==", "0cc49928-910e-4b3b-a922-05c00534b98e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "CourseRequirements");

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
