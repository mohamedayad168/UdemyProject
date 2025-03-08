using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateCourseNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Courses",
                newName: "CourseLevel");

            migrationBuilder.AddColumn<string>(
                name: "BestSeller",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestSeller",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseLevel",
                table: "Courses",
                newName: "Level");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c01b33ea-978e-4b2c-8e16-f27031a7acf9", "AQAAAAIAAYagAAAAENI+XgYs4kn0wN7JRU9dK/4u44U7lhFGzlEK2qGoFkNBJA6k+yzWjgGho2mpbhHZrw==", "3918b87b-b44d-464f-828d-8ab9fe60f53d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c453d892-65bd-4bc6-8a8c-51880655b26f", "AQAAAAIAAYagAAAAENDg50BJEkI/71xEfuJrMeJyGBTYWt7xXUqqhN+YaKY1/7fZ4E6TFYIjFY6n+g+kyQ==", "1f4ee09e-055f-4b33-b467-59797552f0e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a893b69-9817-4ad4-ae4d-064b88128fc7", "AQAAAAIAAYagAAAAEGmn2R68Mu97mnxuS74CaR0zu2i5VQctCwjfXFzqF0HbXKIFpOQqPnTDlXDCVqBCuA==", "89d8aa13-9005-477b-bec0-7e0755d069ad" });
        }
    }
}
