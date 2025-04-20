using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;
using Udemy.Service.Service;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Owner")]
    public class AdminsController(SignInManager<ApplicationUser> signInManager, IServiceManager serviceManager) : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Forbid();
        }




        [HttpGet("page")]
        public async Task<ActionResult<PaginatedRes<UserDto>>> GetPage([FromQuery]PaginatedSearchReq searchReq)
        {
            searchReq.SearchTerm ??= "";
            searchReq.OrderBy ??= "title";

            var paginatedResponse = await serviceManager.UserService.GetRoleUsersPageAsync(searchReq,"Admin", DeletionType.NotDeleted, false);
            return Ok(paginatedResponse);
        }


        [HttpPost("")]
        public async Task<IActionResult> Register([FromForm] UserForCreationDto user)
        {
            var admin = await signInManager.UserManager.FindByEmailAsync(user.Email);

            if (admin is not null) return BadRequest($"Email '{admin.Email}' Already Exists");

            await serviceManager.UserService.CreateUserAsync(user,"Admin");

            return Ok( );

        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await serviceManager.UserService.DeleteUserAsync(id);

            return Ok( );

        }
    }
}
