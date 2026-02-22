using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    internal class Program
    {
        public class ProductDemo
        {
            private object id;
            private object name;
            private object price;
            private object quantity;

            public ProductDemo(int id, string name, double price, int quantity)
            {
                //boxing
                this.id = id;
                this.name = name;
                this.price = price;
                this.quantity = quantity;
            }

            public void displayProductDetails()
            {
                //unboxing
                double amtPayable = (double)price * (int)quantity;
                Console.WriteLine("\nProduct Details: ");
                Console.WriteLine($"Product id: {id}");
                Console.WriteLine($"Product name: {name}");
                Console.WriteLine($"Product Price: {price}");
                Console.WriteLine($"Product Quantity: {quantity}");
                Console.WriteLine($"Product Amt Payable: {amtPayable}");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the id of product: ");
            string input = Console.ReadLine();
            if(int.TryParse(input, out int id))
            {
                Console.Write("\nEnter the name of product: ");
                input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                {
                    string name = input;
                    Console.Write("\nEnter price: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int price))
                    {
                        Console.Write("\nEnter quantity: ");
                        input = Console.ReadLine();
                        if(int.TryParse(input, out int quantity))
                        {
                            ProductDemo demo = new ProductDemo(id, name, price, quantity);
                            demo.displayProductDetails();
                        }
                        else
                            Console.WriteLine("Invalid quantity");
                    }
                    else
                        Console.WriteLine("Invalid price");
                }
                else
                    Console.WriteLine("Invalid name");
            }
            else
                Console.WriteLine("Invalid id");
            Console.Read();
        }
    }
}
