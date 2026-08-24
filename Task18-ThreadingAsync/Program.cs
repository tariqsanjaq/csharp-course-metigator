using System.Diagnostics;
using Task18_ThreadingAsync;

internal class Program
{
    private static async Task Main(string[] args)
    {
        FileDownloader fileDownloader = new FileDownloader();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        fileDownloader.MultiFileDownloader();
        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed);

        AsyncFileDownloader asyncFileDownloader = new AsyncFileDownloader();
        Stopwatch stopwatch2 = new Stopwatch();
        stopwatch2.Start();
        await asyncFileDownloader.MultiFileDownloader();
        stopwatch2.Stop();

        Console.WriteLine(stopwatch2.Elapsed);
    }
}