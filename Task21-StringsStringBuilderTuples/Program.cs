using System.Diagnostics;
using System.Text;
using Task21_StringsStringBuilderTuples;

internal class Program
{
    private const int Iterations = 10000;

    private static void Main(string[] args)
    {
        TextAnalyzer analyzer = new();
        string sampleText = "C# is a powerful language. C# is also fun! Do you enjoy programming in C#? Learning C# takes practice, but it is rewarding.";

        var result = analyzer.Analyze(sampleText);
        Console.WriteLine(analyzer.BuildReport(result));

        // Benchmark: repeated concatenation allocates a new string on every pass
        Stopwatch concatWatch = Stopwatch.StartNew();
        string concatenated = "";
        for (int i = 0; i < Iterations; i++)
        {
            concatenated += "Test";
        }
        concatWatch.Stop();

        // Benchmark: StringBuilder appends into a single growable buffer
        Stopwatch builderWatch = Stopwatch.StartNew();
        StringBuilder builder = new();
        for (int i = 0; i < Iterations; i++)
        {
            builder.Append("Test");
        }
        builderWatch.Stop();

        Console.WriteLine($"String concatenation: {concatWatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"StringBuilder:        {builderWatch.ElapsedMilliseconds} ms");
    }
}
