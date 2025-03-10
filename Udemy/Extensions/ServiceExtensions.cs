﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository;
using Udemy.Infrastructure.Repository.EntityRepos;
using Udemy.Service.AutoMapperConfigration;
using Udemy.Service.IService;
using Udemy.Service.Service;
namespace Udemy.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<ApplicationUser, IdentityRole<int>>(o =>
        {
            //o.Password.RequireDigit = true;
            //o.Password.RequireLowercase = false;
            //o.Password.RequireUppercase = false;
            //o.Password.RequireNonAlphanumeric = false;
            //o.Password.RequiredLength = 10;
            //o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
    }
    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<ICourseRequirementRepo, CourseRequirementRepo>();
    }
    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();


    }
    public static void ConfigureAutoMapperService(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(AutoMapperProfile));
    }

}
