using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> testQueue = new PriorityQueue<string>();

            testQueue.Enqueue(1, "One");

            testQueue.Enqueue(-1, "NegativeOne");

            testQueue.Enqueue(1, "BiggerNumber");

            while (testQueue.Count > 0)
            {
                Console.WriteLine(testQueue.Dequeue().ToString());
            }
        }
    }
}
