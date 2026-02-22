using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MTBSContext context;
        private readonly IConfiguration config;

        public TicketRepository(MTBSContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public bool Add(Ticket entity)
        {
            try
            {
                //var existingTicket = context.Tickets.FirstOrDefault(t => t.UserId == entity.UserId && t.MovieId == entity.MovieId);
                //if (existingTicket != null)
                //{
                //    throw new MtbsException("Duplicate Ticket.");
                //}
                //context.Tickets.Add(entity);
                //int recordsAffected = context.SaveChanges();
                //if (recordsAffected > 0)
                //{
                //    return true;
                //}
                //else
                //    return false;
                
                bool isUploaded = Helper.UploadBlob(config, entity).Result;
                return isUploaded;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public bool Cancel(int id)
        {
            try
            {
                var ticket = context.Tickets.Find(id);
                if (ticket == null)
                {
                    throw new MtbsException("Ticket not found");
                }
                ticket.IsCanceled = true;
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(object key)
        {
            try
            {
                var existingTicket = context.Tickets.Find(key);
                if (existingTicket == null)
                {
                    throw new MtbsException("Ticket not found");
                }
                return existingTicket;
            }
            catch (MtbsException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public IEnumerable<Ticket> Get()
        {
            var list = context.Tickets.ToList();
            return list;
        }

        public bool Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
