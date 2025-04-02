using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class SubCategoryCDTO
    {
        [StringLength(20)]
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    
    }


}
