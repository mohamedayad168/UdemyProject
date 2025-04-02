using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Security.Claims;
using Udemy.Core.Entities;

namespace Udemy.Presentation.Extenstions;

public static class ClaimPrincipalExtensions
{
    public static async Task<ApplicationUser> GetUserByEmail(
        this UserManager<ApplicationUser> userManager , ClaimsPrincipal user
    )
    {
        var userToReturn = await userManager.Users.FirstOrDefaultAsync(
            x => x.Email == user.GetEmail()
        );

        if (userToReturn == null)
            throw new AuthenticationException("User Not Found");

        return userToReturn;
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email)
            ?? throw new AuthenticationException("Email Not Found");

        return email;
    }
}
