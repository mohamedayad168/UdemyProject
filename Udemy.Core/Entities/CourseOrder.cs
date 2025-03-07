using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CourseOrder
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
