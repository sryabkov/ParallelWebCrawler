using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelWebCrawler
{
    /// <summary>
    /// Producer/Consumer Queue, based on code from "C# 6.0 in a Nutshell, 6th Edition", ch. 23
    /// </summary>
    public class TaskQueue : IDisposable
    {
        BlockingCollection<Task> _taskQueue = new BlockingCollection<Task>();

        public TaskQueue(int numberOfWorkers)
        {
            for(int i = 0; i < numberOfWorkers; i++)
            {
                Task.Factory.StartNew(Consume);
            }
        }

        public Task Enqueue(Action action, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new Task(action, cancellationToken);
            _taskQueue.Add(task);
            return task;
        }

        //public Task<TResult> Enqueue<TResult>(Func<TResult> function, 
        //    CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var task = new Task<TResult>(function, cancellationToken);
        //    _taskQueue.Add(task);
        //    return task;
        //}

        void Consume()
        {
            Console.WriteLine(Task.CurrentId);
            foreach (var task in _taskQueue.GetConsumingEnumerable())
            {
                try
                {
                    if (!task.IsCanceled)
                    {
                        task.RunSynchronously();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception in Consume()");
                }
            }
        }

        public void Dispose()
        {
            _taskQueue.CompleteAdding();
        }
    }
}
