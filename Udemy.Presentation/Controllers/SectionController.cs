using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SectionController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetSectionsByCourseId(int courseId, [FromQuery] bool trackChanges)
        {
            var sections = await _service.SectionService.GetSectionsByCourseIdAsync(courseId, trackChanges);
            if (sections == null || !sections.Any())
            {
                return NotFound("No sections found for the specified course.");
            }

            return Ok(sections);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSections()
        {
            var sections = await _service.SectionService.GetAllAsync(trackChanges: false);
            return Ok(sections);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var section = await _service.SectionService.GetByIdAsync(id, trackchange: false);
            if (section == null)
                return NotFound();

            return Ok(section);
        }


        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> CreateSection([FromBody] SectionCDTO sectioncDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SectionService.CreateSectionAsync(sectioncDto);


            return Ok(result);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateSection(int id, [FromBody] SectionUDTO sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SectionService.UpdateAsync(id, sectionDto);
            if (!result)
                return NotFound();

            return Ok(sectionDto);
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var result = await _service.SectionService.DeleteSectionAsync(id);
            if (!result)
                return NotFound();

            return Ok("Section deleted successfully");
        }
    }
}


