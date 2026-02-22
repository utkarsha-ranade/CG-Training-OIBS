using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericClass<int> generic1 = new GenericClass<int>();
            generic1.Add(1);
            generic1.Method1<bool>(true);

            GenericClass<string> generic2 = new GenericClass<string>();
            generic2.Add("Name");

            //GenericClass<Order> generic2 = new GenericClass<Order>();            Order is a Class
            //generic2.Add(new Order);

            Console.Read();
        }
    }
}
