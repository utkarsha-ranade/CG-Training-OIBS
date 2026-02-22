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
            Console.WriteLine("Enter an Integer");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int num))
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Entered value is 1");
                        break;
                    case 2:
                        Console.WriteLine("Entered value is 2");
                        break;
                    case 3:
                        Console.WriteLine("Entered value is 3");
                        break;
                    case 4:
                        Console.WriteLine("Entered value is 4");
                        break;
                    case 5:
                        Console.WriteLine("Entered value is 5");
                        break;
                    default:
                        Console.WriteLine("Entered value is other than 1, 2, 3, 4, 5");
                        break;
                }
            }
            else
                Console.WriteLine("Invalid Input");
            Console.Read();
        }
    }
}
