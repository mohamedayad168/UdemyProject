using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetAllAsync()
        {
            var courses = await serviceManager.CoursesService.GetAllAsync(false);
            return Ok(courses);
        }


        [HttpGet("page")]
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


        [HttpGet("{title:alpha}")]
        public async Task<ActionResult<CourseRDTO?>> GetByTitleAsync([FromRoute] string title)
        {
            var course = await serviceManager.CoursesService.GetByTitleAsync(title, false);
            return Ok(course);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CourseCDTO course)
        {
            var id = await serviceManager.CoursesService.CreateAsync(course);
            return Created("/api/courses/" + id, course);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CourseUDTO course)
        {
            await serviceManager.CoursesService.UpdateAsync(course);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await serviceManager.CoursesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
