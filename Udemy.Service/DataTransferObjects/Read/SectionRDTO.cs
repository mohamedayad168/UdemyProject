using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Read
{
  public  class SectionRDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public int NoLessons { get; set; }
        public int CourseId { get; set; }
    }
}
