using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Capgemini.OIBS.Models
{
    public class Transaction
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public Int64 AccountNo { get; set; }
        
        public double Amount { get; set; }
        public int? TransferId { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Today;
        public Transtype TransactionType { get; set; }
        public bool IsValid { get; set; } = true;
    }
}

public enum Transtype
{
    Withdraw=1,
    Deposit,
    Transfer
}
