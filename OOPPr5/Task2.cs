using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPPr5
{
    internal class Task2
    {
        private object light1Lock = new object();
        private object light2Lock = new object();
        private object light3Lock = new object();
        private object light4Lock = new object();

        private Semaphore semaphore = new Semaphore(2, 2);

        public void Active()
        {
            Thread Trafficlight1Thread = new Thread(new ThreadStart(Light1));
            Thread Trafficlight2Thread = new Thread(new ThreadStart(Light2));
            Thread Trafficlight3Thread = new Thread(new ThreadStart(Light3));
            Thread Trafficlight4Thread = new Thread(new ThreadStart(Light4));

            Trafficlight1Thread.Start();
            Trafficlight2Thread.Start();
            Trafficlight3Thread.Start();
            Trafficlight4Thread.Start();

            while (true)
            {
                semaphore.WaitOne();
                lock (light1Lock)
                {
                    Console.WriteLine("Cars passing from TrafficLight 1");
                    Thread.Sleep(2000);
                }
                lock (light2Lock)
                {
                    Console.WriteLine("Cars passing from TrafficLight 2");
                    Thread.Sleep(2000);
                }
                lock (light3Lock)
                {
                    Console.WriteLine("Cars passing from TrafficLight 3");
                    Thread.Sleep(2000);
                }
                lock (light4Lock)
                {
                    Console.WriteLine("Cars passin from TrafficLight 4");
                    Thread.Sleep(2000);
                }
                semaphore.Release();
            }
        }
        private void Light1()
        {
            while (true)
            {
                lock (light1Lock)
                {
                    Console.WriteLine("TrafficLight 1 is green");
                    Thread.Sleep(5000);
                    Console.WriteLine("TrafficLight 1 is yellow");
                    Thread.Sleep(2000);
                    Console.WriteLine("TrafficLight 1 is red");
                }
                Thread.Sleep(1000);
            }
        }
        private void Light2()
        {
            while (true)
            {
                lock (light2Lock)
                {
                    Console.WriteLine("TrafficLight 2 is green");
                    Thread.Sleep(5000);
                    Console.WriteLine("TrafficLight 2 is yellow");
                    Thread.Sleep(2000);
                    Console.WriteLine("TrafficLight 2 is red");
                }
                Thread.Sleep(1000);
            }
        }
        private void Light3()
        {
            while (true)
            {
                lock (light3Lock)
                {
                    Console.WriteLine("TrafficLight 3 is green");
                    Thread.Sleep(5000);
                    Console.WriteLine("TrafficLight 3 is yellow");
                    Thread.Sleep(2000);
                    Console.WriteLine("TrafficLight 3 is red");
                }
                Thread.Sleep(1000);
            }
        }
        private void Light4()
        {
            while (true)
            {
                lock (light4Lock)
                {
                    Console.WriteLine("TrafficLight 4 is green");
                    Thread.Sleep(5000);
                    Console.WriteLine("TrafficLight 4 is yellow");
                    Thread.Sleep(2000);
                    Console.WriteLine("TrafficLight 4 is red");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
