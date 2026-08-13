using Task12_EnumeratorsIterators;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\n--- Comparison ---");
        Console.WriteLine("Manual: ~45 lines, nested enumerator class, manual state tracking (_index).");
        Console.WriteLine("Yield:  ~6 lines, compiler generates the state machine automatically.");
        Console.WriteLine("Same output — yield is syntactic sugar over the manual pattern.");

        Console.WriteLine("=== Manual ===");
        foreach (int n in new NumberRange(5, 4))
            Console.WriteLine(n);

        Console.WriteLine("\n=== Yield ===");
        foreach (int n in new NumberRangeYield(5, 4))
            Console.WriteLine(n);
    }
}