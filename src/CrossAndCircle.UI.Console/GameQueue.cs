using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CrossAndCircle.UI.Console
{
    internal class GameQueue
    {
        private ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();

        public GameQueue()
        {
            Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    Thread.Sleep(100);
                    queue.TryDequeue(out var workToDo);
                    workToDo();
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Do(Action work)
        {
            queue.Enqueue(work);
        }
    }
}
