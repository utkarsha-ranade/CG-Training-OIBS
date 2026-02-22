using EvenOdd.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even.OddUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int Num))
            {
                if(EvenOdd.isEven(Num))
                    Console.WriteLine("Even");
                else
                    Console.WriteLine("Odd");
            }
            else
                Console.WriteLine("Invalid Input");
            Console.Read();
        }
    }
}
