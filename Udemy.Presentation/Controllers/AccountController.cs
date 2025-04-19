using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    SignInManager<ApplicationUser> signInManager,
    IMapper mapper,
    IServiceManager serviceManager,
    ILogger<AccountController> logger,
    UserManager<ApplicationUser> userManager

) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (user is null)
            return NotFound($"User With Email: {loginDto.Email} Doesn't Exist");

        var result = await signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
            return BadRequest($"Password: {loginDto.Password} is Wrong");

        var roles = await signInManager.UserManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role , UserRole.Student)
        };

        var identity = new ClaimsIdentity(claims, "Identity.Application");

        var principal = new ClaimsPrincipal(identity);

        await signInManager.SignOutAsync();

        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal, new AuthenticationProperties
        {
            IsPersistent = true
        });

        var userDto = mapper.Map<UserDto>(user);
        userDto.Roles = roles ?? [];

        return Ok(userDto);
    }
    [HttpPost("instructor/login")]
    public async Task<IActionResult> instructorLogin(LoginDto loginDto)
    {
        var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (user is null)
            return NotFound($"User With Email: {loginDto.Email} Doesn't Exist");

        var result = await signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
            return BadRequest($"Password: {loginDto.Password} is Wrong");

        var roles = await signInManager.UserManager.GetRolesAsync(user);
        if (roles.Contains("Instructor"))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role , UserRole.Instructor)
            };


            var identity = new ClaimsIdentity(claims, "Identity.Application");

            var principal = new ClaimsPrincipal(identity);

            await signInManager.SignOutAsync();

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true
            });

            var userDto = mapper.Map<UserDto>(user);
            userDto.Roles = roles ?? [];

            return Ok(userDto);
        }

        return BadRequest("you are not instructor please register as instructor");

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
        logger.LogInformation("GetUserInfo method is called");
        if (User.Identity?.IsAuthenticated == false)
            return NoContent();

        var user = await signInManager.UserManager.GetUserByEmail(User);
        var userDto = mapper.Map<UserDto>(user);

        var roles = await signInManager.UserManager.GetRolesAsync(user);
        userDto.Roles = roles ?? [];
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
        var student = await signInManager.UserManager.FindByEmailAsync(register.Email);

        if (student == null)
        {
            var studentForCreation = mapper.Map<StudentForCreationDto>(register);
            studentForCreation.Wallet = 0m;

            var createdStudent = await serviceManager.StudentService.CreateStudentAsync(studentForCreation);
            var studentEntity = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == register.Email);

            await signInManager.UserManager.AddToRoleAsync(studentEntity, UserRole.Student);

            return Ok(createdStudent);
        }
        else
        {
            return BadRequest("Email is Already Exist");
        }
    }
    [HttpGet("check-email")]
    public async Task<ActionResult<bool>> CheckEmailExists([FromQuery] string email)
    {
        return await userManager.FindByEmailAsync(email) != null;
    }

    [HttpGet("check-username")]
    public async Task<ActionResult<bool>> CheckUsernameExists([FromQuery] string username)
    {
        return await userManager.FindByNameAsync(username) != null;
    }
}