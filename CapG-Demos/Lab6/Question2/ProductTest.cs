using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class DataEntryException : Exception
    {
        public DataEntryException(string message) : base(message) { }
    }
    class ProductMock
    {
        private int _productId;
        private string _productName;
        private double _price;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value <= 0)
                {
                    throw new DataEntryException("Product ID must be greater than zero.");
                }
                _productId = value;
            }
        }
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value == "")
                {
                    throw new DataEntryException("Product Name cannot be left blank.");
                }
                bool isOnlyLetterorNumbers = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && !char.IsDigit(value[i]))
                    {
                        isOnlyLetterorNumbers = false;
                        break;
                    }
                }
                if (!isOnlyLetterorNumbers)
                {
                    throw new DataEntryException("Product Name should have alphabets and numbers only.");
                }
                _productName = value;
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price <= 0)
                {
                    throw new DataEntryException("Price of product must be greater than zero.");
                }
                _price = value;
            }
        }
    }
    internal class ProductTest
    {
        static void Main(string[] args)
        {
            try
            {
                ProductMock pm = new ProductMock();

                Console.Write("Enter Id: ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int id))
                {
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out double price))         //price = double.Parse(Console.ReadLine());
                    {
                        pm.ProductId = id;
                        pm.ProductName = name;
                        pm.Price = price;
                    }
                    else
                        Console.WriteLine("Invalid Price");                 
                }
                else
                    Console.WriteLine("Invalid Id");                             
            }
            catch (DataEntryException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
