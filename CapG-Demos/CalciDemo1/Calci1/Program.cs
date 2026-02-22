using CalciDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calci1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number:");
            string input = Console.ReadLine();  
            if(double.TryParse(input, out double num1))
            {
                Console.WriteLine("Enter Second Number:");
                input = Console.ReadLine();
                if (double.TryParse(input, out double num2))
                {
                    Console.WriteLine("1)Add 2)Subtract 3)Multiply 4)Divide");
                    Console.WriteLine("Enter your choice:");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out double choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                double sum = Ops.Add(num1, num2);
                                Console.WriteLine("Sum = " + sum);
                                break;
                            case 2:
                                double diff = Ops.Subtract(num1, num2);
                                Console.WriteLine("Difference = " + diff);
                                break;
                            case 3:
                                double prod = Ops.Multiply(num1, num2);
                                Console.WriteLine("Product = " + prod);
                                break;
                            case 4:
                                double quo = Ops.Divide(num1, num2);
                                Console.WriteLine("Quotient = " + quo);
                                break;
                            default:
                                Console.WriteLine("Invalid");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Invalid");
                }
                else
                    Console.WriteLine("Invalid");
            }
            else
                Console.WriteLine("Invalid");
            Console.Read();
        }
    }
}
