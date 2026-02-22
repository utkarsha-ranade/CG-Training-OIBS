using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3,3];
            Console.WriteLine("Enter the data");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string input = Console.ReadLine();
                    arr[i,j] = Convert.ToInt32(input);
                }
            }
            Console.WriteLine("Your Array:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{arr[i,j]}\t");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
