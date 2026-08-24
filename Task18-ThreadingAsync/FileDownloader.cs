using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task18_ThreadingAsync
{
    public class FileDownloader
    {
        private readonly object _lock = new object();
        private int _completedCount = 0;

        private void OneFileDownloader(string fileName, int howLongItTakeInMilisec)
        {
            Console.WriteLine($"the file name:{fileName} is under proccess ....");
            Thread.Sleep(howLongItTakeInMilisec);
            int counter = 0;
            lock (_lock)
            {
                counter = ++_completedCount;
            }
            Console.WriteLine($"counter: {counter}\nfile Name: {fileName}");
        }

        public void MultiFileDownloader()
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
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 5; i++)
            {
                int x = i;
                Thread t = new Thread(() => OneFileDownloader(name[x], ms[x]));
                threads.Add(t);
                t.Start();
            }
            foreach (var item in threads)
            {
                item.Join();
            }

        }

    }
}
