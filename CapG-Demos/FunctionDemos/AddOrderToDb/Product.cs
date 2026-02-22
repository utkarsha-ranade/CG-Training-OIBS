using System;

namespace AddOrderToDb
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public double Price { get; set; }
        public Category Category { get; set; }
        public bool IsActive { get; set; } = true;
    }
}