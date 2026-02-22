using CapG.OMS.Exceptions;
using CapG.OMS.Models;
using CapG.OMS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CapG.OMS.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OMSContext context;
        public OrderRepository(OMSContext context)
        {
            this.context = context;
        }

        public bool Add(OrderInputDto entity)
        {
            List<Product> productList = new List<Product>();   
            try
            {
                foreach (var item in entity.OrderItems)
                {
                    var product = context.Products.Find(item.ProductId);
                    if(product == null)
                    {
                        throw new OmsException("Product does not exist");
                    }
                    else
                    {
                        productList.Add(product);
                    }
                }
                //order
                Order newOrder = new Order
                {
                    CustomerId = entity.CustomerID
                };
                //orderItem
                List<OrderItem> items = new List<OrderItem>();
                foreach (var product in productList)
                {
                    OrderItem item = new OrderItem
                    {
                        ProductId = product.Id,
                        Price = product.Price,
                        Quantity = entity.OrderItems.FirstOrDefault(oi => oi.ProductId == product.Id).Quantity,
                        OrderId = newOrder.Id
                    };
                    items.Add(item);
                }
                newOrder.OrderItems = items;
                context.Orders.Add(newOrder);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool Cancel(int id)
        {
            try
            {
                var order = context.Orders.Find(id);
                if (order == null)
                {
                    throw new OmsException("Order not found");
                }
                order.IsCanceled = true;
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
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
                var order = context.Orders.Find(key);
                if (order == null)
                {
                    throw new OmsException("Employee not found");
                }
                context.Orders .Remove(order);
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

        public OrderInputDto Get(object key)
        {
            try
            {
                var order = context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == Convert.ToInt32(key));
                if(order == null)
                {
                    throw new OmsException("Order not found");
                }
                OrderInputDto orderDto = new OrderInputDto
                {
                    CustomerID = order.CustomerId,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                    }).ToList()
                };
                return orderDto;
            }
            catch (SqlException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        public IEnumerable<OrderInputDto> Get()
        {
            try
            {
                var list = context.Orders.Include(o => o.OrderItems).ToList();
                //transform from Order to Dto
                var dtos = list.Select(o => new OrderInputDto
                {
                    CustomerID = o.CustomerId,
                    OrderDate = o.OrderDate,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                    }).ToList()
                });
                return dtos;
            }
            catch (SqlException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        public bool Update(OrderInputDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
