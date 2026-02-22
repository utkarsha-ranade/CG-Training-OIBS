using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        delegate double Operation(double n1, double n2);
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number : ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double num1))
            {
                Console.WriteLine("Enter second number : ");
                input = Console.ReadLine();
                if (double.TryParse(input, out double num2))
                {
                    Console.WriteLine("1)Add\n2)Multiply\n3)Divide\n4)Subtract\n5)Find Max Value");
                    Console.WriteLine("Enter your choice : ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int choice))
                    {
                        Operation operation = null;
                        switch (choice)
                        {
                            case 1:
                                operation = ArithmeticOperation.Add;
                                break;
                            case 2:
                                operation = ArithmeticOperation.Multiply;
                                break;
                            case 3:
                                operation = ArithmeticOperation.Divide;
                                break;
                            case 4:
                                operation = ArithmeticOperation.Subtract;
                                break;
                            case 5:
                                operation = ArithmeticOperation.FindMax;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice!!");
                                break;
                        }
                        PerformArithmeticOperation(num1, num2, operation);
                    }
                }
                else
                    Console.WriteLine("Invalid input.");
            }
            else
                Console.WriteLine("Invalid input.");
            Console.Read();
        }
        public class ArithmeticOperation
        {
            public static double Add(double n1, double n2) => n1 + n2;
            public static double Multiply(double n1, double n2) => n1 * n2;
            public static double Divide(double n1, double n2) => n1 / n2;
            public static double Subtract(double n1, double n2) => n1 - n2;
            public static double FindMax(double n1, double n2) => Math.Max(n1, n2);
        }
        static void PerformArithmeticOperation(double num1, double num2, Operation operation)
        {
            var result = operation(num1, num2);
            Console.WriteLine($"Result = {result}");
        }
    }
}
