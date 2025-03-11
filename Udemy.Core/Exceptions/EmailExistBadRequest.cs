namespace Udemy.Core.Exceptions;
public class EmailExistBadRequest(string email): BadRequestException($"Email: {email} already Exist")
{
}
