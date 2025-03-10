using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Exceptions;
public class UserNotFoundException(string message): NotFoundException(message)
{
}
