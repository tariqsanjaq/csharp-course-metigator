using Task06_OperatorOverloadingFinalizer;

class Program
{
    static void Main(string[] args)
    {
        Money m1 = new Money();           // default: 0 JD
        Money m2 = new Money(50, "JD");
        Money m3 = new Money(90, "US");
        Money m4 = new Money(50, "JD");

        // Addition / subtraction (same currency)
        Money m5 = m1 + m2;
        Console.WriteLine($"m1 + m2 = {m5.Amount} {m5.Currency}");

        Money m6 = m2 - m4;
        Console.WriteLine($"m2 - m4 = {m6.Amount} {m6.Currency}");

        // Comparisons
        Console.WriteLine($"m1 == m4: {m1 == m4}");
        Console.WriteLine($"m2 != m4: {m2 != m4}");
        Console.WriteLine($"m1 < m4: {m1 < m4}");
        Console.WriteLine($"m2 > m4: {m2 > m4}");

        // Currency mismatch — demonstrates CheckCurrency actually working
        
            Money mError = m1 + m3;

        Console.WriteLine("\n\n-----------------------------------------------");

        // Finalizer / GC demo
        CreateAndDiscardMoney();

        Console.WriteLine("Forcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Done.");
    }

    static void CreateAndDiscardMoney()
    {
        Money temp = new Money(50, "USD");
        // temp goes out of scope when this method returns —
        // nothing references it anymore after that
    }
}