﻿using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IUserRepository
{
    Task<IdentityResult> AddRolesToUser(ApplicationUser user, IEnumerable<string> roles);
    Task<IdentityResult> AddRoleToUser(ApplicationUser user, string role);
    Task<IdentityResult> CreateUserAsync(Student user, string password);
    void DeleteUser(ApplicationUser user);
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool trackChanges, RequestParamter requestParamter);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<ApplicationUser?> GetUserByIdAsync(int id);
    Task<ApplicationUser?> GetUserByUsernameAsync(string username);
}
