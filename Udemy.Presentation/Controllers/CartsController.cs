using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/Students/{studentId}/Carts")]
public class CartsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("/api/Carts")]
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

    [HttpPost]
    public async Task<IActionResult> CreateStudentCart(CartForCreationDto cartDto, int studentId)
    {
        var studentCart = await serviceManager.CartService.CreateStudentCartAsync(cartDto, studentId);
        return CreatedAtAction("GetStudentCart", new { studentId }, studentCart);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudentCart(CartForUpdatingDto cartDto, int studentId)
    {
        await serviceManager.CartService.UpdateStudentCartAsync(cartDto, studentId);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudentCart(int studentId)
    {
        await serviceManager.CartService.DeleteStudentCartAsync(studentId);

        return NoContent();
    }
}
