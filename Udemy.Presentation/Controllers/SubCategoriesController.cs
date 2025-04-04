using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/subcategories")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SubCategoriesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var subCategories = await _service.SubCategoriesService.GetAllAsync(false);
            return Ok(subCategories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var subCategory = await _service.SubCategoriesService.GetByIdAsync(id, false);
            return Ok(subCategory);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetSubCategoryByTitle(string title)
        {
            var subCategory = await _service.SubCategoriesService.GetByTitleAsync(title, false);
            return Ok(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryCDTO subCategory)
        {
            if (subCategory == null)
            {
                return BadRequest("SubCategory object is null");
            }

            var createdSubCategory = await _service.SubCategoriesService.CreateAsync(subCategory);
            return CreatedAtAction(nameof(GetSubCategoryById), new { id = createdSubCategory.Id }, createdSubCategory);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSubCategory(int id, [FromBody] SubCategoryUDTO subCategory)
        {
            if (subCategory == null)
            {
                return BadRequest("SubCategory object is null");
            }

            await _service.SubCategoriesService.UpdateAsync(subCategory);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            await _service.SubCategoriesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
