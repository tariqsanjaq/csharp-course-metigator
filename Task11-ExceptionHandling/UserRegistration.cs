using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_ExceptionHandling
{

    internal class UserRegistration
    {
        public void Register(string name, string email, string age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Name cannot be empty.");
                
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                // فحص الإيميل
                throw new ValidationException("Email must contain '@'. or cannot be empty.");

            }
            int parsedAge;
            try
            {
                parsedAge = int.Parse(age);
            }
            catch (FormatException ex)
            {
                throw new ValidationException("Age must be a number.", ex);
            }

            if ( parsedAge > 120 ||  parsedAge < 0 )
            {
                
                throw new InvalidAgeException("Age must be between 0 and 120.");

            }
            


            Console.WriteLine($"User registered: {name}");
        }
    }

}
