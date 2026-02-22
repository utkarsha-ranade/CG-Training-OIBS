using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count:" + list.Count);

            list.Add("Pani Puri");
            list.Add("Dahi Wada");
            list.Add("Jalebi Fafda");
            list.Add("Pav Bhaji");
            list.Add("Vada Paav");

            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count:" + list.Count);

            Console.WriteLine("Clear List");
            list.Clear();
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count:" + list.Count);

            Console.Read();
        }
    }
}
