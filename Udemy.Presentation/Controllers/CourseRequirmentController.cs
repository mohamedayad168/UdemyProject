using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Presentation.Controllers
{
    [Route("api/courserequirements")]
    [ApiController]
    public class CourseRequirementController : ControllerBase
    {
        private readonly ICourseRequirementRepo _courseRequirementRepository;

        public CourseRequirementController(ICourseRequirementRepo courseRequirementRepository)
        {
            _courseRequirementRepository = courseRequirementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourseRequirements()
        {
            var requirements = await _courseRequirementRepository.GetAllRequirementsAsync(trackChanges: false);
            return Ok(requirements);
        }

        [HttpGet("{requirement}/{courseId:int}")]
        public async Task<IActionResult> GetCourseRequirement(string requirement, int courseId)
        {
            var req = await _courseRequirementRepository.GetRequirementByIdAsync(requirement, courseId, trackChanges: false);
            if (req == null)
                return NotFound($"No requirement '{requirement}' found for Course ID {courseId}.");

            return Ok(req);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<IActionResult> GetRequirementsByCourseId(int courseId)
        {
            var requirements = await _courseRequirementRepository.GetRequirementsByCourseIdAsync(courseId, trackChanges: false);
            return Ok(requirements);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseRequirement([FromBody] CourseRequirement requirement)
        {
            if (requirement == null)
                return BadRequest("Requirement data is null.");

            await _courseRequirementRepository.CreateRequirementAsync(requirement);
            return CreatedAtAction(nameof(GetCourseRequirement),
                new { requirement = requirement.Requirement, courseId = requirement.CourseId },
                requirement);
        }

        [HttpDelete("{requirement}/{courseId:int}")]
        public async Task<IActionResult> DeleteCourseRequirement(string requirement, int courseId)
        {
            var req = await _courseRequirementRepository.GetRequirementByIdAsync(requirement, courseId, trackChanges: true);
            if (req == null)
                return NotFound($"No requirement '{requirement}' found for Course ID {courseId}.");

            await _courseRequirementRepository.SoftDeleteRequirementAsync(requirement, courseId);
            return NoContent();
        }
    }
}
