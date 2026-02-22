using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapG.ShapeLibrary
{
    public class Circle : Shape
    {
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;

        }
        public override double Area()
        {
            return 3.14 * radius * radius;
        }
    }
}
