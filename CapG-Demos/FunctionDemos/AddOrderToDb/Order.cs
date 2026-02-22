using System;

namespace AddOrderToDb
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public bool IsCanceled { get; set; } = false;
    }
}