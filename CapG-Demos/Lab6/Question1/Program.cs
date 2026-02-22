using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Program
    {
        class InvalidCreditLimit : Exception
        {
            public InvalidCreditLimit(string message) : base(message) { }
        }
        //Task1&2
        class Customer
        {
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string address;
            public string Address
            {
                get { return address; }
                set { address = value; }
            }

            private string city;
            public string City
            {
                get { return city; }
                set { city = value; }
            }

            private string phone;
            public string Phone
            {
                get { return phone; }
                set { phone = value; }
            }

            private decimal creditLimit;
            public decimal CreditLimit
            {
                get { return creditLimit; }
                set
                {
                    //Task 4
                    if (value > 50000)
                    {
                        //Task 5
                        throw new InvalidCreditLimit("The value is above 50000.");
                    }
                    creditLimit = value;
                }
            }

            //Task 3
            public Customer() { }
            public Customer(int id, string name, string address, string city, string phone, decimal creditLimit)
            {
                this.id = id;
                this.name = name;
                this.address = address;
                this.city = city;
                this.phone = phone;
                this.CreditLimit = creditLimit;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Sam", "Street 24", "Boston", "045523658", 25000);
                Console.WriteLine($"Customer Id: {customer1.Id}");
                Console.WriteLine($"Customer Name: {customer1.Name}");
                Console.WriteLine($"Customer Address: {customer1.Address}");
                Console.WriteLine($"Customer City: {customer1.City}");
                Console.WriteLine($"Customer Phone: {customer1.Phone}");
                Console.WriteLine($"Customer CreditLimit: {customer1.CreditLimit}");
            }
            catch (InvalidCreditLimit ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}