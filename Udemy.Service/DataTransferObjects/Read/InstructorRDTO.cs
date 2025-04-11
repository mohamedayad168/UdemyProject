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



    }




}