using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CourseRequirement:BaseEntity
    {
        public int CourseId { get; set; }
        public required string Requirement { get; set; }
        public Course Course { get; set; }
    }
}
