using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push(1);
            myStack.Push("Hello");

            Console.WriteLine("Total: " + myStack.Count);

            Console.WriteLine("Popped ITEM: " + myStack.Pop());

            Console.WriteLine("Total: " + myStack.Count);

            Console.Read();
        }
    }
}
