using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class InstructorRDTO
    {

        public int? Id { get; set; }



        public string Email { get; set; }

        public string UserName { get; set; }



        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Bio { get; set; }

     
        public string Name { get; set; }



        public int? TotalCourses { get; set; }
        public int? TotalReviews { get; set; }
        public int? TotalStudents { get; set; }


    }




}