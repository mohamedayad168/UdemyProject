using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Infrastructure.Extensions;

namespace Udemy.Infrastructure.Repository;
public class UserRepository(
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager) : RepositoryBase<ApplicationUser>(dbContext), IUserRepository
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

    public async Task<PaginatedRes<ApplicationUser>> GetRoleUsersPageAsync(PaginatedSearchReq searchReq,string roleName, DeletionType deletionType, bool trackChanges)
    {
        IQueryable<ApplicationUser> query = from user in dbContext.Users
                               join UserRole in dbContext.UserRoles on user.Id equals UserRole.UserId
                               join Role in dbContext.Roles on UserRole.RoleId equals Role.Id
                               where Role.Name == roleName
                               select user;

      
        if (searchReq.SearchTerm!.Length > 0)
        {
            query = FindAll(trackChanges, deletionType)
            .Where(x => 
                x.FirstName.ToLower().Contains(searchReq.SearchTerm!.Trim().ToLower()) ||
                x.LastName.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower()) ||
                x.Email.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower()) ||
                EF.Functions.Like(x.PhoneNumber, searchReq.SearchTerm!.Trim())
             );
        }
        else
        {
            query = FindAll(trackChanges, deletionType);
        }


        var courses = await query
            .Sort(searchReq.OrderBy!)
            .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
            .Take(searchReq.PageSize)
            .ToListAsync();

        var response = new PaginatedRes<ApplicationUser>
        {
            CurrentPage = searchReq.PageNumber,
            PageSize = searchReq.PageSize,
            TotalItems = await query.CountAsync(),
            Data = courses,
        };
        return response;
    }



    public async Task<ApplicationUser?> GetUserByIdAsync(int id)
    {
        return await userManager.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted != true);
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        var user = await dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email);



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
