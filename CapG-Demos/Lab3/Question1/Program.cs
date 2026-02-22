using Question1.Library;
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
            //Task4
            Participant p= new Participant();
            Console.WriteLine("Enter id: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int empid))
            {
                p.EmpId = empid;
                Console.WriteLine("Enter name: ");
                input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                {
                    p.Name = input;
                    Console.WriteLine("Enter Foundation Marks: ");
                    input= Console.ReadLine();
                    if(int.TryParse(input, out int fmarks))
                    {
                        p.FoundationMarks = fmarks;
                        Console.WriteLine("Enter Web Basic Marks");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int bmarks))
                        {
                            p.WebBasicMarks = bmarks;
                            Console.WriteLine("Enter DotNet Marks");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int dnmarks))
                            {
                                p.DotNetMarks = dnmarks;
                                p.CalculateTotalMarks();
                                p.CalculatePercentage();
                                Console.WriteLine($"\nCompany Name: {Participant.CompanyName}");
                                Console.WriteLine($"Total Marks: {p.ObtainedMarks}");
                                Console.WriteLine($"Percentage: {p.getPercentage()}");
                            }
                            else
                                Console.WriteLine("Inavlid DotNet Marks");
                        }
                        else
                            Console.WriteLine("Invalid Web Basic Marks");
                    }
                    else
                        Console.WriteLine("Invalid Foundation Marks");
                }
                else
                    Console.WriteLine("Invalid name");
            }
            else
                Console.WriteLine("Invalid id");
            Console.ReadLine();
        }
    }
}