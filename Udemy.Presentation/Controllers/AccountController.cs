using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(SignInManager<ApplicationUser> signInManager) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await signInManager.UserManager.FindByEmailAsync(loginDto.Email);
        if(user is null)
            return NotFound($"User With Email: {loginDto.Email} Doesn't Exist");

        var result = await signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password);
        if(!result)
            return BadRequest($"Password: {loginDto.Password} is Wrong");

        await signInManager.SignInAsync(user , true);

        return NoContent();
    }

    [Authorize]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }
}
