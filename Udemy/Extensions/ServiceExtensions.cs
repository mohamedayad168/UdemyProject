using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository;
using Udemy.Service.AutoMapperConfigration;
using Udemy.Service.Helper;
using Udemy.Service.IService;
using Udemy.Service.Service;
namespace Udemy.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<ApplicationUser , IdentityRole<int>>(o =>
        {
            o.Password.RequiredLength = 8;
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;
            o.Password.RequireUppercase = true;
            o.Password.RequireNonAlphanumeric = true;
            o.Password.RequiredUniqueChars = 1;
            o.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }
    public static void ConfigureSqlContext(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
            options.EnableSensitiveDataLogging();
        });
    }
    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager , RepositoryManager>();

    }
    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager , ServiceManager>();


    }
    public static void ConfigureAutoMapperService(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(AutoMapperProfile));
    }
    public static void ConfigureCloudinaryService(this IServiceCollection service)
    {
        service.AddScoped<ICloudService , CloudService>();
    }
    public static void ConfigureCloudinarySettings(this IServiceCollection service , IConfiguration configuration)
    {
        service.Configure<CloudSetting>(configuration.GetSection("CloudinarySettings"));
    }
    public static void ConfigureCORS(this IServiceCollection service)
    {
        service.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDevelopment" ,
                policy =>
                {
                    policy.WithOrigins(
                        "http://localhost:4200" ,//student & instructor frontend
                        "http://localhost:54377"// admin frontend
                    )
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });


            options.AddPolicy("AllowAngularProduction" ,
                policy =>
                {
                    policy.WithOrigins("https://studify-admin-yn.vercel.app")
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });
    }
    public static void ConfigureApplicationDevelopmentCookie(this IServiceCollection services)
    {
        // Configure Identity's default cookie directly
        services.ConfigureApplicationCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromDays(30);
            //options.Cookie.SameSite = SameSiteMode.None;
            // Disable redirects
            options.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = ctx =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                } ,
                OnRedirectToAccessDenied = ctx =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                }
            };
        });
    }
    public static void ConfigureApplicationProductionCookie(this IServiceCollection services)
    {
        // Configure Identity's default cookie directly
        services.ConfigureApplicationCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromDays(30);
            options.Cookie.SameSite = SameSiteMode.None;
            // Disable redirects
            options.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = ctx =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                } ,
                OnRedirectToAccessDenied = ctx =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                }
            };
        });
    }
}
