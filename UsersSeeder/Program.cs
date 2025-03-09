using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Udemy.Core.Entities;

namespace UsersSeeder
{
    internal class Program
    {
        

        static async Task Main(string[] args)
        {
            const string UsersFilePath = "Users.csv";
            var users = UsersReader.ReadUsersFromCsv(UsersFilePath);

            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope(); // Create a DI scope
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //await SeedUsersAsync(userManager, context, users);




        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(@"server=.; database=UdemyDB; Integrated Security=true; TrustServerCertificate=true"));

                services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();

                services.AddLogging();
            });
        static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IEnumerable<Users> users)
        {
            const int batchSize = 500; // Process in batches of 1000

            var hashedPassword = new PasswordHasher<ApplicationUser>().HashPassword(null, "userPassword");

            var students = users.Take(60000).Select(user => new Student
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CountryName = user.CountryName,
                City = user.City,
                State = user.State,
                Age = user.Age,
                Gender = user.Gender,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                EmailConfirmed = true,
                PasswordHash = hashedPassword,
                IsDeleted = false
            });


            var instructors = users.Skip(60000).Select(user => new Instructor
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName.Length > 50 ? user.LastName[..20] : user.LastName,
                CountryName = user.CountryName,
                City = user.City,
                State = user.State,
                Age = user.Age,
                Gender = user.Gender,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsDeleted = false,

            });


            // Insert users in batches
            await BulkInsertInBatches(dbContext, students.ToList(), batchSize);
            await BulkInsertInBatches(dbContext, instructors.ToList(), batchSize);

            // Assign roles manually (bulk insert)



            await AssignRoles(dbContext, dbContext.Students.ToList(), 3);
            await AssignRoles(dbContext, dbContext.Instructors.ToList(), 2);

            Console.WriteLine("User seeding completed.");
        }

        private static async Task BulkInsertInBatches<T>(ApplicationDbContext dbContext, List<T> users, int batchSize) where T : ApplicationUser
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync()) // 🔥 Begin Transaction
            {
                try
                {
                    for (int i = 0; i < users.Count; i += batchSize)
                    {
                        var batch = users.Skip(i).Take(batchSize).ToList();
                        await dbContext.Users.AddRangeAsync(batch);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine($"Inserted {i + batch.Count} users...");
                    }

                    await transaction.CommitAsync(); // ✅ Commit Transaction
                    Console.WriteLine("All users inserted successfully!");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // ❌ Rollback on failure
                    Console.WriteLine($"Transaction failed: {ex.Message}");
                }
            }
        }


        private static async Task AssignRoles<TUser>(ApplicationDbContext dbContext, IEnumerable<TUser> users,int roleId) where TUser : ApplicationUser
        {
            var userRoles = users.Select(user => new IdentityUserRole<int>
            {
                UserId = user.Id,
                RoleId = roleId
            }).ToList();

            await dbContext.UserRoles.AddRangeAsync(userRoles);
            await dbContext.SaveChangesAsync();
        }

        //static async Task SeedUsersAsync( UserManager<ApplicationUser> userManager,ApplicationDbContext dbContext,List<Users> users)
        //{
        //    //Students Seeder
        //    using (var transaction = await dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            foreach (var user in users.Take(60000))
        //            {
        //                var applicationUser = new Student
        //                {
        //                    UserName = user.Email,
        //                    Email = user.Email,
        //                    FirstName = user.FirstName,
        //                    LastName = user.LastName,
        //                    CountryName = user.CountryName,
        //                    City = user.City,
        //                    State = user.State,
        //                    Age = user.Age,
        //                    Gender = user.Gender,
        //                    CreatedDate = DateTime.Now,
        //                    ModifiedDate = DateTime.Now,
        //                    IsDeleted = false
        //                };

        //                var result = await userManager.CreateAsync(applicationUser, user.Password);

        //                if (result.Succeeded)
        //                {
        //                    await userManager.AddToRoleAsync(applicationUser, "Student");
        //                    Console.WriteLine("User created successfully.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors)}");
        //                    throw new Exception("User creation failed, rolling back transaction.");
        //                }
        //            }

        //            await transaction.CommitAsync(); // ✅ Commit transaction if all users are created successfully
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync(); // ❌ Rollback transaction if any error occurs
        //            Console.WriteLine($"Transaction failed: {ex.Message}");
        //        }
        //    }

        //    //Instructor Seeder

        //    using (var transaction = await dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            foreach (var user in users.Skip(6000))
        //            {
        //                var applicationUser = new Instructor
        //                {
        //                    UserName = user.Email,
        //                    Email = user.Email,
        //                    FirstName = user.FirstName,
        //                    LastName = user.LastName,
        //                    CountryName = user.CountryName,
        //                    City = user.City,
        //                    State = user.State,
        //                    Age = user.Age,
        //                    Gender = user.Gender,
        //                    CreatedDate = DateTime.Now,
        //                    ModifiedDate = DateTime.Now,
        //                    IsDeleted = false
        //                };

        //                var result = await userManager.CreateAsync(applicationUser, user.Password);

        //                if (result.Succeeded)
        //                {
        //                    await userManager.AddToRoleAsync(applicationUser, "Instructor");
        //                    Console.WriteLine("User created successfully.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors)}");
        //                    throw new Exception("User creation failed, rolling back transaction.");
        //                }
        //            }

        //            await transaction.CommitAsync(); // ✅ Commit transaction if all users are created successfully
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync(); // ❌ Rollback transaction if any error occurs
        //            Console.WriteLine($"Transaction failed: {ex.Message}");
        //        }
        //    }



        //}




    }





}
