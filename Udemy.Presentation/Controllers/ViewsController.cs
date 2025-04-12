using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewsController(ApplicationDbContext context):ControllerBase
    {
        [HttpGet("VSupDimSection")]
        public async Task<IActionResult> GetVSupDimSection()
        {
            var data = await context.VSupDimSection.ToListAsync();
            return Ok(data);
        }



        [HttpGet("VDimcourse")]
        public async Task<IActionResult> GetVDimcourse()
        {
            var data = await context.VDimcourse.ToListAsync();
            return Ok(data);
        }



        [HttpGet("VDimUser")]
        public async Task<IActionResult> GetVDimUser()
        {
            var data = await context.VDimUser.ToListAsync();
            return Ok(data);
        }



        [HttpGet("VSupDimQuiz")]
        public async Task<IActionResult> GetVSupDimQuiz()
        {
            var data = await context.VSupDimQuiz.ToListAsync();
            return Ok(data);
        }



        [HttpGet("vw_FactCart")]
        public async Task<IActionResult> Getvw_FactCart()
        {
            var data = await context.vw_FactCart.ToListAsync();
            return Ok(data);
        }



        [HttpGet("vw_FactEnrollment")]
        public async Task<IActionResult> Getvw_FactEnrollment()
        {
            var data = await context.vw_FactEnrollment.ToListAsync();
            return Ok(data);
        }



        [HttpGet("vw_FactOrder")]
        public async Task<IActionResult> Getvw_FactOrder()
        {
            var data = await context.vw_FactOrder.ToListAsync();
            return Ok(data);
        }
    }
}
