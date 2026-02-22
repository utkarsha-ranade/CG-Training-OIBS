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
            //employee emp = new employee();
            //console.writeline("enter employee id");
            //string input = console.readline();
            //if (int.tryparse(input, out int id))
            //{
                //    emp.ID = id;
                //    Console.WriteLine("Enter Employee Name");
                //    input = Console.ReadLine();
                //    if (!string.IsNullOrEmpty(input))
                //    {
                //        emp.Name = input;
                //        Console.WriteLine("Enter Address");
                //        input = Console.ReadLine();
                //        if (!string.IsNullOrEmpty(input))
                //        {
                //            emp.Addr = input;
                //            Console.WriteLine("Enter City");
                //            input = Console.ReadLine();
                //            if (!string.IsNullOrEmpty(input))
                //            {
                //                emp.City = input;
                //                Console.WriteLine("Enter Salary");
                //                input = Console.ReadLine();
                //                if(int.TryParse(input, out int sal))
                //                {
                //                    emp.Salary = sal;
                //                }
                //                else
                //                    Console.WriteLine("Invalid Salary");
                //            }
                //            else
                //                Console.WriteLine("Invalid City");
                //        }
                //        else
                //            Console.WriteLine("Invalid Address");
                //    }
                //    else
                //        Console.WriteLine("Invalid Employee Name");
                //}
                //else
                //    Console.WriteLine("Invalid Employee ID");

            //Array
            Employee[] emp1 = new Employee[10];
            Console.WriteLine("Enter Info for 10 Employees");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter Employee ID");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    Employee emp = new Employee();
                    emp.ID = id;
                    Console.WriteLine("Enter Employee Name");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        emp.Name = input;
                        Console.WriteLine("Enter Address");
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            emp.Addr = input;
                            Console.WriteLine("Enter City");
                            input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input))
                            {
                                emp.City = input;
                                Console.WriteLine("Enter Salary");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out int sal))
                                {
                                    emp.Salary = sal;
                                }
                                else
                                    Console.WriteLine("Invalid Salary");
                            }
                            else
                                Console.WriteLine("Invalid City");
                        }
                        else
                            Console.WriteLine("Invalid Address");
                    }
                    else
                        Console.WriteLine("Invalid Employee Name");
                }
                else
                    Console.WriteLine("Invalid Employee ID");
            }
            Console.Read();
        }
    }
}
