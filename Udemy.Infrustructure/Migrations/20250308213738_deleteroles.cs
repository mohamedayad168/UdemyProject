﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Instructor", "INSTRUCTOR" },
                    { 3, null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "City", "ConcurrencyStamp", "CountryName", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 11111, 0, 30, "New York", "74b3201b-c630-40de-824b-28805f1d685d", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", "M", null, "Admin", false, null, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAIAAYagAAAAEG1McwDuVZzuhRJqMGOSEs89N3DoaNZLF5JrQQWb0v6Pd80rjYuvoMbew3nW9KbtCA==", null, false, "c153428f-a909-4d22-b6a9-2913f1e9b22c", "New York", false, "admin" },
                    { 22222, 0, 30, "New York", "42b8bc1d-682b-4825-bdb1-d79212025bf7", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@gmail.com", true, "Instructor", "M", null, "Instructor", false, null, null, "INSTRUCTOR@gmail.com", "INSTRUCTOR", "AQAAAAIAAYagAAAAEGLJj4unaIL41CT88r12ySz1N7um8cZW8T7aqh/kQPGoUwtU5VZ0QGVkobbzgoYx1A==", null, false, "7b7c75f7-34c1-4429-b51c-d13637bc7089", "New York", false, "instructor" },
                    { 33333, 0, 30, "New York", "26eae278-2cee-403b-8642-121547d7b9c8", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@gmail.com", true, "Student", "M", null, "Student", false, null, null, "STUDENT@gmail.com", "STUDENT", "AQAAAAIAAYagAAAAEAzIZStgcOkN9K9IkhMRHq5xuTWC2TdZ6e7mX5t8CGSrP3X2mWabJO1r+WhNs4Pwxw==", null, false, "e47e9a71-cf7d-40b1-8872-957386f78191", "New York", false, "student" }
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
    }
}
