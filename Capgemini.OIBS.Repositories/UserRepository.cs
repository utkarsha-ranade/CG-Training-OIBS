using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.OIBS.Repositories
{
    public class UserRepository
    {
        private OIBS_DBcontext context;
        public UserRepository(OIBS_DBcontext context)
        {
            this.context = context;
        }
        public bool Add(User entity)
        {
            try
            {
                var exists = context.Users
                    .FirstOrDefault(ex => ex.Email == entity.Email || ex.UserName == entity.UserName || ex.MobileNo == entity.MobileNo);
                if (exists != null)
                {
                    throw new OIBSException("Duplicate User");
                }

                context.Users.Add(entity);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }

                return false;
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public User Get(object key)
        {
            try
            {
                var exist = context.Users.Find(key);
                if (exist == null)
                {
                    throw new OIBSException("User Not Found");
                }
                return exist;
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
            }
        }

        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }

        public bool Update(User entity)
        {
            try
            {
                var user = context.Users.FirstOrDefault(ex=> ex.IsActive == true);
                var canReject = context.Users.AsNoTracking().FirstOrDefault
                    (ex => ex.Id == user.Id && 
                    (ex.UserName != entity.UserName || ex.MobileNo != entity.MobileNo));
                
                if (canReject != null)
                {
                    throw new OIBSException("Cannot Update User");
                }
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.DateOfBirth = entity.DateOfBirth;
                user.Gender = entity.Gender;
                user.Email = entity.Email;
                context.Users.Update(user);

                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new OIBSException(e.Message);
            }
            catch (SqlException e)
            {
                throw new OIBSException(e.Message);
            }
        }
        public bool Verify(object id)
        {
            var exists = context.Users.Find(id);
            if (exists == null)
            {
                throw new OIBSException("User Does Not Exist.");
            }
            if (exists.IsVerified == false)
            {
                exists.IsVerified = true;
                context.Users.Update(exists);
            }
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
