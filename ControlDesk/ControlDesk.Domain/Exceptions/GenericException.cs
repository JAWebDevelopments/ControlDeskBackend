using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Domain.Exceptions
{
    public class GenericException: Exception
    {
        public GenericException() { }
        public GenericException(string message) : base(message) { }
        public GenericException(string message, Exception innerException) : base(message, innerException) { }
    }
}
