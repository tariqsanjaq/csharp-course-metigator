using System.Diagnostics;
using Task18_ThreadingAsync;

internal class Program
{
    private static void Main(string[] args)
    {
        FileDownloader fileDownloader = new FileDownloader();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        fileDownloader.MultiFileDownloader();
        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed);

    }
}