using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = GetHashtable();

            //Task 1
            if (hashtable.ContainsKey("Perimeter"))
            {
                Console.WriteLine("The Hashtable contains the key \"Perimeter\"");
            }
            else
            {
                Console.WriteLine("The Hashtable does not contain the key \"Perimeter\"");
            }

            //Task 2
            int index = 0;
            int indexArea = -1;
            foreach (string key in hashtable.Keys)
            {
                if (hashtable.ContainsKey("Area"))
                {
                    indexArea = index;
                }
                index++;
            }
            if (indexArea != -1)
            {
                Console.WriteLine($"The Hashtable with the key \"Area\" has index {indexArea}");
            }
            else
            {
                Console.WriteLine("The Hashtable does not contain the key \"Area\"");
            }

            Console.WriteLine();
            foreach (string key in hashtable.Keys)
            {
                Console.WriteLine($"{key}\t{hashtable[key]}");
            }

            //Task 3
            Console.WriteLine();
            if (hashtable.ContainsKey("Mortgage"))
            {
                hashtable.Remove("Mortgage");
                Console.WriteLine("The entry for \"Mortgage\" has been deleted.");
            }
            else
            {
                Console.WriteLine("The Hashtable does not contain the key \"Mortgage\"");
            }
            Console.WriteLine();
            foreach (string key in hashtable.Keys)
            {
                Console.WriteLine(($"{key}\t{hashtable[key]}"));
            }
            Console.ReadLine();
        }
        static Hashtable GetHashtable()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Area", 1000);
            hashtable.Add("Perimeter", 55);
            hashtable.Add("Mortgage", 540);

            return hashtable;
        }
    }
}

