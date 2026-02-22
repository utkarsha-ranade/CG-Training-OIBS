using CapG.ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapG.ShapeUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Area Calculation Program");
            Console.WriteLine("1) Square, 2) Triangle, 3) Circle, 4) Rectangle");
            Console.WriteLine("Enter Choice");
            string input = Console.ReadLine();
            //vadidate
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1: //square
                        Console.WriteLine("Enter side");
                        input = Console.ReadLine();
                        if (double.TryParse(input, out double side))
                        {
                            Square squareObj = new Square(side);
                            double area = squareObj.Area();
                            Console.WriteLine("Area " + area);
                        }
                        else
                        {
                            Console.WriteLine("Invalid side");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter Base");
                        string input1 = Console.ReadLine();

                        if (double.TryParse(input, out double basevalue))
                        {
                            Console.WriteLine("Enter Height");
                            string input2 = Console.ReadLine();
                            if (double.TryParse(input, out double height))
                            {
                                Triangle triangleObj = new Triangle(basevalue, height);
                                double area = triangleObj.Area();
                                Console.WriteLine("Area " + area);
                            }
                            else
                            {
                                Console.WriteLine("Invalid side");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid side");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter radius");
                        string input3 = Console.ReadLine();
                        if (double.TryParse(input, out double radius))
                        {
                            Circle circleObj = new Circle(radius);
                            double area = circleObj.Area();
                            Console.WriteLine("Area " + area);
                        }
                        else
                        {
                            Console.WriteLine("Invalid side");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Base");
                        string input4 = Console.ReadLine();

                        if (double.TryParse(input, out double baseval))
                        {
                            Console.WriteLine("Enter Height");
                            string input5 = Console.ReadLine();
                            if (double.TryParse(input, out double length))
                            {
                                Rectangle rectangleObj = new Rectangle(baseval, length);
                                double area = rectangleObj.Area();
                                Console.WriteLine("Area " + area);
                            }
                            else
                            {
                                Console.WriteLine("Invalid length");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid baseval");
                        }
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT");
                        break;
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
