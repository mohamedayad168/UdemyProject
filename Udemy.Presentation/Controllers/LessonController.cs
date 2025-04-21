using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public LessonController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonRDto>>> GetAllLessons([FromQuery] bool trackChanges)
        {
            var lessons = await _serviceManager.LessonService.GetAllAsync(trackChanges);
            return Ok(lessons);
        }

        // GET: api/Lesson/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonRDto>> GetLessonById(int id, [FromQuery] bool trackChanges)
        {
            var lesson = await _serviceManager.LessonService.GetByIdAsync(id, trackChanges);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        // GET: api/Lesson/section/{sectionId}
        [Authorize(Roles = "Instructor")]
        [HttpGet("section/{sectionId}")]
        public async Task<ActionResult<IEnumerable<LessonRDto>>> GetLessonsBySectionId(int sectionId, [FromQuery] bool trackChanges)
        {
            var lessons = await _serviceManager.LessonService.GetLessonsBySectionIdAsync(sectionId, trackChanges);
            return Ok(lessons);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonCDto lessonCDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _serviceManager.LessonService.CreatelessonAsync(lessonCDto);
                if (result == null)
                    return StatusCode(500, "Failed to create lesson");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // PUT: api/Lesson/{id}
        [HttpPut]
        [Authorize(Roles = "Instructor")]
        public async Task<ActionResult> UpdateLesson(LessonUDto lessonUDto)
        {

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var InstructorId = await _serviceManager.LessonService.GetLessonInstructorId(lessonUDto.Id);
            if (userId == InstructorId)
            {
                var isUpdated = await _serviceManager.LessonService.UpdateAsync(lessonUDto.Id, lessonUDto);
                if (isUpdated)
                {
                    return NoContent();
                }

                return NotFound();
            }
            return NotFound();

        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            var lesson = await _serviceManager.LessonService.GetByIdAsync(id, trackchange: false);
            if (lesson == null)
            {
                return NotFound();
            }

            var isDeleted = await _serviceManager.LessonService.DeletelesssonAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return BadRequest("Failed to delete the lesson.");
        }
    }
}
