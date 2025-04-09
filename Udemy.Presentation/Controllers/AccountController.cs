using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Udemy.Core.Entities;
using Udemy.Core.Utils;
using Udemy.Presentation.Extenstions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    SignInManager<ApplicationUser> signInManager ,
    IMapper mapper ,
    IServiceManager serviceManager

) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (user is null)
            return NotFound($"User With Email: {loginDto.Email} Doesn't Exist");

        var result = await signInManager.UserManager.CheckPasswordAsync(user , loginDto.Password);
        if (!result)
            return BadRequest($"Password: {loginDto.Password} is Wrong");

        var roles = await signInManager.UserManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role , role));
        }

        var identity = new ClaimsIdentity(claims , "Identity.Application");

        var principal = new ClaimsPrincipal(identity);

        await signInManager.SignOutAsync();

        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme , principal , new AuthenticationProperties
        {
            IsPersistent = true
        });

        return NoContent();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }

    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated == false)
            return NoContent();

        var user = await signInManager.UserManager.GetUserByEmail(User);
        var userDto = mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpGet]
    public IActionResult GetAuthState()
    {
        return Ok(new
        {
            isAuthenticated = User.Identity?.IsAuthenticated ?? false
        });
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(UserForCreationDto register)
    {
        var user = await signInManager.UserManager.FindByEmailAsync(register.Email);
        if (user == null)
        {
            var createUser = await serviceManager.UserService.CreateUserAsync(register);

            var userEntity = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
            await signInManager.UserManager.AddToRoleAsync(userEntity , UserRole.Student);

            return Ok(createUser);
        }
        else
        {
            return BadRequest("Email is Already Exist");
        }

    }
}
