namespace Udemy.Service.DataTransferObjects.Create;
public class CartForCreationDto
{
    public List<int> CourseIds { get; set; } = new List<int>();
}

/* the cart entity contains the following properties :
- studentId : will come from route
- student : no need
- id : will be created automatically
- amount : computed
- cartCourse : no need
 */