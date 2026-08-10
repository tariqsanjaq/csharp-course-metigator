using System;
using System.IO;              // needed for File.AppendAllText — worth adding explicitly
using Task05_DelegatesEvents;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of TaskManager — this is the object whose
        // TaskCompleted event we're about to subscribe to.
        TaskManager manager = new TaskManager();

        // Subscribe both handlers using +=. This doesn't call them yet —
        // it just adds them to TaskCompleted's internal list of subscribers.
        // Order matters: they'll fire in the order they were added.
        manager.TaskCompleted += LogToConsole;
        manager.TaskCompleted += LogToFile;

        // This is what actually triggers the notification. Inside
        // CompleteTask, TaskCompleted?.Invoke("Write report") runs,
        // which calls BOTH subscribed handlers below, one after another.
        manager.CompleteTask("Write report");

        // Local functions: methods declared inside Main itself, rather
        // than as separate class members. "static" here means this local
        // function can't accidentally capture/use outer variables from
        // Main — it only has access to what's explicitly passed in (taskName).
        static void LogToConsole(string taskName)
        {
            Console.WriteLine($"[Console] Task completed: {taskName}");
        }

        static void LogToFile(string taskName)
        {
            // AppendAllText adds a new line to log.txt without erasing
            // what's already there — so this file grows every time you run
            // the program. Check your project folder for log.txt after running.
            File.AppendAllText("log.txt", $"Task completed: {taskName}\n");
        }
    }
}