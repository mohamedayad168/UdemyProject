using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1faa765-9c11-4db4-ba3a-3b8adbef76a1", "AQAAAAIAAYagAAAAEPR30Cqm4q+oYtkpCJ8EWoMg2VU9zeKmNRnfTHDjdbgHoZsaJAKKK/7Dm84bs3L9NA==", "3976843c-824e-48a6-bc48-b11e94accfa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8255debc-5457-4a92-b8ad-eb67616ae4d0", "AQAAAAIAAYagAAAAEBj+6hRLdkslEKsnMt1Z1GpcejHfVsNurJdDDoeHBjzrdpW51ZCc2LzlnwtHN5bBOw==", "3d629337-d4da-4acb-ae71-93720810da32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c105f9-b746-4d9d-baec-a45988d89d92", "AQAAAAIAAYagAAAAEH7NcwmVK77qUCUaDo3z8q+Ckxm2yCQYhZ4LR3pjTIcBqrsp0VHOub2Y+Jyjxnx14w==", "2416a6a1-ee57-4415-a70c-45766478cb7b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
