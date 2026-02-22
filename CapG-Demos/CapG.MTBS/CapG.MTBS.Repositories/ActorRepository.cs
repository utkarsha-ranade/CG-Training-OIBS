using CapG.MTBS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;
using CapG.MTBS.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CapG.MTBS.Repositories
{
    public class ActorRepository : IRepository<Actor>
    {
        private readonly MTBSContext context;

        public ActorRepository(MTBSContext context)
        {
            this.context = context;
        }

        public bool Add(Actor entity)
        {
            try
            {
                //duplicate
                var actor = context.Actors.FirstOrDefault(m =>
                    m.Name == entity.Name &&
                    m.DateOfBirth.Date == entity.DateOfBirth.Date);
                if (actor != null)
                {
                    throw new MtbsException("Actor already exists");
                }
                //add
                context.Actors.Add(entity);
                int recordsAffected = context.SaveChanges();
                if(recordsAffected > 0)
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
            try
            {
                var actor = context.Actors.Find(key);
                if (actor == null)
                {
                    throw new MtbsException("Actor Not Found");
                }

                context.Actors.Remove(actor);

                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                    return true;

                return false;
            }
            catch (SqlException e)
            {
                throw new MtbsException(e.Message);
            }
        }

        public Actor Get(object key)
        {
            try
            {
                var actors = context.Actors.Find(key);
                return actors;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public IEnumerable<Actor> Get()
        {
            var list = context.Actors.ToList();
            return list;
        }

        public bool Update(Actor entity)
        {
            try
            {
                var existingActor = context.Customers.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
                context.Actors.Update(entity);
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
