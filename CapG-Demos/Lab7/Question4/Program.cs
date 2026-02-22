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
            List<Employee> employee = new List<Employee>();
            Console.WriteLine("Enter Employee Number : ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                Console.WriteLine("Enter Employee Name : ");
                input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                {
                    string name = input;
                    Console.WriteLine("Enter Basic Salary : ");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out double salary))
                    {
                        Console.WriteLine("Enter PF : ");
                        input = Console.ReadLine();
                        if (double.TryParse(input, out double pf))
                        {
                            Employee emp = new Employee(number, name, salary, pf);
                            employee.Add(emp);
                            foreach (Employee e in employee)
                            {
                                Console.WriteLine(e.ToString());
                            }
                        }
                        else
                            Console.WriteLine("Invalid PF.");
                    }
                    else
                        Console.WriteLine("Invalid Salary.");
                }
                else
                    Console.WriteLine("Invalid Name.");
            }
            else
                Console.WriteLine("Invalid Number.");
            Console.Read();
        }
    }
}
