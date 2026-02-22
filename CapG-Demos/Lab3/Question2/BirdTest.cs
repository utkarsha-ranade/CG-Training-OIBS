using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Bird
    {
        private string Name;
        private double Maxheight;

        public Bird() //Default Constructor
        {
            this.Name = "Mountain Eagle";
            this.Maxheight = 500;
        }

        public Bird(string birdname, double max_ht) //Overloaded Constructor
        {
            this.Name = birdname;
            this.Maxheight = max_ht;
        }

        public void fly()
        {
            Console.WriteLine($"{this.Name} flies at altitude {this.Maxheight}");
        }

        public void fly(double AtHeight)
        {
            if (AtHeight <= this.Maxheight)
                Console.WriteLine($"{this.Name} is flying at {AtHeight}");
            else
                Console.WriteLine($"{this.Name} cannot fly at this height");
        }
    }
    public class BirdTest
    {
        static void Main(string[] args)
        {
            Bird b = new Bird("Crow", 150);
            b.fly();
            b.fly(100);
            Console.ReadLine();
        }
    }
}
