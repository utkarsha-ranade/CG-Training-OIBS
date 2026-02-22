using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Dictionary<string, string> states = new Dictionary<string, string>();
            //Task2
            states.Add("MH14", "Maharashtra");
            states.Add("JH10", "Jharkhand");
            states.Add("KL12", "Kerala");
            states.Add("WB28", "West Bengal");
            states.Add("RJ21", "Rajasthan");
            states.Add("UP26", "Uttar Pradesh");
            states.Add("AS03", "Assam");
            states.Add("GO06", "Goa");
            states.Add("PB20", "Punjab");
            states.Add("GJ07", "Gujarat");
            //Task3
            try
            {
                if (!states.ContainsKey("RJ21"))
                {
                    states.Add("RJ21", "Rajasthan");
                }
                else
                    throw new ArgumentException("Key is already present.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Task4
            if (states.ContainsKey("GO06"))
            {
                states["GO06"] = "Panaji";
                Console.WriteLine($"Updated value for \"GO06\" is {states["GO06"]}");
            }
            //Task5
            if (!states.ContainsKey("MZ17"))
                states.Add("MZ17", "Mizoram");
            //Task6
            try
            {
                Console.WriteLine(states["SK22"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Task7
            foreach (string item in states.Keys)
            {
                Console.WriteLine($"{item}\t{states[item]}");
            }
            //Task8
            if(states.ContainsKey("RJ21"))
            {
                states.Remove("RJ21");
                Console.WriteLine("Key deleted.");
            }
            else
                Console.WriteLine("Key does not exist.");
            Console.Read();
        }        
    }
}
