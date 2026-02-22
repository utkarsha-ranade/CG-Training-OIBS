using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict.Add(101, "Sam");
            myDict.Add(102, "Ed");
            myDict.Add(103, "Sid");
            myDict.Add(104, "Jake");
            myDict.Add(105, "Elle");

            Console.WriteLine("Enter User ID");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int UID))
            {
                if (myDict.ContainsKey(UID))
                {
                    Console.WriteLine("User Name: " + myDict[UID]);
                }
                else
                    Console.WriteLine("User ID not found");
            }
            else
                Console.WriteLine("Invalid UserID");

            Console.Read();
        }
    }
}
