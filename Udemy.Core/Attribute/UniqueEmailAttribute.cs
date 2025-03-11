using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;

namespace Udemy.Core.Attribute;
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value , ValidationContext validationContext)
    {
        var userManager = validationContext.GetService<UserManager<ApplicationUser>>();

        var email = value as string;

        if (userManager.Users.Any(x => x.Email == email))
        {
            return new ValidationResult("Email is already in use.");
        }

        return ValidationResult.Success;
    }
}
