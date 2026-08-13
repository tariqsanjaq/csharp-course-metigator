using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_ExceptionHandling
{
    internal class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
            
        }
        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }



    }
}
