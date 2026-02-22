using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace CapG.MTBS.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;
        [Range(100, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public bool IsCanceled { get; set; } = false;
        public string UserId { get; set; }
        [JsonIgnore]
        public CustomUser User { get; set; }
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        [Display(Name = "No Of Seats")]
        public int NoOfSeats { get; set; }
    }
}
