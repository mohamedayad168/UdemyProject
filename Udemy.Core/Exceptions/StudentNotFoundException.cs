namespace Udemy.Core.Exceptions;
public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException(string message) : base(message)
    {
    }
}
