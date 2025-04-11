using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentClientSecretAndPaymentIntentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bf440b9-831f-4c38-a9b7-279e1b186030", new DateTime(2025, 4, 11, 9, 45, 28, 720, DateTimeKind.Local).AddTicks(2727), "AQAAAAIAAYagAAAAEGdX/ys4JuL40Y84/OIE+2bCg3GyljGZCKbYETUjYrWaPYIchTcB1aQxZOOWZO3vQw==", "9009651e-d291-463a-8aeb-1ef941deb3aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22222,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c24de89a-ec7d-40a3-b7a4-061dedc164c3", new DateTime(2025, 4, 11, 9, 45, 28, 832, DateTimeKind.Local).AddTicks(3203), "AQAAAAIAAYagAAAAEK1RBtXpyhGes2lqHLoq5D0YrhtYGj1zEAbFyjJgaI/VCJD2WT4GVJ9lhKK/y5GwvA==", "5251805f-4db8-4e75-bef1-c2ba33ac3803" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33333,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef7011b9-cc66-4737-9a40-a2e6da0c752a", new DateTime(2025, 4, 11, 9, 45, 28, 925, DateTimeKind.Local).AddTicks(3140), "AQAAAAIAAYagAAAAEH+DYVvWyNwj+jbCMcTwKsl2kKW1pD5i2Q4PtA/k/s+O2mDs6yGHw3AZWu9Xs335Dw==", "6b83da6d-d349-48de-9a0b-3a67af7a9c3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Carts");

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
    }
}
