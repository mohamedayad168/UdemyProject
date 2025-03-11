using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;

namespace Udemy.Core.Attribute;
public class UniquUsernameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value , ValidationContext validationContext)
    {
        var userManager = validationContext.GetService<UserManager<ApplicationUser>>();

        var username = value as string;

        if (userManager.Users.Any(x => x.UserName == username))
        {
            return new ValidationResult("username is already in use.");
        }

        return ValidationResult.Success;
    }
}
