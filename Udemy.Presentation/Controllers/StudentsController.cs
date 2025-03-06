using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Service.IService;


namespace Udemy.Presentations.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController(IServiceManager serviceManager) : ControllerBase
{
    //?page=10&size=20
    [HttpGet]
    public async Task<IActionResult> GetAllStudents([FromQuery] RequestParamter? requestParamter)
    {
        var studentsDto = await serviceManager.StudentService.GetAllStudentAsync(false , requestParamter);
        return Ok(studentsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var studentDto = await serviceManager.StudentService.GetStudentByIdAsync(id , false);
        return Ok(studentDto);
    }
}