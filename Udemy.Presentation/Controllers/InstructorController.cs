﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Utils;
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
        private readonly IServiceManager _serviceManager;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public InstructorController(IServiceManager serviceManager, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _serviceManager = serviceManager;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorRDTO>>> GetAll()
        {
            var instructors = await _serviceManager.InstructorService.GetAllAsync(false);
            return Ok(instructors);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstructorRDTO>> GetById(int id)
        {
            var instructor = await _serviceManager.InstructorService.GetByIdAsync(id, false);
            if (instructor == null)
                return NotFound($"Instructor with ID {id} not found.");

            return Ok(instructor);
        }


        [HttpGet("title/{title}")]
        public async Task<ActionResult<InstructorRDTO>> GetByTitle(string title)
        {
            var instructor = await _serviceManager.InstructorService.GetByTitleAsync(title, false);
            if (instructor == null)
                return NotFound($"Instructor with title '{title}' not found.");

            return Ok(instructor);
        }




        [HttpPost("create")]
        public async Task<ActionResult<Instructor>> Create([FromBody] InstructorCDTO instructorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (instructorDto == null)
                return BadRequest("Instructor data is required.");

            var createdInstructor = await _serviceManager.InstructorService.CreateAsync(instructorDto);
            var instructor = await signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.Email == createdInstructor.Email);
            await signInManager.UserManager.UpdateSecurityStampAsync(instructor);
            await userManager.AddPasswordAsync(instructor, instructorDto.Password);
            await userManager.AddToRoleAsync(instructor, UserRole.Instructor);



            return CreatedAtAction(nameof(GetById), new { id = createdInstructor.Id }, instructor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] InstructorUTO instructorDto)
        {
            if (instructorDto == null)
                return BadRequest("Instructor data is required.");

            var isUpdated = await _serviceManager.InstructorService.UpdateAsync(id, instructorDto);
            if (!isUpdated)
                return NotFound($"Instructor with ID {id} not found.");

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _serviceManager.InstructorService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound($"Instructor with ID {id} not found.");

            return NoContent();
        }
        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<Instructor>> GetInstructorDetails(int instructorId)
        {
            var instructor = await _serviceManager.InstructorService.GetInstructorDetails(instructorId);
            if (instructor == null)
            {
                return NotFound("Instructor not found");
            }

            return Ok(instructor);
        }

        [HttpGet("{instructorId:int}/courses")]
        public async Task<ActionResult<IEnumerable<CourseRDTO>>> GetInstructorCourses(int instructorId)
        {
            var courses = await _serviceManager.InstructorService.GetCoursesByInstructor(instructorId);

            if (courses == null || !courses.Any())
            {
                return NotFound("No courses found for the instructor");
            }

            return Ok(courses);
        }

        [HttpGet("check-email")]
        public async Task<ActionResult<bool>> CheckEmailExists([FromQuery] string email)
        {
            return await userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("check-username")]
        public async Task<ActionResult<bool>> CheckUsernameExists([FromQuery] string username)
        {
            return await userManager.FindByNameAsync(username) != null;
        }

    }
}
