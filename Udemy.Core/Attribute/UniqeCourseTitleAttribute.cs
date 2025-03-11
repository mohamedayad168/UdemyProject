using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

public class UniqeCourseTitleAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var title = value as string;
        var context = validationContext.GetService<ICoursesRepository>();

        if (context.FindByCondition(c=>c.Title==title,false).AnyAsync().Result)
        {
            return new ValidationResult("Title is already in use.");
        }

        return ValidationResult.Success;
    }
}