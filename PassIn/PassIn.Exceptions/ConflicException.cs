using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Exceptions
{
    public class ConflicException : Exception
    {
        public ConflicException(string message) : base(message)
        {

        }
    }
}
