using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.UserDTOs;
using Udemy.Service.IService;
using Udemy.Service.Service;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/Users")]
public class UserController(IServiceManager serviceManager): ControllerBase
{
    private readonly IServiceManager serviceManager = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery]RequestParamter requestParamter)
    {
        var users = await serviceManager.UserService.GetAllUsersAsync(false , requestParamter);

        return Ok(users);
    }

    [HttpGet("{id:int}" , Name = "GetUserById")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await serviceManager.UserService.GetUserByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserForCreationDto userDto)
    {
        var user = await serviceManager.UserService.CreateUserAsync(userDto);

        return CreatedAtAction("GetUserById", new {id = user.Id}, user);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUser(int id, UserForUpdatingDto userDto)
    {
        await serviceManager.UserService.UpdateUserAsync(id, userDto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await serviceManager.UserService.DeleteUserAsync(id);

        return NoContent();
    }
}
