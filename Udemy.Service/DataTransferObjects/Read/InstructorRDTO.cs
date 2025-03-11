using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class InstructorRDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Bio { get; set; }
        public int? TotalCourses { get; set; }
        public int? TotalReviews { get; set; }
        public int? TotalStudents { get; set; }
        public decimal Wallet { get; set; }
    }
}