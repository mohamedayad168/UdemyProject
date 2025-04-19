using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool trackChanges, RequestParamter requestParamter);
    Task<PaginatedRes<ApplicationUser>> GetRoleUsersPageAsync(PaginatedSearchReq searchReq, string role, DeletionType deletionType, bool trackChanges);



    Task<IdentityResult> AddRolesToUser(ApplicationUser user, IEnumerable<string> roles);
    Task<IdentityResult> AddRoleToUser(ApplicationUser user, string role);
    Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
    void DeleteUser(ApplicationUser user);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<ApplicationUser?> GetUserByIdAsync(int id);
    Task<ApplicationUser?> GetUserByUsernameAsync(string username);
}
