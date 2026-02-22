using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.Models
{
    public class Nominee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Relation Relation { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
