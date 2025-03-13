namespace Udemy.Service.DataTransferObjects.Read;
public class CartDto
{
    public string StudentUsername { get; set; }
    public int StudentId { get; set; }
    public int Id { get; set; }
    public int? Amount { get; set; }
    public List<CourseRDTO> Courses { get; set; }
}
