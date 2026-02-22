using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersListLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customers> customerList = new List<Customers>();
            Console.WriteLine("Enter info for 3 Customers");
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Enter Customer ID");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int CID))
                {
                    Customers newcustomer = new Customers();
                    newcustomer.ID = CID;

                    Console.WriteLine("Enter Customer Name");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        newcustomer.Name = input;
                        Console.WriteLine("Enter Customer City");
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            newcustomer.City = input;
                        }
                        else
                            Console.WriteLine("Invalid Input");
                    }
                    else
                        Console.WriteLine("Invalid Input");
                }
                else
                    Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("Customer List");
            foreach (var customer in customerList)
            {
                Console.WriteLine(customer);
            }
            Console.Read();
        }
    }
}
