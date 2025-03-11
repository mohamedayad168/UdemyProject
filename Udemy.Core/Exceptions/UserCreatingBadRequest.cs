namespace Udemy.Core.Exceptions;
public class UserCreatingBadRequest(string message): BadRequestException(message)
{
}
