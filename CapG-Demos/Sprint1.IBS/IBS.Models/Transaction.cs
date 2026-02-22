using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime DateofTrans { get; set; }
        public TransactionType TransactionType { get; set; }
        public Nullable<int> TransNo { get; set; } = null;
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
