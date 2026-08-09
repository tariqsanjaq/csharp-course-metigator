using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Implicit cast — never fails, compiler allows it silently
        int z = 32;
        double x = z;
        Console.WriteLine($"Implicit: int z = {z} -> double x = {x}");

        // Explicit cast — truncates, doesn't throw
        double y = 23.34;
        int c = (int)y;
        Console.WriteLine($"Explicit: double y = {y} -> int c = {c} (truncated, not rounded)");

        // Explicit cast "failure" — silent overflow, no exception
        long bigNumber = 5_000_000_000;
        int overflowed = (int)bigNumber;
        Console.WriteLine($"Explicit overflow: long {bigNumber} -> int {overflowed} (wrapped silently, no exception)");

        // Convert class — success
        int r = Convert.ToInt32(y);
        Console.WriteLine($"Convert: double y = {y} -> int r = {r}");

        // Convert class — failure
        try
        {
            int bad2 = Convert.ToInt32("abc");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Convert failed: {ex.Message}");
        }

        // Parse — success
        string t = "123";
        int u = int.Parse(t);
        Console.WriteLine($"Parse: \"{t}\" -> int u = {u}");

        // Parse — failure
        string bad = "abc";
        try
        {
            int result = int.Parse(bad);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Parse failed: {ex.Message}");
        }

        // TryParse — failure handled without a crash
        if (int.TryParse(bad, out int parsed))
        {
            u = parsed;
        }
        else
        {
            Console.WriteLine("TryParse: invalid input handled without an exception");
        }



        // 2
        Console.WriteLine("--------------------------------------------");
        //boxing
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            int unbox = 123;
            object obj = unbox;
        }
        
        sw.Stop();

        //unboxing 
        Stopwatch sw2 = Stopwatch.StartNew();

        for(int i = 0; i < 1000000; i++)
        {
            object box = 23;
            int boxing = (int)box;
        }
        
        sw2.Stop();
        // dirict value type
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            int asd = 123;
            double df = (double)asd;
        }
        stopwatch.Stop();
        // prefomance 
        Console.WriteLine($"unboxing time :{sw}\nboxing time: {sw2}\ndirect value : {stopwatch}");

        Console.WriteLine($"Boxing time: {sw.ElapsedMilliseconds} ms");
    }
}