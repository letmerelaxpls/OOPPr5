using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPPr5
{
    internal class Task1
    {
        private Queue<int> queue = new Queue<int>();
        private object objectLock = new object();
        static Random random = new Random();
        public void Active() 
        {
            Thread producerThread = new Thread(Producer);
            Thread consumerThread = new Thread(Consumer);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();
        }
        private void Producer()
        {
            while (true)
            {
                int value = random.Next(100);

                lock (objectLock)
                {
                    queue.Enqueue(value);
                    Console.WriteLine($"Producer: {value}");
                }
                Thread.Sleep(1000);
            }
        }

        private void Consumer()
        {
            while (true)
            {
                int value;
                lock (objectLock)
                {
                    if (queue.Count > 0)
                    {
                        value = queue.Dequeue();
                        Console.WriteLine($"Consumer {value} is removed");
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
    
}
