using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;
using Udemy.Service.Service;

namespace Udemy.Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController(IServiceManager manager) :ControllerBase
    {
        [HttpGet ]
        public async Task<ActionResult<IEnumerable<CategoryRDTO>>> GetAllCategoriesAsync()
        {
            var categories = await manager.CategoriesService.GetAllAsync(false);
            return Ok(categories);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryRDTO>> GetCategoryByIdAsync([FromRoute] int id)
        {
            var category = await manager.CategoriesService.GetByIdAsync(id, false);
            return Ok(category);
        }


        [HttpGet("{title}")]
        [ActionName(nameof(GetCategoryByTitleAsync))]
        public async Task<ActionResult<CategoryRDTO>> GetCategoryByTitleAsync(string title)
        {
            var category = await manager.CategoriesService.GetByTitleAsync(title, false);
            return Ok(category);
        }


        [HttpPost ]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCDTO category)
        {
            var categoryRDTO = await manager.CategoriesService.CreateAsync(category);

            //var url = Url.Action(
            //    action: "CreateAsync",
            //    controller: "Categorys", // Use "Categorys" instead of nameof(CategorysController)
            //    values: new { title = categoryRDTO.Title }
            //  );

            var actionResult= CreatedAtAction(nameof(GetCategoryByTitleAsync), new { title = categoryRDTO.Name }, categoryRDTO);
            
            return actionResult;
        }


        [HttpPut ]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryUDTO categoryUDTO)
        {
            var categoryRDTO = await manager.CategoriesService.UpdateAsync(categoryUDTO);
            return CreatedAtAction(nameof(GetCategoryByTitleAsync), new { categoryRDTO.Name }, categoryRDTO);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {
            await manager.CategoriesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
