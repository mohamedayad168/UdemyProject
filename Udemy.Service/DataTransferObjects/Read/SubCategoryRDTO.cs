using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class SubCategoryRDTO
    {
        public SubCategoryRDTO()
        {
            
        }
        public SubCategoryRDTO(SubCategory subCategory)
        {
            Id = subCategory.Id;
            Name = subCategory.Name;
            Category = new CategoryRDTO()
            {
                Id = subCategory.Category.Id,
                Name = subCategory.Category.Name
            };
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public  string Name { get; set; }
        
        public CategoryRDTO Category { get; set; }

    }



}
