using CapG.EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using CapG.EMS.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CapG.EMS.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EMSContext context;
        public EmployeeRepository(EMSContext context)
        {
            this.context = context;
        }
        public bool Add(Employee entity)
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

        public Employee Get(object key)
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

        public IEnumerable<Employee> Get()
        {
            var list = context.Employees.ToList();
            return list;
        }

        public IEnumerable<Employee> GetByDept(int id)
        {
            var list = context.Employees.Where(e => e.DeptId == id);
            return list;
        }

        public bool Update(Employee entity)
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
