using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CapG.OMS.Models
{
    public class OMSContext : DbContext
    {
        public OMSContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<OrderItem> OrderItems { get; set;}
        public DbSet<User> Users { get; set; }
    }
}
