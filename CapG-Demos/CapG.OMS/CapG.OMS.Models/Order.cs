using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.OMS.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; } = false; 
        public ICollection<OrderItem> OrderItems { get; set;}
    }
}
