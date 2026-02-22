using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models.DTOS
{
    public class TransactionDTO
    {
        public Int64 AccountNo { get; set; }
        public double Amount { get; set; }
        public Transtype TransactionType { get; set; }
        public Int64 DestinationAccountNo { get; set; } = 0;
    }
}
