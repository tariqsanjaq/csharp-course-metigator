using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_ExceptionHandling
{
    internal class InvalidAgeException : ValidationException
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
        public InvalidAgeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
