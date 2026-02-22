using System.Collections.Generic;

namespace AddOrderToDb
{
    internal class OrderDto
    {
        public Order Order { get; set; }
        public List<CartItem> Items { get; set; }
    }
}