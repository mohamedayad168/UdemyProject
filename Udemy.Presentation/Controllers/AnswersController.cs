using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Answer;
using Udemy.Service.DataTransferObjects.Ask;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/users/{userId}/courses/{courseId}/asks/{askId}/answer")]
public class AnswersController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUserCourseAskAnswers(
        int userId , int courseId , int askId , [FromQuery] RequestParamter requestParamter
    )
    {
        var answerDtos = await serviceManager.AnswerService.GetAllUserAskAnswersAsync(
            userId , askId , courseId , false , requestParamter
        );

        return Ok(answerDtos);
    }

    [HttpGet("{answerId:int}" , Name = "GetUserCourseAskAnswers")]
    public async Task<IActionResult> GetUserCourseAskAnswers(
        int userId , int courseId , int askId , int answerId
    )
    {
        var answerDto = await serviceManager.AnswerService.GetUserAskAnswerByIdAsync(
            userId , askId , courseId , answerId
        );

        return Ok(answerDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserCourseAskAnswer(
        AnswerForCreationDto answerForCreationDto , int userId , int courseId , int askId
    )
    {
        var answerDto = await serviceManager.AnswerService.CreateUserAskAnswerAsync(
            answerForCreationDto , courseId , userId , askId
        );

        return CreatedAtAction(
            "GetUserCourseAskAnswers" , new { userId , courseId , askId , answerId = answerDto.Id } , answerDto
        );
    }

    [HttpPut("{answerId:int}")]
    public async Task<IActionResult> UpdateUserCourseAskAnswer(
        AnswerForUpdatingDto answerDto , int userId , int courseId , int askId , int answerId
    )
    {
        await serviceManager.AnswerService.UpdateUserAskAnswerAsync(
            answerDto , courseId , userId , askId , answerId
        );

        return NoContent();
    }

    [HttpDelete("{answerId:int}")]
    public async Task<IActionResult> DeleteUserCourseAskAnswer(
        int userId , int courseId , int askId , int answerId
    )
    {
        await serviceManager.AnswerService.DeleteUserAskAnswerAsync(
            courseId , userId , askId , answerId
        );

        return NoContent();
    }
}
