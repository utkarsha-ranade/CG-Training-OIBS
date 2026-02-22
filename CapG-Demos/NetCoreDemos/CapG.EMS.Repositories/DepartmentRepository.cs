using CapG.EMS.Exceptions;
using CapG.EMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapG.EMS.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private EMSContext context;
        public DepartmentRepository(EMSContext context)
        {
            this.context = context;
        }
        public bool Add(Department entity)
        {
            try
            {
                var existingEmployee = context.Departments.FirstOrDefault(d => d.Id == entity.Id);
                if (existingEmployee != null)
                {
                    throw new EmsException("Duplicate Employee.");
                }
                context.Departments.Add(entity);
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
                var department = context.Departments.Find(key);
                if (department == null)
                {
                    throw new EmsException("Department not found");
                }
                context.Departments.Remove(department);
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

        public Department Get(object key)
        {
            try
            {
                var existingDepartment = context.Departments.Find(key);
                if (existingDepartment == null)
                {
                    throw new EmsException("Department not found");
                }
                return existingDepartment;
            }
            catch (EmsException ex)
            {
                throw new EmsException(ex.Message);
            }
        }

        public IEnumerable<Department> Get()
        {
            var list = context.Departments.ToList();
            return list;
        }

        public bool Update(Department entity)
        {
            try
            {
                var existingDepartment = context.Departments.AsNoTracking().FirstOrDefault(d => d.Id == entity.Id);
                if (existingDepartment == null)
                {
                    throw new EmsException("Department not found.");
                }
                context.Departments.Update(entity);
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
