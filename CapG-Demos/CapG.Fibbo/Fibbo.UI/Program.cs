using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibbo.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int Num))
            {
                Console.WriteLine("Fibbonacci Series");
                int n1 = 0, n2 = 1, next;
                Console.WriteLine(n1);
                Console.WriteLine(n2);
                next = n1 + n2;
                while (next <= Num)
                {
                    Console.WriteLine(next);
                    n1 = n2;
                    n2 = next;
                    next = n1 + n2;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.Read();
        }
    }
}
