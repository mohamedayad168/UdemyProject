using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedBasicUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BestSeller",
                table: "Courses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "City", "ConcurrencyStamp", "CountryName", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 11111, 0, 30, "New York", "ec8fed8d-5b3e-449a-9786-2c2507a2176f", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", "M", null, "Admin", false, null, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAIAAYagAAAAELptlHr87XOMNoUOJ6H28Y9Y5c6NqvZlWF/bRw9599tRCWK8f0TrZ8N/bBki96qA3w==", null, false, "d59f451d-b9a2-4533-8b5f-ab00240ec1cd", "New York", false, "admin" },
                    { 22222, 0, 30, "New York", "c9eda82e-332f-4c92-9326-cc2044b76e9b", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@gmail.com", true, "Instructor", "M", null, "Instructor", false, null, null, "INSTRUCTOR@gmail.com", "INSTRUCTOR", "AQAAAAIAAYagAAAAEBThkFxhSwiCmSD3glkmsvGjtEoYzYMZoVXnW8kQtFOqb7lOcO9nMNihbWbsD/Ziqw==", null, false, "5afa2791-5ba6-496e-bd26-0658089cc99c", "New York", false, "instructor" },
                    { 33333, 0, 30, "New York", "7bdffd32-3985-4d5c-9ad9-4d1dcdb46570", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@gmail.com", true, "Student", "M", null, "Student", false, null, null, "STUDENT@gmail.com", "STUDENT", "AQAAAAIAAYagAAAAEJnuytiMsa4IfZtbl3tBVPPtnceUGkiIMw544KG5g3xh06ygipSZWgn2As1u+ATl/g==", null, false, "8d49504d-ea9d-44a9-b707-50f7bd1d96f7", "New York", false, "student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 11111 },
                    { 2, 22222 },
                    { 3, 33333 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Title", "TotalCourses", "TotalReviews", "TotalStudents", "Wallet" },
                values: new object[] { 22222, null, null, null, null, null, 0m });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Bio", "Title", "Wallet" },
                values: new object[] { 33333, null, "Student", 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 11111 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 22222 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 33333 });

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 22222);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33333);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333);

            migrationBuilder.AlterColumn<string>(
                name: "BestSeller",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
