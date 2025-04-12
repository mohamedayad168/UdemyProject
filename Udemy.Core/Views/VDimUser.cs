using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class VDimUser
    {
        [Key]
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CountryName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public int? HasFacebook { get; set; }
        public int? HasLinkedin { get; set; }
        public int? HasX { get; set; }
        public int? HasInstegram { get; set; }
        public string? Title { get; set; }
        public string? Bio { get; set; }
        public decimal? Wallet { get; set; }
        public int? IsStudent { get; set; }
        public int? IsInstructor { get; set; }
        public int? IsAdmin { get; set; }
    }
}
