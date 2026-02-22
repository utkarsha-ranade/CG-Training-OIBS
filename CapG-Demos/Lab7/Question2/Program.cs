using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    internal class Program
    {
        class Product
        {
            public int ProductNo { get; set; }
            public string ProductName { get; set; }
            public double Rate { get; set; }
            public int Stock { get; set; }
            public override string ToString() => $"No : {ProductNo}\tName : {ProductName}\tRate : {Rate}\tStock : {Stock}";
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("1)Add new product\n2)Delete currently searched product\n3)Search product\n4)Save new product\n5)Exit");
                Console.WriteLine("Enter your choice : ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Product product = new Product();
                            Console.WriteLine("Enter product no. : ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int number))
                            {
                                product.ProductNo = number;
                                Console.WriteLine("Enter product name : ");
                                input = Console.ReadLine();
                                if (!string.IsNullOrEmpty(input))
                                {
                                    product.ProductName = input;
                                    Console.WriteLine("Enter product rate : ");
                                    input = Console.ReadLine();
                                    if (double.TryParse(input, out double rate))
                                    {
                                        product.Rate = rate;
                                        Console.WriteLine("Enter product stock : ");
                                        input = Console.ReadLine();
                                        if (int.TryParse(input, out int stock))
                                        {
                                            product.Stock = stock;
                                            products.Add(product);                                            
                                        }
                                        else
                                            Console.WriteLine("Invalid stock.");
                                    }
                                    else
                                        Console.WriteLine("Invalid rate.");
                                }
                                else
                                    Console.WriteLine("Invalid name.");
                            }
                            else
                                Console.WriteLine("Invalid number.");

                            break;
                        case 2:
                            Console.WriteLine("Enter the product no. you want to delete : ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int no))
                            {
                                bool exist = false;
                                foreach (Product p in products)
                                {
                                    if (p.ProductNo == no)
                                    {
                                        products.Remove(p);
                                        exist = true;
                                        break;
                                    }
                                }
                                if (!exist)
                                {
                                    Console.WriteLine("Product does not exist.");
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter product number you want to search : ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int no1))
                            {
                                bool exist = false;
                                foreach (Product p in products)
                                {
                                    if (p.ProductNo == no1)
                                    {
                                        Console.WriteLine(p.ToString());
                                        exist = true;
                                    }
                                }
                                if (!exist)
                                {
                                    Console.WriteLine("Product does not exist.");
                                }
                            }
                            break;
                        case 4:
                            products.Sort(delegate (Product x, Product y)
                            {
                                return x.ProductNo.CompareTo(y.ProductNo);
                            });
                            foreach(Product p in products)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Wrong Choice.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid choice");
            }
        }
    }
}
