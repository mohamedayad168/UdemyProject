using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class Quiz : BaseEntity
    {
        public Course Course { get; set; }
        [Column(TypeName ="Course_Id")]
        public int CourseId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }

        public List<QuizQuestion> QuizQuestion { get; set; } = new List<QuizQuestion>();
    }
}
