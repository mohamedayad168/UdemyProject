using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
  public  class LessonCDto
    {
        public int id { set; get; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int SectionId { get; set; }
    }
}
