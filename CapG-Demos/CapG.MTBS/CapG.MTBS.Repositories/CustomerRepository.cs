using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapG.MTBS.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly MTBSContext context;
        public CustomerRepository(MTBSContext context)
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
                    throw new MtbsException("Duplicate Customer.");
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
                throw new MtbsException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            try
            {
                var customer = context.Customers.Find(key);
                if (customer == null)
                {
                    throw new MtbsException("Customer not found");
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
                throw new MtbsException(ex.Message);
            }
        }

        public Customer Get(object key)
        {
            try
            {
                var existingEmployee = context.Customers.Find(key);
                if (existingEmployee == null)
                {
                    throw new MtbsException("Employee not found");
                }
                return existingEmployee;
            }
            catch (MtbsException ex)
            {
                throw new MtbsException(ex.Message);
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
                    throw new MtbsException("Customer not found.");
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
                throw new MtbsException(ex.Message);
            }
        }
    }
}
