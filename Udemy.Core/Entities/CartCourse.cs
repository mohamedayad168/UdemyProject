using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CartCourse
    {
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
