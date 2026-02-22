using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models
{
    public class Interest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        public Int64 AccountNo { get; set; }
        public type AccountType { get; set; }
        public int Rate { get; set; }
        public double InterestAmount { get; set; } = 0;
    }
}
