using StringUtilities;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Tariq.StringUtilities 1.0.0 ===");
        Console.WriteLine("Consumed as a NuGet package from LocalFeed.\n");

        Console.WriteLine("--- ToSlug ---");
        Console.WriteLine($"\"Hello, World!\"   -> \"{"Hello, World!".ToSlug()}\"");
        Console.WriteLine($"\"C# Task 17\"      -> \"{"C# Task 17".ToSlug()}\"");

        Console.WriteLine("\n--- IsValidEmail ---");
        Console.WriteLine($"\"tariq@gmail.com\" -> {"tariq@gmail.com".IsValidEmail()}");
        Console.WriteLine($"\"tariq@gmail\"     -> {"tariq@gmail".IsValidEmail()}");

        Console.WriteLine("\n--- ToTitleCase ---");
        Console.WriteLine($"\"tariq sanjaq\"    -> \"{"tariq sanjaq".ToTitleCase()}\"");
        Console.WriteLine($"\"HELLO WORLD\"     -> \"{"HELLO WORLD".ToTitleCase()}\"");

        Console.WriteLine("\n--- Truncate ---");
        Console.WriteLine($"\"The quick brown fox\", 10 -> \"{"The quick brown fox".Truncate(10)}\"");
        Console.WriteLine($"\"Short\", 10               -> \"{"Short".Truncate(10)}\"");
    }
}