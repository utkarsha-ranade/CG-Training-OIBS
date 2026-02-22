using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.OIBS.Models.DTOS
{
    public class ReportDTO
    {
        public Int64 AccountNo { get; set; }
        public double Amount { get; set; }
        public int? TransferId { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public Transtype TransactionType { get; set; }
        public bool IsValid { get; set; }
    }
}
