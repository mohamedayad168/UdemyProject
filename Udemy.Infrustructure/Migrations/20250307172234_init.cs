using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Name = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    NormalizedName = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles" , x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    FirstName = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    LastName = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    CountryName = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    City = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    State = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Age = table.Column<int>(type: "int" , nullable: false) ,
                    Gender = table.Column<string>(type: "nvarchar(1)" , maxLength: 1 , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: true) ,
                    UserName = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    Email = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)" , maxLength: 256 , nullable: true) ,
                    EmailConfirmed = table.Column<bool>(type: "bit" , nullable: false) ,
                    PasswordHash = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit" , nullable: false) ,
                    TwoFactorEnabled = table.Column<bool>(type: "bit" , nullable: false) ,
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset" , nullable: true) ,
                    LockoutEnabled = table.Column<bool>(type: "bit" , nullable: false) ,
                    AccessFailedCount = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers" , x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Name = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories" , x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Content = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications" , x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    RoleId = table.Column<int>(type: "int" , nullable: false) ,
                    ClaimType = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    ClaimValue = table.Column<string>(type: "nvarchar(max)" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId" ,
                        column: x => x.RoleId ,
                        principalTable: "AspNetRoles" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    ClaimType = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    ClaimValue = table.Column<string>(type: "nvarchar(max)" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins" ,
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)" , nullable: false) ,
                    ProviderKey = table.Column<string>(type: "nvarchar(450)" , nullable: false) ,
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    UserId = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins" , x => new { x.LoginProvider , x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles" ,
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    RoleId = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles" , x => new { x.UserId , x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId" ,
                        column: x => x.RoleId ,
                        principalTable: "AspNetRoles" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens" ,
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    LoginProvider = table.Column<string>(type: "nvarchar(450)" , nullable: false) ,
                    Name = table.Column<string>(type: "nvarchar(450)" , nullable: false) ,
                    Value = table.Column<string>(type: "nvarchar(max)" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens" , x => new { x.UserId , x.LoginProvider , x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false) ,
                    Title = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: true) ,
                    Bio = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: true) ,
                    TotalCourses = table.Column<int>(type: "int" , nullable: true) ,
                    TotalReviews = table.Column<int>(type: "int" , nullable: true) ,
                    TotalStudents = table.Column<int>(type: "int" , nullable: true) ,
                    Wallet = table.Column<decimal>(type: "decimal(18,2)" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_AspNetUsers_Id" ,
                        column: x => x.Id ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false) ,
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    Name = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Link = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias" , x => new { x.Id , x.UserId });
                    table.ForeignKey(
                        name: "FK_SocialMedias_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false) ,
                    Title = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Bio = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    Wallet = table.Column<decimal>(type: "decimal(18,2)" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_Id" ,
                        column: x => x.Id ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Name = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    CategoryId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId" ,
                        column: x => x.CategoryId ,
                        principalTable: "Categories" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserNotification" ,
                columns: table => new
                {
                    NotificationsId = table.Column<int>(type: "int" , nullable: false) ,
                    UsersId = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserNotification" , x => new { x.NotificationsId , x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserNotification_AspNetUsers_UsersId" ,
                        column: x => x.UsersId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserNotification_Notifications_NotificationsId" ,
                        column: x => x.NotificationsId ,
                        principalTable: "Notifications" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    StudentId = table.Column<int>(type: "int" , nullable: false) ,
                    Amount = table.Column<int>(type: "int" , nullable: true) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Students_StudentId" ,
                        column: x => x.StudentId ,
                        principalTable: "Students" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    StudentId = table.Column<int>(type: "int" , nullable: false) ,
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    Status = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    TotalAmount = table.Column<int>(type: "int" , nullable: false) ,
                    Discount = table.Column<decimal>(type: "decimal(8,2)" , nullable: true) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Students_StudentId" ,
                        column: x => x.StudentId ,
                        principalTable: "Students" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Title = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Description = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    Status = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    Level = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    Discount = table.Column<decimal>(type: "DECIMAL(8,2)" , nullable: true) ,
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)" , nullable: false) ,
                    Duration = table.Column<int>(type: "int" , nullable: false) ,
                    Language = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    ImageUrl = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    VideoUrl = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    NoSubscribers = table.Column<int>(type: "int" , nullable: false) ,
                    IsFree = table.Column<bool>(type: "bit" , nullable: false) ,
                    IsApproved = table.Column<bool>(type: "bit" , nullable: false) ,
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)" , nullable: false , computedColumnSql: "[Price] * ([Discount]/100)" , stored: true) ,
                    Rating = table.Column<decimal>(type: "DECIMAL(2,1)" , nullable: true) ,
                    SubCategoryId = table.Column<int>(type: "int" , nullable: false) ,
                    InstructorId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId" ,
                        column: x => x.InstructorId ,
                        principalTable: "Instructors" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Subcategories_SubCategoryId" ,
                        column: x => x.SubCategoryId ,
                        principalTable: "Subcategories" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asks" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Title = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Content = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asks" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asks_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asks_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartCourse" ,
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int" , nullable: false) ,
                    CoursesId = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCourse" , x => new { x.CartsId , x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CartCourse_Carts_CartsId" ,
                        column: x => x.CartsId ,
                        principalTable: "Carts" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade); // Keep CASCADE for CartsId
                    table.ForeignKey(
                        name: "FK_CartCourse_Courses_CoursesId" ,
                        column: x => x.CoursesId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.NoAction); // Change to NO ACTION for CoursesId
                });

            migrationBuilder.CreateTable(
                name: "CourseGoals" ,
                columns: table => new
                {
                    Goal = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: false) ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGoals" , x => new { x.CourseId , x.Goal });
                    table.ForeignKey(
                        name: "FK_CourseGoals_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOrder" ,
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int" , nullable: false) ,
                    OrdersId = table.Column<int>(type: "int" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOrder" , x => new { x.CoursesId , x.OrdersId });
                    table.ForeignKey(
                        name: "FK_CourseOrder_Courses_CoursesId" ,
                        column: x => x.CoursesId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade); // Keep CASCADE for CoursesId
                    table.ForeignKey(
                        name: "FK_CourseOrder_Orders_OrdersId" ,
                        column: x => x.OrdersId ,
                        principalTable: "Orders" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.NoAction); // Change to NO ACTION for OrdersId
                });

            migrationBuilder.CreateTable(
                name: "CourseRequirements" ,
                columns: table => new
                {
                    Requirement = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: false) ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRequirements" , x => new { x.Requirement , x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseRequirements_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments" ,
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int" , nullable: false) ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    StartDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    CompletionDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    Status = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    Rating = table.Column<decimal>(type: "DECIMAL(8,2)" , nullable: true) ,
                    comment = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: true) ,
                    CertificationUrl = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: true) ,
                    ProgressPercentage = table.Column<decimal>(type: "decimal(8,2)" , nullable: true)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments" , x => new { x.StudentId , x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId" ,
                        column: x => x.StudentId ,
                        principalTable: "Students" ,
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quizzes" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Title = table.Column<string>(type: "nvarchar(20)" , maxLength: 20 , nullable: false) ,
                    Duration = table.Column<int>(type: "int" , nullable: false) ,
                    NoLessons = table.Column<int>(type: "int" , nullable: false) ,
                    CourseId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId" ,
                        column: x => x.CourseId ,
                        principalTable: "Courses" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Content = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    AskId = table.Column<int>(type: "int" , nullable: false) ,
                    UserId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Asks_AskId" ,
                        column: x => x.AskId ,
                        principalTable: "Asks" ,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_UserId" ,
                        column: x => x.UserId ,
                        principalTable: "AspNetUsers" ,
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false) ,
                    QuizId = table.Column<int>(type: "int" , nullable: false) ,
                    Type = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    QuestionTxt = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    ChoiceA = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: true) ,
                    ChoiceB = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: true) ,
                    ChoiceC = table.Column<string>(type: "nvarchar(50)" , maxLength: 50 , nullable: true) ,
                    AnswerTxt = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions" , x => new { x.Id , x.QuizId });
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId" ,
                        column: x => x.QuizId ,
                        principalTable: "Quizzes" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades" ,
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int" , nullable: false) ,
                    QuizId = table.Column<int>(type: "int" , nullable: false) ,
                    Grade = table.Column<decimal>(type: "decimal(8,2)" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades" , x => new { x.StudentId , x.QuizId });
                    table.ForeignKey(
                        name: "FK_StudentGrades_Quizzes_QuizId" ,
                        column: x => x.QuizId ,
                        principalTable: "Quizzes" ,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentGrades_Students_StudentId" ,
                        column: x => x.StudentId ,
                        principalTable: "Students" ,
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    Title = table.Column<string>(type: "nvarchar(100)" , maxLength: 100 , nullable: false) ,
                    Duration = table.Column<int>(type: "int" , nullable: false) ,
                    Type = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    VideoUrl = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    ArticleContent = table.Column<string>(type: "nvarchar(max)" , nullable: true) ,
                    SectionId = table.Column<int>(type: "int" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Sections_SectionId" ,
                        column: x => x.SectionId ,
                        principalTable: "Sections" ,
                        principalColumn: "Id" ,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progresses" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "int" , nullable: false)
                        .Annotation("SqlServer:Identity" , "1, 1") ,
                    StudentId = table.Column<int>(type: "int" , nullable: false) ,
                    LessonId = table.Column<int>(type: "int" , nullable: false) ,
                    Status = table.Column<string>(type: "nvarchar(max)" , nullable: false) ,
                    CreatedDate = table.Column<DateTime>(type: "datetime2" , nullable: false) ,
                    ModifiedDate = table.Column<DateTime>(type: "datetime2" , nullable: true) ,
                    IsDeleted = table.Column<bool>(type: "bit" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses" , x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_Lessons_LessonId" ,
                        column: x => x.LessonId ,
                        principalTable: "Lessons" ,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Progresses_Students_StudentId" ,
                        column: x => x.StudentId ,
                        principalTable: "Students" ,
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles" ,
                columns: new[] { "Id" , "ConcurrencyStamp" , "Name" , "NormalizedName" } ,
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Instructor", "INSTRUCTOR" },
                    { 3, null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers" ,
                columns: new[] { "Id" , "AccessFailedCount" , "Age" , "City" , "ConcurrencyStamp" , "CountryName" , "CreatedDate" , "Email" , "EmailConfirmed" , "FirstName" , "Gender" , "IsDeleted" , "LastName" , "LockoutEnabled" , "LockoutEnd" , "ModifiedDate" , "NormalizedEmail" , "NormalizedUserName" , "PasswordHash" , "PhoneNumber" , "PhoneNumberConfirmed" , "SecurityStamp" , "State" , "TwoFactorEnabled" , "UserName" } ,
                values: new object[,]
                {
                    { 1, 0, 30, "New York", "4b9885ca-34c0-45fc-95ba-d4ecca8f1850", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", "M", null, "Admin", false, null, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAIAAYagAAAAEAh1HDCwOmBO0eDKbNlp4pw5pIxR7VOuFqOrlyYpyUdM8KKmitsDH9RbylMSco0l9g==", null, false, "8247017f-0303-41ce-b03d-1e477cdd0faa", "New York", false, "admin" },
                    { 2, 0, 30, "New York", "8db67495-385b-4f3c-9a5d-c7f967c46559", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@gmail.com", true, "Instructor", "M", null, "Instructor", false, null, null, "INSTRUCTOR@gmail.com", "INSTRUCTOR", "AQAAAAIAAYagAAAAENaRMm09AXZuA8y3hkjInhXrvkgdJ0lMZ7tqjU6Y8i/MlR3iHDfRfZxpaAIqy2wIFQ==", null, false, "45784fc4-a104-4d17-8696-545850fc5f01", "New York", false, "instructor" },
                    { 3, 0, 30, "New York", "d58e2701-2396-4f02-9d90-0d61d7ef14ba", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@gmail.com", true, "Student", "M", null, "Student", false, null, null, "STUDENT@gmail.com", "STUDENT", "AQAAAAIAAYagAAAAEKnhCONsEBk2zZH687mbtK3WiJcjAP4IyOry/VtohNJpp+qGdCD9csSmx/Qa+J5U6g==", null, false, "322e74ed-1f6b-4e51-97e2-3e8f0544c8d6", "New York", false, "student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles" ,
                columns: new[] { "RoleId" , "UserId" } ,
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Instructors" ,
                columns: new[] { "Id" , "Bio" , "Title" , "TotalCourses" , "TotalReviews" , "TotalStudents" , "Wallet" } ,
                values: new object[] { 2 , null , null , null , null , null , 0m });

            migrationBuilder.InsertData(
                table: "Students" ,
                columns: new[] { "Id" , "Bio" , "Title" , "Wallet" } ,
                values: new object[] { 3 , null , "Student" , 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AskId" ,
                table: "Answers" ,
                column: "AskId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId" ,
                table: "Answers" ,
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserNotification_UsersId" ,
                table: "ApplicationUserNotification" ,
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Asks_CourseId" ,
                table: "Asks" ,
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Asks_UserId" ,
                table: "Asks" ,
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId" ,
                table: "AspNetRoleClaims" ,
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex" ,
                table: "AspNetRoles" ,
                column: "NormalizedName" ,
                unique: true ,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId" ,
                table: "AspNetUserClaims" ,
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId" ,
                table: "AspNetUserLogins" ,
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId" ,
                table: "AspNetUserRoles" ,
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex" ,
                table: "AspNetUsers" ,
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex" ,
                table: "AspNetUsers" ,
                column: "NormalizedUserName" ,
                unique: true ,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartCourse_CoursesId" ,
                table: "CartCourse" ,
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_StudentId" ,
                table: "Carts" ,
                column: "StudentId" ,
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOrder_OrdersId" ,
                table: "CourseOrder" ,
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequirements_CourseId" ,
                table: "CourseRequirements" ,
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId" ,
                table: "Courses" ,
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubCategoryId" ,
                table: "Courses" ,
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId" ,
                table: "Enrollments" ,
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId" ,
                table: "Lessons" ,
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StudentId" ,
                table: "Orders" ,
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_LessonId" ,
                table: "Progresses" ,
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_StudentId" ,
                table: "Progresses" ,
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId" ,
                table: "QuizQuestions" ,
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CourseId" ,
                table: "Quizzes" ,
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId" ,
                table: "Sections" ,
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UserId" ,
                table: "SocialMedias" ,
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_QuizId" ,
                table: "StudentGrades" ,
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId" ,
                table: "Subcategories" ,
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ApplicationUserNotification");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartCourse");

            migrationBuilder.DropTable(
                name: "CourseGoals");

            migrationBuilder.DropTable(
                name: "CourseOrder");

            migrationBuilder.DropTable(
                name: "CourseRequirements");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "Asks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
