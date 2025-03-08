using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Update
{
    public class CategoryUDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public required string Name { get; set; }
    }
}
