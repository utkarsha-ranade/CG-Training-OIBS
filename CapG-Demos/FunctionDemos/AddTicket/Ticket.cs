using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTicket
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public double Price { get; set; }
        public bool IsCanceled { get; set; } = false;
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int NoOfSeats { get; set; }
    }
}
