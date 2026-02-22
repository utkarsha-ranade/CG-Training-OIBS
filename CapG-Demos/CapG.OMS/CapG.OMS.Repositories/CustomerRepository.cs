using CapG.OMS.Exceptions;
using CapG.OMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapG.OMS.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private OMSContext context;
        public CustomerRepository(OMSContext context)
        {
            this.context = context;
        }
        public bool Add(Customer entity)
        {
            try
            {
                var existingCustomer = context.Customers.FirstOrDefault(e => e.Email == entity.Email);
                if (existingCustomer != null)
                {
                    throw new OmsException("Duplicate Customer.");
                }
                context.Customers.Add(entity);
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
                throw new OmsException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            try
            {
                var customer = context.Customers.Find(key);
                if (customer == null)
                {
                    throw new OmsException("Customer not found");
                }
                context.Customers.Remove(customer);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        public Customer Get(object key)
        {
            try
            {
                var existingEmployee = context.Customers.Find(key);
                if (existingEmployee == null)
                {
                    throw new OmsException("Employee not found");
                }
                return existingEmployee;
            }
            catch (OmsException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        public IEnumerable<Customer> Get()
        {
            var list = context.Customers.ToList();
            return list;
        }

        public bool Update(Customer entity)
        {
            try
            {
                var existingCustomer = context.Customers.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
                if (existingCustomer == null)
                {
                    throw new OmsException("Customer not found.");
                }
                context.Customers.Update(entity);
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
                throw new OmsException(ex.Message);
            }
        }
    }
}
