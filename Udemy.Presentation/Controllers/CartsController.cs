using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Core.Utils;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/Students/{studentId}/Carts")]
[Authorize(Roles = UserRole.Student)]
public class CartsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("/api/Carts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllStudentsCarts([FromQuery]RequestParamter requestParamter)
    {
        var carts = await serviceManager.CartService.GetAllStudentsCartsAsync(false, requestParamter);

        return Ok(carts);
    }

    [HttpGet(Name = "GetStudentCart")]
    public async Task<IActionResult> GetStudentCart(int studentId)
    {
        var studentCart = await serviceManager.CartService.GetStudentCartAsync(studentId, false);
        return Ok(studentCart);
    }

    [HttpPost("{courseId}")]
    public async Task<IActionResult> AddCourseToStudentCart(int courseId, int studentId)
    {
        await serviceManager.CartService.AddCourseToStudentCartAsync(courseId, studentId);

        return NoContent();
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourseFromStudentCart(int courseId, int studentId)
    {
        await serviceManager.CartService.DeleteCourseFromStudentCartAsync(courseId, studentId);

        return NoContent();
    }
}
