using System;
using System.Linq;

namespace LINQLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 7, 8 };
            var result = from n in numbers
                         where n % 2 == 0
                         select n;

            //lambda method
            var result1 = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("Even Numbers : ");
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
            Console.Read();
        }
    }
}
