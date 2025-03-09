using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixStudentTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Students",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5432e61-4ec3-452c-aa0a-2c0751302993", "AQAAAAIAAYagAAAAECpYVuCw1rHq/kHTNr00zbOWJoonhmpsmijx1q1gNqVHUx29DPOZKRmGG+ZvsorMcQ==", "5c69b646-f51d-4b56-b903-9ce3c6a91b06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9ee90be-fb51-4bdc-9246-daa0bb32db83", "AQAAAAIAAYagAAAAEKUW/LkTag61ZY9fp6eUzoNF+D9kBpCji53RLjjrqQiFQwvraFndS2WMdEiOa81LOQ==", "003f5ffb-99e8-4133-95b6-bc3000d835c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dc08e71-1d17-4985-a2ca-5b47f4d4972b", "AQAAAAIAAYagAAAAEL9YYui96GR8Lsib/ZGPxgX9LJwMIJ00nytvcVaOsPzfM14GH7EhVTtKRxtSC2wnCg==", "18fe4b08-7545-48d1-8990-16e53d47c7ae" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Students",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64f1e41d-390a-4d80-99e2-c7ddb00c6444", "AQAAAAIAAYagAAAAEIJFl25ZCsRJVHJX7BDlO5x9THzb5sI2IZaH6ceOXfdyxNMyXyds1pvg2w+MUN2MJQ==", "6f8192c6-77f0-4a04-8667-008818c798d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30dc4fee-4482-41ce-8c59-6d938e469ab4", "AQAAAAIAAYagAAAAEB8IdWVhQogIsAAyzQbOm0SKJahzbKXcQ1ELE91eyDMiJQJbs8YrSa7e/xOao9w3xw==", "1b57d5bc-8dff-4bc6-964a-9fc415cde1af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "910ecfd9-a4dd-42ca-93cd-60c38c7318fd", "AQAAAAIAAYagAAAAEFVN7PbI2eR7JtJNiu0I2+NN8+rQAN0fGtRbpPUDXrhV9sdN2/VkiexJEKrdicHNZw==", "a5d9ca50-f92f-4b9c-8f51-fad7e961104e" });
        }
    }
}
