using AutoMapper;
using CloudinaryDotNet.Actions;
using System.Text;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class UserService(
    IRepositoryManager repository,
    IMapper mapper) : IUserService
{
    private readonly IRepositoryManager repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges, RequestParamter requestParamter)
    {
        var users = await repository.User.GetAllUsersAsync(trackChanges, requestParamter);

        var usersDto = mapper.Map<IEnumerable<UserDto>>(users);

        return usersDto;
    }


    public async Task<PaginatedRes<UserDto>> GetRoleUsersPageAsync(PaginatedSearchReq searchReq, string role, DeletionType deletionType, bool trackChanges)
    {
        var paginatedUsers = await repository.User.GetRoleUsersPageAsync(searchReq, role, deletionType, trackChanges);

        var paginatedDtos = new PaginatedRes<UserDto>
        {
            Data = mapper.Map<IEnumerable<UserDto>>(paginatedUsers.Data),
            CurrentPage = paginatedUsers.CurrentPage,
            PageSize = paginatedUsers.PageSize,
            TotalItems = paginatedUsers.TotalItems,
        };

        return paginatedDtos;
    }


    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await GetUserAndCheckIfItExistsAsync(id);

        var userDto = mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var user = await repository.User.GetUserByEmailAsync(email);

        if (user is null)
            throw new UserNotFoundException($"User With Email: {email} Deosn't Exist");

        var userDto = mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<ApplicationUser> GetAllUserDataByEmailAsync(string email)
    {
        var user = await repository.User.GetUserByEmailAsync(email);

        if (user is null)
            throw new UserNotFoundException($"User With Email: {email} Deosn't Exist");


        return user;
    }

    public async Task<UserDto> GetUserByUsernameAsync(string username)
    {
        var user = await repository.User.GetUserByUsernameAsync(username);

        if (user is null)
            throw new UserNotFoundException($"User With Username: {username} Deosn't Exist");

        var userDto = mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto> CreateUserAsync(UserForCreationDto userDto,string role="Student")
    {
        var userEntity = mapper.Map<ApplicationUser>(userDto);

        // handle password validation (must contain at least chararcter, ... etc)

        var result = await repository.User.CreateUserAsync(userEntity, userDto.Password);

        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in result.Errors)
                sb.Append(error.Description);

            throw new UserCreatingBadRequest(sb.ToString());
        }

        await repository.User.AddRoleToUser(userEntity, role);



        var userToReturn = mapper.Map<UserDto>(userEntity);

        return userToReturn;
    }

    

    public async Task UpdateUserAsync(int id, UserForUpdatingDto userDto)
    {
        var userEntity = await GetUserAndCheckIfItExistsAsync(id);

        var userWithSameUsername = await repository.User.GetUserByUsernameAsync(userDto.UserName);

        if (userWithSameUsername is not null && userWithSameUsername.Id != userEntity.Id)
        {
            throw new UsernameExistBadRequest(userDto.UserName);
        }

        mapper.Map(userDto, userEntity);

        await repository.SaveAsync();
    }





    private async Task<ApplicationUser> GetUserAndCheckIfItExistsAsync(int id)
    {
        var user = await repository.User.GetUserByIdAsync(id);

        if (user is null)
            throw new UserNotFoundException($"User With Id: {id} Deosn't Exist");

        return user;
    }






    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserAndCheckIfItExistsAsync(id);

        repository.User.DeleteUser(user);

        await repository.SaveAsync();
    }

}
