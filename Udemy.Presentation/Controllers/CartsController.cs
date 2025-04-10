using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Core.ReadOptions;
using Udemy.Core.Utils;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/Carts")]
[Authorize(Roles = UserRole.Student)]
public class CartsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("/api/all-carts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllStudentsCarts([FromQuery]RequestParamter requestParamter)
    {
        var carts = await serviceManager.CartService.GetAllStudentsCartsAsync(false, requestParamter);

        return Ok(carts);
    }

    [HttpGet(Name = "GetStudentCart")]
    [AllowAnonymous]
    public async Task<IActionResult> GetStudentCart()
    {
        if (User.Identity?.IsAuthenticated == false)
            return NoContent();

        int studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var studentCart = await serviceManager.CartService.GetStudentCartAsync(studentId, false);

        return Ok(studentCart);
    }

    [HttpPost]
    public async Task<IActionResult> AddCourseToStudentCart(int courseId)
    {
        int studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        await serviceManager.CartService.AddCourseToStudentCartAsync(courseId, studentId);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourseFromStudentCart(int courseId)
    {
        int studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        await serviceManager.CartService.DeleteCourseFromStudentCartAsync(courseId, studentId);

        return NoContent();
    }
}
