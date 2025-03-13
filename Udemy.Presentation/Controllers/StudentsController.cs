using Microsoft.AspNetCore.Mvc;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;


namespace Udemy.Presentations.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStudents([FromQuery] RequestParamter? requestParamter)
    {
        var studentsDto = await serviceManager.StudentService.GetAllStudentAsync(false , requestParamter);
        return Ok(studentsDto);
    }

    [HttpGet("{id}", Name = "GetStudentById")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var studentDto = await serviceManager.StudentService.GetStudentByIdAsync(id , false);

        return Ok(studentDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentForCreationDto studentDto)
    {
        var student = await serviceManager.StudentService.CreateStudentAsync(studentDto);

        return CreatedAtAction("GetStudentById" , new { id = student.Id } , student);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStudent(int id , StudentForUpdatingDto studentDto)
    {
        await serviceManager.StudentService.UpdateStudentAsync(id , studentDto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await serviceManager.StudentService.DeleteStudentAsync(id);

        return NoContent();
    }
}