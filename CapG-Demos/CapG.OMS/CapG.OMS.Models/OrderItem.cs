using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapG.OMS.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(1, double.MaxValue)]
        public double Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
