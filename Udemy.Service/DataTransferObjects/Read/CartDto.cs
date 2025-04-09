namespace Udemy.Service.DataTransferObjects.Read;
public class CartDto
{
    public int StudentId { get; set; }
    public List<CourseRDTO> Courses { get; set; }
}
