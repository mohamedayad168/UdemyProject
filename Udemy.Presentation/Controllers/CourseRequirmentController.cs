using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.IService;

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

      
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourseRequirement(int id)
        {
            var requirement = await _courseRequirementRepository.GetRequirementByIdAsync(id, trackChanges: false);
            if (requirement == null)
                return NotFound($"No course requirement found with ID {id}.");

            return Ok(requirement);
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
            return CreatedAtAction(nameof(GetCourseRequirement), new { id = requirement.CourseId }, requirement);
        }

     
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourseRequirement(int id)
        {
            var requirement = await _courseRequirementRepository.GetRequirementByIdAsync(id, trackChanges: true);
            if (requirement == null)
                return NotFound($"No course requirement found with ID {id}.");

            await _courseRequirementRepository.DeleteRequirementAsync(requirement);
            return NoContent();
        }
    }
}