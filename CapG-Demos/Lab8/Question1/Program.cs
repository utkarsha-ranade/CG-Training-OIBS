using System;
using System.Collections;
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
            Hashtable districts = new Hashtable();
            int choice = 0;
            while(choice != 6)
            {
                Console.WriteLine("1)Add Record\n2)Search record\n3)Display All Records\n" +
                    "4)To display Total count of Records at any point\n5)Remove any particular record\n6)Exit");
                Console.WriteLine("Enter your choice");
                string input = Console.ReadLine();
                if(int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter District Number : ");
                            input = Console.ReadLine();
                            if(!string.IsNullOrEmpty(input))
                            {
                                string number = input;
                                Console.WriteLine("Enter District Name : ");
                                input = Console.ReadLine();
                                if (!string.IsNullOrEmpty(input))
                                {
                                    string name = input;
                                    districts.Add(number, name);
                                    Console.WriteLine("District added successfully.");
                                }
                                else
                                    Console.WriteLine("Invalid Name.");
                            }
                            else
                                Console.WriteLine("Invalid Number.");
                            break;
                        case 2:
                            Console.WriteLine("Enter district number to search");
                            input= Console.ReadLine();
                            if (!string.IsNullOrEmpty(input))
                            {
                                bool exist = false;
                                foreach (string key in districts.Keys)
                                {
                                    if (key == input)
                                    {
                                        Console.WriteLine($"District Number : {key}\tDistrict Name : {districts[key]}");
                                        exist = true;
                                        break;
                                    }
                                }
                                if (!exist)
                                {
                                    Console.WriteLine("District does not exist.");
                                }
                            }
                            else
                                Console.WriteLine("Invalid Number.");
                            break;
                        case 3:
                            Console.WriteLine("ALL DISTRICTS");
                            Console.WriteLine("Number\tName");
                            foreach (DictionaryEntry d in districts)
                            {
                                Console.WriteLine($"{d.Key}\t{d.Value}");
                            }
                            break;
                        case 4:
                            Console.WriteLine($"Total records are : {districts.Count}");
                            break;
                        case 5:
                            Console.WriteLine("Enter district number to remove");
                            input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input))
                            {
                                bool exist = false;
                                if(districts.ContainsKey(input) || districts.ContainsValue(input))
                                {
                                    districts.Remove(input);
                                    Console.WriteLine("The district has been deleted successfully.");
                                    exist = true;
                                    break;
                                }
                                if (!exist)
                                {
                                    Console.WriteLine("District does not exist.");
                                }
                            }
                            else
                                Console.WriteLine("Invalid Number.");
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Wrong Choice!!!!");
                            break;
                    }
                }
            }
        }
    }
}
