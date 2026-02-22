using PrimeNo.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNo.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number");
            string input = Console.ReadLine();
            if(int.TryParse(input, out int Num))
            {
                if(Prime.isPrime(Num))
                    Console.WriteLine("Prime");
                else
                    Console.WriteLine("Not Prime");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.Read();
        }
    }
}
