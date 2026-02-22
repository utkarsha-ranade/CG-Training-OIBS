using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IBS.Models
{
    public class IBSContext : DbContext
    {
        public IBSContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
