using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashtableLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable myHash = new Hashtable();
            myHash.Add(101, "Sam");
            myHash.Add(102, "Ed");
            myHash.Add(103, "Sid");
            myHash.Add(104, "Jake");
            myHash.Add(105, "Elle");
            //myHash.Add(102, "John");
            //myHash[104] = "Dude";

            Console.WriteLine("Enter User ID");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int UID))
            {
                if (myHash.ContainsKey(UID))
                {
                    Console.WriteLine("User Name: " + myHash[UID]);
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
