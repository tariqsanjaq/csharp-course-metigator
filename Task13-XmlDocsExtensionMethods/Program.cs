using System;

namespace Task13_XmlDocsExtensionMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== ToTitleCase ===");
            Console.WriteLine($"\"tariq sanjaq\"  -> \"{"tariq sanjaq".ToTitleCase()}\"");
            Console.WriteLine($"\"HELLO WORLD\"   -> \"{"HELLO WORLD".ToTitleCase()}\"");
            Console.WriteLine($"null            -> \"{((string?)null).ToTitleCase()}\"");

            Console.WriteLine("\n=== Truncate ===");
            Console.WriteLine($"\"The quick brown fox\", 10 -> \"{"The quick brown fox".Truncate(10)}\"");
            Console.WriteLine($"\"Short\", 10               -> \"{"Short".Truncate(10)}\"");
            Console.WriteLine($"\"Anything\", 2             -> \"{"Anything".Truncate(2)}\"");

            try
            {
                "Anything".Truncate(-1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            Console.WriteLine("\n=== IsValidEmail ===");
            Console.WriteLine($"\"tariq@bestdev.com\" -> {"tariq@bestdev.com".IsValidEmail()}");
            Console.WriteLine($"\"tariq@bestdev\"     -> {"tariq@bestdev".IsValidEmail()}");
            Console.WriteLine($"\"not an email\"      -> {"not an email".IsValidEmail()}");

            Console.WriteLine("\n=== ToSlug ===");
            Console.WriteLine($"\"Hello World!\"            -> \"{"Hello World!".ToSlug()}\"");
            Console.WriteLine($"\"  C#  Course --- Task 13 \" -> \"{"  C#  Course --- Task 13 ".ToSlug()}\"");
            Console.WriteLine($"\"Café Münchén\"            -> \"{"Café Münchén".ToSlug()}\"");

            Console.WriteLine("\n=== Instance methods always win ===");
            // string already has ToUpper(). If we had written an extension
            // with the same name and signature, the built-in one would run.
            Console.WriteLine("tariq".ToUpper());
        }
    }
}