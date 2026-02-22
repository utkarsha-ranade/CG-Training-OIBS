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
    public class ProductRepository : IRepository<Product>
    {
        private OMSContext context;
        public ProductRepository(OMSContext context)
        {
            this.context = context;
        }
        public bool Add(Product entity)
        {
            try
            {
                var existingProduct = context.Products.FirstOrDefault(e => e.Name == entity.Name);
                if (existingProduct != null)
                {
                    throw new OmsException("Duplicate Product.");
                }
                context.Products.Add(entity);
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
                var product = context.Products.Find(key);
                if (product == null)
                {
                    throw new OmsException("Product not found");
                }
                context.Products.Remove(product);
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

        public Product Get(object key)
        {
            try
            {
                var existingProduct = context.Products.Find(key);
                if (existingProduct == null)
                {
                    throw new OmsException("Employee not found");
                }
                return existingProduct;
            }
            catch (OmsException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        public IEnumerable<Product> Get()
        {
            var list = context.Products.ToList();
            return list;
        }

        public bool Update(Product entity)
        {
            try
            {
                var existingProduct = context.Products.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
                if (existingProduct == null)
                {
                    throw new OmsException("Product not found.");
                }
                context.Products.Update(entity);
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
