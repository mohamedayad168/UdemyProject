using Microsoft.AspNetCore.Mvc;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;
using Udemy.Service.Service;

namespace Udemy.Presentation.Controllers
{
    public class SectionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SectionController(IServiceManager service)
        {
            _service = service;
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
        public async Task<IActionResult> CreateSection([FromBody] SectionCDTO sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SectionService.CreateSectionAsync(sectionDto);
            if (!result)
                return StatusCode(500, "Failed to create section");

            return Ok("Section created successfully");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(int id, [FromBody] SectionUDTO sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SectionService.UpdateAsync(id, sectionDto);
            if (!result)
                return NotFound();

            return Ok("Section updated successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var result = await _service.SectionService.DeleteSectionAsync(id);
            if (!result)
                return NotFound();

            return Ok("Section deleted successfully");
        }
    }
}


