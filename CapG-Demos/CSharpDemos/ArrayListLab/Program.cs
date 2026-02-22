using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList List = new ArrayList();
            List.Add(1);
            List.Add("hello");
            List.Add(true);

            Console.WriteLine("Iterating ArrayList");
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
