using CapG.EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.EMS.Repositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        IEnumerable<Employees> GetByDept(int id);
    }
}
