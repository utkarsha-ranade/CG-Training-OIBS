using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1.Library
{
    public class ArithmeticOperation
    {
        public delegate double Operation(double n1, double n2);

        public static double Add(double n1, double n2) => n1 + n2;
        public static double Multiply(double n1, double n2) => n1 * n2;
        public static double Divide(double n1, double n2) => n1 / n2;
        public static double Subtract(double n1, double n2) => n1 - n2;
        public static double FindMax(double n1, double n2) => Math.Max(n1, n2);
    }
}
