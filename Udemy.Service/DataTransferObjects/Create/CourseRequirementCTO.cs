using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class CourseRequirementCTO
    {
        [Required]
        [StringLength(255)]
        public string Requirement { get; set; } = string.Empty;

        [Required]
        public int CourseId { get; set; }
    }
}
