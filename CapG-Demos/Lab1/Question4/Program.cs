using Question4.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter total no. of Students");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int total))
            {
                SchoolDemo[] school1 = new SchoolDemo[total];
                Console.WriteLine($"Enter info for {total} Students");
                for (int i = 0; i < total; i++)
                {
                    Console.WriteLine("Enter Rollnumber");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int roll))
                    {
                        SchoolDemo school = new SchoolDemo();
                        school.rollNumber = roll;
                        Console.WriteLine("Enter Name");
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            school.studentName = input;
                            Console.WriteLine("Enter Age");
                            input = Console.ReadLine();
                            if (byte.TryParse(input, out byte ag))
                            {
                                school.age = ag;
                                Console.WriteLine("Enter Gender");
                                input = Console.ReadLine();
                                if (char.TryParse(input, out char gen))
                                {
                                    school.gender = gen;
                                    Console.WriteLine("Enter Date of Birth");
                                    DateTime userDateTime;
                                    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                                    {
                                        school.dateOfBirth = userDateTime;
                                        Console.WriteLine("Enter Address");
                                        input = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(input))
                                        {
                                            school.address = input;
                                            Console.WriteLine("Enter Percentage");
                                            input = Console.ReadLine();
                                            if (float.TryParse(input, out float per))
                                            {
                                                school.percentage = per;
                                                Console.WriteLine("\nSTUDENT DETAILS:\n");
                                                Console.WriteLine(school.ToString());
                                            }
                                            else
                                                Console.WriteLine("Invalid Percentage");
                                        }
                                        else
                                            Console.WriteLine("Invalid Address");
                                    }
                                    else
                                        Console.WriteLine("Invalid Date of Birth");
                                }
                                else
                                    Console.WriteLine("Gender");
                            }
                            else
                                Console.WriteLine("Invalid Age");
                        }
                        else
                            Console.WriteLine("Invalid Name");
                    }
                    else
                        Console.WriteLine("Invalid Rollnumber");
                }
            }
            else
                Console.WriteLine("Invalid Input");
            Console.Read();
        }
    }
}
