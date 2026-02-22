using Question2.Library;
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
            Console.WriteLine("Enter First Number:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double num1))
            {
                Console.WriteLine("Enter Second Number:");
                input = Console.ReadLine();
                if (double.TryParse(input, out double num2))
                {
                    Console.WriteLine("1)Add 2)Subtract 3)Multiply 4)Divide 5)Modulo");
                    Console.WriteLine("Enter your choice:");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out double choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                double sum = ArithmeticOperations.Add(num1, num2);
                                Console.WriteLine("Sum = " + sum);
                                break;
                            case 2:
                                double diff = ArithmeticOperations.Subtract(num1, num2);
                                Console.WriteLine("Difference = " + diff);
                                break;
                            case 3:
                                double prod = ArithmeticOperations.Multiply(num1, num2);
                                Console.WriteLine("Product = " + prod);
                                break;
                            case 4:
                                double quo = ArithmeticOperations.Divide(num1, num2);
                                Console.WriteLine("Quotient = " + quo);
                                break;
                            case 5:
                                double mod = ArithmeticOperations.Modulo(num1, num2);
                                Console.WriteLine("Modulo = " + mod);
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
