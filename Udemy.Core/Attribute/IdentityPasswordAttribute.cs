using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;

namespace Udemy.Core.Attribute;
public class IdentityPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value , ValidationContext validationContext)
    {
        var password = value as string;

        var userManager = validationContext.GetRequiredService<UserManager<ApplicationUser>>();

        var passwordOptions = validationContext.GetService<IOptions<IdentityOptions>>()?.Value.Password;
        var passwordValidator = new PasswordValidator<ApplicationUser>();
        var identityUser = new ApplicationUser(); 

        var validationResult = passwordValidator.ValidateAsync(
            manager: userManager , 
            user: identityUser ,
            password: password
        ).GetAwaiter().GetResult();


        if (!validationResult.Succeeded)
        {
            var errorMessage = string.Join("," , validationResult.Errors.Select(e => e.Description));
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }
}