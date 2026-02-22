using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public struct Program1
    {
        int Number;
        public void Square(int n)
        {
            this.Number = n;
            Console.WriteLine("Square of Number : " + Number * Number);
        }
        public void Cube(int n)
        {
            this.Number = n;
            Console.WriteLine("Cube of Number : " + Number * Number * Number);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int n))
            {
                Program1 p1 = new Program1();
                p1.Square(n);
                p1.Cube(n);
            }
            else
                Console.WriteLine("Invalid Input");
            Console.Read();
        }
    }
}
