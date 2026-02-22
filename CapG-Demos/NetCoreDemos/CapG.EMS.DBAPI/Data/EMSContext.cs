using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapG.EMS.Models;

namespace CapG.EMS.DBAPI.Data
{
    public class EMSContext : DbContext
    {
        public EMSContext (DbContextOptions<EMSContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
