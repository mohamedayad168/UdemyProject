using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VDimcourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoSubscribers = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VDimcourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VDimUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasFacebook = table.Column<bool>(type: "bit", nullable: false),
                    HasLinkedin = table.Column<bool>(type: "bit", nullable: false),
                    HasX = table.Column<bool>(type: "bit", nullable: false),
                    HasInstagram = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: false),
                    IsInstructor = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VDimUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VSupDimQuiz",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    MultipleChoiceCount = table.Column<int>(type: "int", nullable: false),
                    TrueOrFalseCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSupDimQuiz", x => new { x.CourseId, x.QuizId });
                });

            migrationBuilder.CreateTable(
                name: "vw_FactCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartDateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vw_FactCart", x => new { x.CourseId, x.StudentId, x.CartId });
                });

            migrationBuilder.CreateTable(
                name: "vw_FactEnrollment",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDateKey = table.Column<int>(type: "int", nullable: false),
                    CompletionDateKey = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeDateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vw_FactEnrollment", x => new { x.CourseId, x.StudentId });
                });

            migrationBuilder.CreateTable(
                name: "vw_FactOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDateKey = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vw_FactOrder", x => new { x.OrderId, x.StudentId });
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31d45892-9945-425e-9ab8-e54fc943beef", new DateTime(2025, 4, 11, 23, 1, 32, 261, DateTimeKind.Local).AddTicks(477), "AQAAAAIAAYagAAAAEOvR4TjC011CQmGWlvjGr0xYMCfwXIL50JHZTTOnOpcsWKNbZ7Q0DH7hsQJXYMdqgw==", "a8aa8a24-a18d-442b-9387-21da7be925fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41ba4084-01b8-4621-bb89-c4bca2a2f613", new DateTime(2025, 4, 11, 23, 1, 32, 299, DateTimeKind.Local).AddTicks(7118), "AQAAAAIAAYagAAAAEAA7mD6908fiM/p5bBPDjfWyYkvTmc2AHXVmB01hJc23Kc084eueoSFRgK8X1KCLrg==", "195cd78e-4ab4-4961-8ebd-9ab9ab16de84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8006ac1-9af4-450c-b2d7-f409144a5b76", new DateTime(2025, 4, 11, 23, 1, 32, 339, DateTimeKind.Local).AddTicks(2298), "AQAAAAIAAYagAAAAENNv9Gt2rBf/09qtjy8OE1TF1k1xAG0INz/5zDFMTBmUzszAP9CZquixR0S5GOP/rA==", "83b0d1b9-71a2-407a-b555-71f184e7e6ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VDimcourse");

            migrationBuilder.DropTable(
                name: "VDimUser");

            migrationBuilder.DropTable(
                name: "VSupDimQuiz");

            migrationBuilder.DropTable(
                name: "vw_FactCart");

            migrationBuilder.DropTable(
                name: "vw_FactEnrollment");

            migrationBuilder.DropTable(
                name: "vw_FactOrder");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "715ecdbd-0982-4e7a-b76f-d39aef5c26f4", new DateTime(2025, 4, 11, 22, 10, 28, 855, DateTimeKind.Local).AddTicks(316), "AQAAAAIAAYagAAAAEG8IDxl6Y87vG/GagMfFpwDH4lOiynGjMKQCNLobO49plvqpQnjtaPz1j3N3fqHW7g==", "64de5aff-084a-4dd7-8cc2-71bb39321e9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72af8547-65ae-49c4-938d-faf50ec7e030", new DateTime(2025, 4, 11, 22, 10, 28, 891, DateTimeKind.Local).AddTicks(4580), "AQAAAAIAAYagAAAAEKL9BRO3lmKA+lbzHc+oHx7O9IxacMVaPa+IggIUOV9lJoFb2LRCym0nanq47poEvw==", "a9df0f44-8865-468d-b150-237a95bcadd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2ec21cb-d668-4436-ba4b-cff1bef16105", new DateTime(2025, 4, 11, 22, 10, 28, 927, DateTimeKind.Local).AddTicks(8299), "AQAAAAIAAYagAAAAECU628twUynzvtD/3yF0v7p88mxEvwUUuFfkVhPBYPzyglZBUjOWDYAyfFYyHuLqHg==", "41eb8e02-3e95-455b-901d-9764913ccb3c" });
        }
    }
}
