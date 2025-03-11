using Microsoft.AspNetCore.Mvc;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.API.Controllers
{
    [Route("api/instructors")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorRDTO>>> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync(false);
            return Ok(instructors);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstructorRDTO>> GetById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id, false);
            if (instructor == null)
                return NotFound($"Instructor with ID {id} not found.");

            return Ok(instructor);
        }


        [HttpGet("title/{title}")]
        public async Task<ActionResult<InstructorRDTO>> GetByTitle(string title)
        {
            var instructor = await _instructorService.GetByTitleAsync(title, false);
            if (instructor == null)
                return NotFound($"Instructor with title '{title}' not found.");

            return Ok(instructor);
        }




        [HttpPost]
        public async Task<ActionResult<InstructorRDTO>> Create([FromBody] InstractorCDTO instructorDto)
        {
            if (instructorDto == null)
                return BadRequest("Instructor data is required.");

            var createdInstructor = await _instructorService.CreateAsync(instructorDto);
            return CreatedAtAction(nameof(GetById), new { id = createdInstructor.Id }, createdInstructor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] InstructorUTO instructorDto)
        {
            if (instructorDto == null)
                return BadRequest("Instructor data is required.");

            var isUpdated = await _instructorService.UpdateAsync(id, instructorDto);
            if (!isUpdated)
                return NotFound($"Instructor with ID {id} not found.");

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _instructorService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound($"Instructor with ID {id} not found.");

            return NoContent();
        }
    }
}
