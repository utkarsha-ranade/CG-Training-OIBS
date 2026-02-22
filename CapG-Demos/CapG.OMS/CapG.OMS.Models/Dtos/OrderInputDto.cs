using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.OMS.Models.Dtos
{
    public class OrderInputDto
    {
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
