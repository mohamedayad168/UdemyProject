using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixUsersId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 11111, null, "Admin", "ADMIN" },
                    { 22222, null, "Instructor", "INSTRUCTOR" },
                    { 33333, null, "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "395e0c92-4ce7-441f-9d64-748579039dba", "AQAAAAIAAYagAAAAEBWFh5ipNfFBEVAw4gzA7K1+zj/ZoyU+u2s/i2Ldqb8p1qT1toNcYmohIv2JHDmKcg==", "6f583d56-d71a-49aa-825b-bf536b484292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "535cd4b1-d645-4f98-9349-c7762a481d24", "AQAAAAIAAYagAAAAEKCMKtnpMwVsM7rk/C3heGWBdY+s044xVcrwvQR++pBVkWrAEk/yMUoaKSx8MVZfMw==", "76663652-7baf-4c90-a31d-b148ce486995" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6825703b-3fca-492b-905c-8edbd68f3061", "AQAAAAIAAYagAAAAEHxoSpt0UH8yLau7+rtXRckgn/vkiKFKR8x6ChBXjOVBGjnW5aQvn5YP4UkXVyB1Fg==", "f46a7c70-f5c8-4f0a-b252-c39fee1aca99" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 11111, 1 },
                    { 22222, 2 },
                    { 33333, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 11111, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 22222, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 33333, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 11111);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 22222);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 33333);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Instructor", "INSTRUCTOR" },
                    { 3, null, "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb08d0de-7b44-499e-bdb3-fe08786ff3ed", "AQAAAAIAAYagAAAAEBGIjOqk16nRRPATfMkZLG5PAbN0dlKzy9rSArzp/HJkqQh0V9oAWGPuMspQO8aS6g==", "04daf9ce-5132-4589-842a-c51a5d81748a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "963f80a9-c5a2-4d1b-a34a-34ba52f50d6c", "AQAAAAIAAYagAAAAEPdjEnDbWGISK5RISahPU8K7EeDsuHcbTFMUXCAdlwsZ78zK+yFTZWmCRbdJrTcUgw==", "012dfc60-7cc9-47d3-a468-fdc24adb4cef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4856b9ee-62d5-4ebc-8599-baca6412a491", "AQAAAAIAAYagAAAAEHFK7vaissoa3brhpINHEC5Z4bCRWTqlhlItmar2BIKtQTL4D4Zj2FL5icXG38/L6w==", "3f2fb36c-9b32-44a2-92ca-536f73637f40" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }
    }
}
