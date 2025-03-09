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
            var users = UsersReader.ReadUsersFromCsv(UsersFilePath).ToList();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) // Create a DI scope
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await SeedUsersAsync(userManager,context, users);
                

            }


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

        static async Task SeedUsersAsync( UserManager<ApplicationUser> userManager,ApplicationDbContext dbContext,List<Users> users)
        {
            //foreach (var user in users.Take(6000))
            //{    
            //        var applicationUser = new Student
            //        {
            //            UserName = user.Email,
            //            Email = user.Email,
            //            FirstName = user.FirstName,
            //            LastName = user.LastName,
            //            CountryName = user.CountryName,
            //            City = user.City,
            //            State = user.State,
            //            Age = user.Age,
            //            Gender = user.Gender,
            //            CreatedDate = DateTime.Now,
            //            ModifiedDate = DateTime.Now,
            //            IsDeleted = false
            //        };
            //        var result = await userManager.CreateAsync(applicationUser, user.Password);

            //        if (result.Succeeded)
            //        {
            //            await userManager.AddToRoleAsync(applicationUser, "Student");



            //            Console.WriteLine("User created successfully.");
            //        }

            //        else
            //            Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors)}");

            //}

            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var user in users.Skip(6000))
                    {
                        var applicationUser = new Instructor
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
                            IsDeleted = false
                        };

                        var result = await userManager.CreateAsync(applicationUser, user.Password);

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(applicationUser, "Instructor");
                            Console.WriteLine("User created successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors)}");
                            throw new Exception("User creation failed, rolling back transaction.");
                        }
                    }

                    await transaction.CommitAsync(); // ✅ Commit transaction if all users are created successfully
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // ❌ Rollback transaction if any error occurs
                    Console.WriteLine($"Transaction failed: {ex.Message}");
                }
            }


            //foreach (var user in users.Skip(6000))
            //{
            //    var applicationUser = new Instructor
            //    { 
            //        UserName = user.Email,
            //        Email = user.Email,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        CountryName = user.CountryName,
            //        City = user.City,
            //        State = user.State,
            //        Age = user.Age,
            //        Gender = user.Gender,
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false
            //    };

            //    var result = await userManager.CreateAsync(applicationUser, user.Password);

            //    if (result.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(applicationUser, "Instructor");

            //        Console.WriteLine("User created successfully.");
            //    }

            //    else
            //        Console.WriteLine($"Failed to create user: {string.Join(", ", result.Errors)}");

            //}
        }
    }





}
