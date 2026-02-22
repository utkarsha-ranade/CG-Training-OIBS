using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapG.ShapeLibrary
{
    public class Triangle : Shape
    {
        double baseValue, height;
        public Triangle(double baseValue, double height)
        {
            this.baseValue = baseValue;
            this.height = height;
        }
        public override double Area()
        {
            return 1 / 2 * baseValue * height;
        }
    }
}