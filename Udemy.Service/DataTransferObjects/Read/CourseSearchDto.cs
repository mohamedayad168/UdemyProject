using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read;
public class CourseSearchDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string InstructorName { get; set; }
    public decimal? Rating { get; set; }
    public decimal Duration { get; set; }
    public string CourseLevel { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Goals { get; set; } = new List<string>();
}
