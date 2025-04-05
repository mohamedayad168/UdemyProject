using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class UserRepository(
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager) : IUserRepository
{
    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool trackChanges, RequestParamter requestParamter)
    {
        var users = trackChanges
            ? dbContext.Users.OfType<ApplicationUser>()
            : dbContext.Users.OfType<ApplicationUser>().AsNoTracking();

        return await users
            .Where(x => x.IsDeleted != true)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(int id)
    {
        return await userManager.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted != true);
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        return user?.IsDeleted == true ? null : user;
    }

    public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);

        return user?.IsDeleted == true ? null : user;
    }

    public async Task<IdentityResult> AddRolesToUser(ApplicationUser user, IEnumerable<string> roles)
    {
        return await userManager.AddToRolesAsync(user, roles);
    }

    public async Task<IdentityResult> AddRoleToUser(ApplicationUser user, string role)
    {
        return await userManager.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
    {
        var result = await userManager.CreateAsync(user, password);
        await dbContext.SaveChangesAsync();
        return result;

    }

    public void DeleteUser(ApplicationUser user)
    {
        user.IsDeleted = true;
    }
}
