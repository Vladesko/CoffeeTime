using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Comons.Exceptions
{
    public class UserNotFoundException(string message) : Exception(message)
    {
    }
}
