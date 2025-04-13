using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VSupDimSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VSupDimSection",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoLessons = table.Column<int>(type: "int", nullable: false),
                    VideoCount = table.Column<int>(type: "int", nullable: false),
                    ArticleCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSupDimSection", x => new { x.CourseId, x.SectionId });
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VSupDimSection");

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
    }
}
