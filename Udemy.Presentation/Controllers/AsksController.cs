using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/users/{userId}/courses/{courseId}/asks")]
public class AsksController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUserCourseAsks(
        int userId , int courseId , [FromQuery]RequestParamter requestParamter
    )
    {
        var askDtos = await serviceManager.AskService.GetAllUserCourseAsksAsync(
            userId, courseId , false , requestParamter
        );

        return Ok(askDtos);
    }

    [HttpGet("{askId:int}", Name = "GetUserCourseAskById")]
    public async Task<IActionResult> GetUserCourseAskById(
        int askId , int userId , int courseId
    )
    {
        var askDto = await serviceManager.AskService.GetUserCourseAskByIdAsync(askId , userId , courseId, false);
        return Ok(askDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserCourseAsk(
        AskForCreationDto askForCreationDto, int userId , int courseId
    )
    {
        var askDto = await serviceManager.AskService.CreateUserCourseAskAsync(askForCreationDto, courseId, userId);

        return CreatedAtAction("GetUserCourseAskById", new {userId , courseId , askId = askDto.Id}, askDto);
    }


    [HttpPut("{askId:int}")]
    public async Task<IActionResult> UpdateUserCourseAsk(
        AskForUpdatingDto askDto, int askId , int userId , int courseId
    )
    {
        await serviceManager.AskService.UpdateUserCourseAskAsync(askDto, courseId, userId, askId);

        return NoContent();
    }


    [HttpDelete("{askId:int}")]
    public async Task<IActionResult> DeleteUserCourseAsk(
        int askId , int userId , int courseId
    )
    {
        await serviceManager.AskService.DeleteUserCourseAskAsync(courseId, userId, askId);

        return NoContent();
    }
}
