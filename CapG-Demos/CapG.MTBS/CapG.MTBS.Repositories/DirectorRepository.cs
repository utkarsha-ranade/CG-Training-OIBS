using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public class DirectorRepository : IRepository<Director>
    {
        private readonly MTBSContext context;

        public DirectorRepository(MTBSContext context)
        {
            this.context = context;
        }

        public bool Add(Director entity)
        {
            try
            {
                //duplicate
                var director = context.Directors.FirstOrDefault(m => m.Name == entity.Name);
                if (director != null)
                {
                    throw new MtbsException("Director already exists");
                }
                //add
                context.Directors.Add(entity);
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
            try
            {
                var director = context.Directors.FirstOrDefault(d => d.
                    Id == (int)key);

                if (director == null)
                    throw new MtbsException("Director Doesn't Exists");

                context.Directors.Remove(director);

                if (context.SaveChanges() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (SqlException e)
            {
                throw new MtbsException(e.Message);
            }
        }

        public Director Get(object key)
        {
            try
            {
                var directors = context.Directors.Find(key);
                return directors;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public IEnumerable<Director> Get()
        {
            var list = context.Directors.ToList();
            return list;
        }

        public bool Update(Director entity)
        {
            try
            {
                var director = context.Directors.AsNoTracking()
                    .FirstOrDefault(d => d.Id == entity.Id);

                if (director == null)
                    throw new MtbsException("Director Does Not Exists");

                var dupdirector = context.Directors.FirstOrDefault(d => d.Name
                    == entity.Name && d.Id != entity.Id);

                if (dupdirector != null)
                    throw new MtbsException("Director Already Exists");

                context.Directors.Update(director);

                if (context.SaveChanges() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (SqlException e)
            {
                throw new MtbsException(e.Message);
            }
        }
    }
}
