using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet(Name = "GetAllAsync")]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetAllAsync()
        {
            var courses = await serviceManager.CoursesService.GetAllAsync(false);
            return Ok(courses);
        }


        [HttpGet("page", Name = "GetPageAsync")]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetPageAsync([FromQuery] RequestParamter requestParamter)
        {
            var courses = await serviceManager.CoursesService.GetPageAsync(requestParamter, false);
            return Ok(courses);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseRDTO?>> GetByIdAsync([FromRoute] int id)
        {
            var course = await serviceManager.CoursesService.GetByIdAsync(id, false);
            return Ok(course);
        }


        [HttpGet("{title}", Name = "GetByTitleAsync")]
        public async Task<ActionResult<CourseRDTO>> GetByTitleAsync(string title)
        {
            var course = await serviceManager.CoursesService.GetByTitleAsync(title, false);
            return Ok(course);
        }


        [HttpPost(Name = "CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] CourseCDTO course)
        {
            var courseRDTO = await serviceManager.CoursesService.CreateAsync(course);

            //var url = Url.Action(
            //    action: "CreateAsync",
            //    controller: "Courses", // Use "Courses" instead of nameof(CoursesController)
            //    values: new { title = courseRDTO.Title }
            //  );

            return CreatedAtAction(nameof(GetByTitleAsync), new { courseRDTO.Title }, courseRDTO);
        }


        [HttpPut(Name = "UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CourseUDTO courseUDTO)
        {
            var courseRDTO = await serviceManager.CoursesService.UpdateAsync(courseUDTO);
            return CreatedAtAction(nameof(GetByTitleAsync), new { courseRDTO.Title }, courseRDTO);
        }


        [HttpPut("ToggleApproved/{id}", Name = "ToggleApprovedAsync")]
        public async Task<IActionResult> ToggleApprovedAsync([FromRoute] int id)
        {
            var updated = await serviceManager.CoursesService.ToggleApprovedAsync(id);

            return updated ? Ok() : BadRequest();

        }


        [HttpDelete("{id}", Name = "DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await serviceManager.CoursesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
