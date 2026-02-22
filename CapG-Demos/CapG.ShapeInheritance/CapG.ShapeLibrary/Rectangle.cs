using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapG.ShapeLibrary
{
    public class Rectangle : Shape
    {
        double baseval, length;
        public Rectangle(double baseval, double length)
        {
            this.baseval = baseval;
            this.length = length;
        }
        public override double Area()
        {
            return baseval * length;
        }
    }
}
