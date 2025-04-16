using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("section/{sectionId}")]
        public async Task<ActionResult<IEnumerable<LessonRDto>>> GetLessonsBySectionId(int sectionId, [FromQuery] bool trackChanges)
        {
            var lessons = await _serviceManager.LessonService.GetLessonsBySectionIdAsync(sectionId, trackChanges);
            return Ok(lessons);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult> CreateLesson([FromBody] LessonCDto lessonCreateDto)
        {
            if (lessonCreateDto == null)
            {
                return BadRequest("Lesson data is null.");
            }

            var isCreated = await _serviceManager.LessonService.CreatelessonAsync(lessonCreateDto);
            if (isCreated)
            {
                return CreatedAtAction(nameof(GetLessonById), new { id = lessonCreateDto.id }, lessonCreateDto);
            }
            return BadRequest("Failed to create lesson.");
        }

        // PUT: api/Lesson/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLesson(int id, [FromBody] LessonUDto lessonUDto)
        {
            

            var isUpdated = await _serviceManager.LessonService.UpdateAsync(id, lessonUDto);
            if (isUpdated)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
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
