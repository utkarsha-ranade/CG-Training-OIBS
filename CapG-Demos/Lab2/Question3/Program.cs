using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[5];
            Console.WriteLine("Enter 5 Cities");
            for (int i = 0; i < 5; i++)
            {
                str[i] = Console.ReadLine();
            }
            Console.WriteLine("The 5 cities are:");
            foreach (string item in str)
            {
                Console.Write($"{item}\t");
            }
            Console.Read();
        }
    }
}
