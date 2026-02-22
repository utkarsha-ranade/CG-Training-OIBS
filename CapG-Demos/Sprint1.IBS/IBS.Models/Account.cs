using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.Models
{
    public class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
        public double Interest { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
