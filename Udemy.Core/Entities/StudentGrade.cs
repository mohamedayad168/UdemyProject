using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class StudentGrade: BaseEntityWithoutId
{

    public int StudentId { get; set; } 
    
    public int QuizId { get; set; } 

    [Required] 
    [Column(TypeName = "decimal(8,2)")] 
    public decimal Grade { get; set; }

    //[Required] 
    //public DateTime CreatedDate { get; set; }

    //public DateTime? ModifiedDate { get; set; } 

    //public bool IsDeleted { get; set; } = false;

    // Navigation Properties (Assuming Student & Quiz Tables Exist)
    public Student Student { get; set; }
    public Quiz Quiz { get; set; }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Udemy.Core.Entities
//{
//    public class StudentGrade
//    {
//        public Quiz Quiz { get; set; }
//        [Key]
//        [Column(TypeName = "Quiz_Id")]
//        public int QuizId { get; set; }
//        public Student Student { get; set; }
//        [Key]
//        [Column(TypeName = "Student_Id")]
//        public int StudentId { get; set; }
//        [Column(TypeName = "decimal(8,2)")]
//        public decimal Grade { get; set; }
//    }
//}
