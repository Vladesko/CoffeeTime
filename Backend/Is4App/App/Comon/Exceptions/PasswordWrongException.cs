using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Comon.Exceptions
{
    public class PasswordWrongException : Exception
    {
        public PasswordWrongException(string message) : base(message)
        {

        }
    }
}
