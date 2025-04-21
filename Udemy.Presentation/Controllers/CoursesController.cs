using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
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
    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;


        public CoursesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;


        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetAllCoursesAsync()
        {
            var courses = await serviceManager.CoursesService.GetAllAsync(false);
            return Ok(courses);
        }
        [HttpGet("category/{id:int}")]


        [HttpGet("page")]
        public async Task<ActionResult<PaginatedRes<CourseRDTO>>> GetPageAsync([FromQuery] PaginatedSearchReq searchReq)
        {
            searchReq.SearchTerm ??= "";
            searchReq.OrderBy ??= "title";




            var paginatedResponse = await serviceManager.CoursesService.GetPageAsync(searchReq, DeletionType.NotDeleted, false);
            return Ok(paginatedResponse);
        }


        [HttpGet("deleted/page")]
        [Authorize(Roles = "Admin, Owner")]
        public async Task<ActionResult<PaginatedRes<CourseRDTO>>> GetDeletedPage([FromQuery] PaginatedSearchReq searchReq)
        {
            var paginatedResponse = await serviceManager.CoursesService.GetPageAsync(searchReq, DeletionType.Deleted, false);
            return Ok(paginatedResponse);
        }




        [HttpGet("search")]
        public async Task<IActionResult> GetCoursesWithSearch([FromQuery] CourseRequestParameter requestParameter)
        {

            var courses = await serviceManager.CoursesService.GetAllWithSearchAsync(requestParameter);

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

        [HttpGet("{id:int}/asks/{askId:int}/answers")]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswersByAskIdAsync([FromRoute] int id, [FromRoute] int askId)
        {
            var answers = await serviceManager.AnswerService.GetAllQuestionAnswersByIdAsync(askId);
            return Ok(answers);
        }


        [HttpGet("{id:int}/asks")]
        public async Task<ActionResult<IEnumerable<AskRDTO>>> GetAsksByCourseIdAsync([FromRoute] int id, [FromQuery] RequestParamter requestParameter)
        {
            var asks = await serviceManager.AskService.GetAsksByCourseIdAsync(id, requestParameter, false);
            return Ok(asks);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Instructor,Owner")]
        public async Task<IActionResult> CreateCourseAsync(CourseCDTO course)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            var Id = int.Parse(userIdClaim);

            if (User.IsInRole("Instructor"))
            {
                if (course.InstructorId != Id)
                    return Forbid("Instructors can only create courses for themselves.");
            }





            var courseRDTO = await serviceManager.CoursesService.CreateAsync(course);

            return CreatedAtAction("GetCourseByTitle", new { title = courseRDTO.Title }, courseRDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Instructor,Owner")]
        public async Task<IActionResult> UpdateCourseAsync([FromRoute] int id, [FromForm] CourseUDTO courseUDTO)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            var Id = int.Parse(userIdClaim);

            if (User.IsInRole("Instructor"))
            {
                if (courseUDTO.InstructorId != Id)
                    return NotFound("Instructors can only create courses for themselves.");
            }
            courseUDTO.Id = id; // ensure ID is set correctly
            var courseRDTO = await serviceManager.CoursesService.UpdateAsync(courseUDTO);
            return Ok(courseRDTO);
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
            var course = await serviceManager.CoursesService.GetByIdAsync(id, true);
            if (course == null)
                return NotFound(new { message = "Course not found." });

            var instructor = await serviceManager.InstructorService.GetByIdAsync(course.InstructorId, true);
            if (instructor == null)
                return NotFound(new { message = "Instructor not found." });

            await serviceManager.CoursesService.DeleteAsync(id);

            instructor.TotalCourses -= 1;
            var instructorUpdated = await serviceManager.InstructorService.UpdateAsync(instructor.Id.Value, new InstructorUTO
            {
                TotalCourses = instructor.TotalCourses
            });

            if (!instructorUpdated)
                return BadRequest(new { message = "Failed to update instructor." });

            return NoContent();
        }



        [HttpGet("subcategories/{subcategoryId}/courses")]
        public async Task<ActionResult<CourseRDTO>> GetCoursesBySubcategory(int subcategoryId)
        {
            var courses = await serviceManager.CoursesService.GetAllBySubcategoryId(subcategoryId);
            if (courses == null || !courses.Any())
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("check-title")]
        public async Task<bool> TitleExist([FromQuery] string title)
        {
            var exist = await serviceManager.CoursesService.GetByTitleForValidation(title, false);
            return exist;

        }
    }
}



