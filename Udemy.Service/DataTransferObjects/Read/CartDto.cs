namespace Udemy.Service.DataTransferObjects.Read;
public class CartDto
{
    public int StudentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
    public List<CourseRDTO> Courses { get; set; }
}
