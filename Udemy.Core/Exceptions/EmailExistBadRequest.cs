namespace Udemy.Core.Exceptions;
public class EmailExistBadRequest(string email): BadRequestException($"User with Email: {email} already Exist")
{
}
