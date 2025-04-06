using Microsoft.AspNetCore.Mvc;
using Udemy.Core.Exceptions;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetAllCoursesAsync()
        {
            var courses = await serviceManager.CoursesService.GetAllAsync(false);
            return Ok(courses);
        }
        [HttpGet("category/{id:int}")]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetAllCoursesByCategory([FromRoute] int id)
        {
            var courses = await serviceManager.CoursesService.GetAllByCategoryId(id);
            return Ok(courses);
        }

        [HttpGet("page")]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetPageCoursesAsync([FromQuery] RequestParamter requestParamter)
        {
            var courses = await serviceManager.CoursesService.GetPageAsync(requestParamter, false);
            return Ok(courses);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseRDTO?>> GetCourseByIdAsync([FromRoute] int id, [FromQuery] bool detailed = false)
        {
            if (detailed)
            {
                var courseDetails = await serviceManager.CoursesService.GetCourseDetailsAsync(id, false);
                return Ok(courseDetails);
            }
            var course = await serviceManager.CoursesService.GetByIdAsync(id, false);
            return Ok(course);
        }


        [HttpGet("{title}", Name = "GetCourseByTitle")]
        public async Task<ActionResult<CourseRDTO>> GetCourseByTitleAsync(string title)
        {
            var course = await serviceManager.CoursesService.GetByTitleAsync(title, false) ?? throw new NotFoundException($"couldnt find course with title: {title}");

            return Ok(course);

        }


        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody] CourseCDTO course)
        {
            var courseRDTO = await serviceManager.CoursesService.CreateAsync(course);

            return CreatedAtAction("GetCourseByTitle", new { title = courseRDTO.Title }, courseRDTO);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCourseAsync([FromBody] CourseUDTO courseUDTO)
        {
            var courseRDTO = await serviceManager.CoursesService.UpdateAsync(courseUDTO);
            return CreatedAtAction(nameof(GetCourseByTitleAsync), new { courseRDTO.Title }, courseRDTO);
        }


        [HttpPut("ToggleApproved/{id}")]
        public async Task<IActionResult> ToggleCourseApprovedAsync([FromRoute] int id)
        {
            var updated = await serviceManager.CoursesService.ToggleApprovedAsync(id);

            return updated ? Ok() : BadRequest();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseAsync([FromRoute] int id)
        {
            await serviceManager.CoursesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
