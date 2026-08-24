using System;
using System.Collections.Generic;
using System.Text;

namespace Task18_ThreadingAsync
{
    internal class AsyncFileDownloader
    {

        private readonly object _lock = new object();
        private int _completedCount = 0;

        private async Task OneFileDownloader(string fileName, int howLongItTakeInMilisec)
        {
            Console.WriteLine($"the file name:{fileName} is under proccess ....");
            await Task.Delay(howLongItTakeInMilisec);
            int counter = 0;
            lock (_lock)
            {
                counter = ++_completedCount;
            }
            Console.WriteLine($"counter: {counter}\nfile Name: {fileName}");
        }

        public async Task MultiFileDownloader()
        {
            List<string> name = new List<string>()
            {
                "task1",
                "task2",
                "task3",
                "task4",
                "task5"
            };
            List<int> ms = new List<int>()
            {
                2000,
                1000,
                3000,
                4000,
                500
            };
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < name.Count; i++)
            {
                int x = i;
                Task t = OneFileDownloader(name[x], ms[x]);
                tasks.Add(t);
            }
            await Task.WhenAll(tasks);

        }

    }
}
