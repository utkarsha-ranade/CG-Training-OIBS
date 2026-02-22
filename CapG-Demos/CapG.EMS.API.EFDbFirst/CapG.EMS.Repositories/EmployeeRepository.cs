using CapG.EMS.Exceptions;
using CapG.EMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapG.EMS.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmsEFDbFirstContext context;
        public EmployeeRepository(EmsEFDbFirstContext context)
        {
            this.context = context;
        }
        public bool Add(Employees entity)
        {
            try
            {
                var existingEmployee = context.Employees.FirstOrDefault(e => e.Email == entity.Email);
                if (existingEmployee != null)
                {
                    throw new EmsException("Duplicate Employee.");
                }
                context.Employees.Add(entity);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new EmsException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            try
            {
                var employee = context.Employees.Find(key);
                if (employee == null)
                {
                    throw new EmsException("Employee not found");
                }
                context.Employees.Remove(employee);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new EmsException(ex.Message);
            }
        }

        public Employees Get(object key)
        {
            try
            {
                var existingEmployee = context.Employees.Find(key);
                if (existingEmployee == null)
                {
                    throw new EmsException("Employee not found");
                }
                return existingEmployee;
            }
            catch (EmsException ex)
            {
                throw new EmsException(ex.Message);
            }
        }

        public IEnumerable<Employees> Get()
        {
            var list = context.Employees.ToList();
            return list;
        }

        public IEnumerable<Employees> GetByDept(int id)
        {
            var list = context.Employees.Where(e => e.DeptId == id);
            return list;
        }

        public bool Update(Employees entity)
        {
            try
            {
                var existingEmployee = context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
                if (existingEmployee == null)
                {
                    throw new EmsException("Employee not found.");
                }
                context.Employees.Update(entity);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new EmsException(ex.Message);
            }
        }
    }
}
