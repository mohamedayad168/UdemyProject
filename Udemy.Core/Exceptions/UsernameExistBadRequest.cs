namespace Udemy.Core.Exceptions;
public class UsernameExistBadRequest(string username): BadRequestException($"User with username: {username} already exist.")
{
}
