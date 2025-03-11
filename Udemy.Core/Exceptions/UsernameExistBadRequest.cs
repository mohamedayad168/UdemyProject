namespace Udemy.Core.Exceptions;
public class UsernameExistBadRequest(string username): BadRequestException($"username: {username} already exist.")
{
}
