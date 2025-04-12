using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaController(IServiceManager serviceManager, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserSocialMedias(int userId)
        {
            try
            {
                // VerifyUserAccess(userId);

                var socialMedias = await serviceManager.SocialMediaService.GetUserSocialMedias(userId);
                return Ok(socialMedias);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int userId, int id)
        {
            try
            {
                // VerifyUserAccess(userId);

                var socialMedia = await serviceManager.SocialMediaService.GetSocialMedia(id, userId);
                return Ok(socialMedia);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }


            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSocialMedia(

      [FromBody] List<SocialMediaDto> dto)
        {
            try
            {
                var updated = new List<SocialMediaDto>();
                // VerifyUserAccess(userId);
                foreach (var item in dto)
                {
                    updated.Add(await serviceManager.SocialMediaService.CreateSocialMedia(item.UserId, item));
                }


                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(
       int id, int userId,
       [FromBody] List<SocialMediaDto> dto)
        {
            try
            {
                // VerifyUserAccess(userId);
                foreach (var item in dto)
                {
                    await serviceManager.SocialMediaService.UpdateSocialMedia(id, userId, item);
                }


                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int userId, int id)
        {
            try
            {
                //VerifyUserAccess(userId);
                await serviceManager.SocialMediaService.DeleteSocialMedia(id, userId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        private void VerifyUserAccess(int requestedUserId)
        {
            var currentUserId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId) || int.Parse(currentUserId) != requestedUserId)
            {
                throw new UnauthorizedAccessException("You can only access your own social media links");
            }
        }
    }
}
