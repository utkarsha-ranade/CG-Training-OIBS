using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersListLab
{
    internal class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"Id: {ID}\tName: {Name}\tCity: {City}";
        }
    }
}

