using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
  public class InstractorCDTO
    {
        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(50)]
        public string? Bio { get; set; }
    }
}
