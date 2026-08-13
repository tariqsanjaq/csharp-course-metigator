using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_ExceptionHandling
{
    internal class ValidationException : AppException
    {
        public ValidationException(string message) : base(message)
        {
            
        }
        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
