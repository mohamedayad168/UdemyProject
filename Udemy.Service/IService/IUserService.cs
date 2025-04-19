using CloudinaryDotNet.Actions;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserForCreationDto userDto, string role="Student");
    Task DeleteUserAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges, RequestParamter? requestParamter);
    Task<PaginatedRes<UserDto>> GetRoleUsersPageAsync(PaginatedSearchReq searchReq, string roleName, DeletionType deletionType, bool trackChanges);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> GetUserByUsernameAsync(string username);
    Task<ApplicationUser> GetAllUserDataByEmailAsync(string email);
    Task UpdateUserAsync(int id, UserForUpdatingDto userDto);
}
