using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models.DTOS
{
    public class InterestDTO
    {
        [JsonIgnore]
        public int AccountId { get; set; }
        public Int64 AccountNo { get; set; }
    }
}
