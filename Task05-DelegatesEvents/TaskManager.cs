using System;
using System.Collections.Generic;
using System.Text;

namespace Task05_DelegatesEvents
{
    // A delegate is a TYPE that describes the "shape" of a method:
    // any method matching this shape (takes one string, returns void)
    // can be plugged in as a handler. Think of it as a job posting —
    // it defines what a candidate method must look like, without
    // saying who the candidate actually is.
    public delegate void handler_completed_task(string nameTask);

    internal class TaskManager
    {
        // An event is a list of "subscribed" methods that match the
        // delegate's shape. Outside code can only += or -= to this list —
        // only TaskManager itself (below) is allowed to actually fire it.
        // This is the "notification strategy": TaskManager doesn't know
        // or care what its subscribers do (console log, file log, etc.),
        // it just promises to call all of them when a task completes.
        public event handler_completed_task TaskCompleted;

        // This is the method that actually "marks a task done."
        public void CompleteTask(string taskName)
        {
            // Raise (fire) the event, calling every subscribed handler
            // in the order they were added, passing taskName to each.
            //
            // The "?." is important: if nobody has subscribed yet,
            // TaskCompleted is null, and calling .Invoke() on null
            // would throw a NullReferenceException. The "?." skips
            // the call safely instead if there are zero subscribers.
            TaskCompleted?.Invoke(taskName);
        }
    }
}