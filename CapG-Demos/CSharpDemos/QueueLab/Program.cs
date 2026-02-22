using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue myQ = new Queue();
            myQ.Enqueue("Sam");
            myQ.Enqueue("Jack");
            myQ.Enqueue("Elle");

            Console.WriteLine("Total: " + myQ.Count);

            Console.WriteLine("Dequeued ITEM: " + myQ.Dequeue());

            Console.WriteLine("Total: " + myQ.Count);

            Console.Read();
        }
    }
}
