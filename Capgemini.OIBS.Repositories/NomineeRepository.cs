using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.OIBS.Repositories
{
    public class NomineeRepository : IRepository<Nominee>
    {
        private OIBS_DBcontext context;
        public NomineeRepository(OIBS_DBcontext context)
        {
            this.context = context;
        }
        public bool Add(Nominee entity)
        {
            try
            {
                var exists = context.Nominees.FirstOrDefault(ex => ex.Email == entity.Email);
                if (exists != null)
                {
                    throw new OIBSException("Duplicate Nominee");
                }
               
                var user = context.Users.FirstOrDefault(ex=> ex.IsActive == true);
                if(user == null)
                {
                    throw new OIBSException("User is not Active");
                }
                var existAccount = context.Accounts.Find(entity.AccountId);
                if (existAccount == null)
                {
                    throw new OIBSException("Account does not Exist");
                }
                var list = context.Accounts.Where(tr => tr.UserId == user.Id).ToList();
                Account account = null;
                foreach (var item in list)
                {
                    if (item.Id == entity.AccountId)
                    {
                        account = item;
                        break;
                    }
                }
                if(account == null)
                {
                    throw new OIBSException("Account does not Exist for the Active user");
                }
                var nominee = context.Nominees.FirstOrDefault(ex => ex.AccountId == entity.AccountId);
                if (nominee != null)
                {
                    throw new OIBSException("Cant have 2 Nominees on 1 Account");
                }
                entity.AccountNo = account.AccountNo;
                context.Nominees.Add(entity);
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
            try
            {
                var exists = context.Nominees.FirstOrDefault(ex => ex.Id == (int)key);
                if (exists == null)
                {
                    throw new OIBSException("Nominee Does Not Exist.");
                }
                var account = context.Accounts.Find(exists.AccountId);
                var user = context.Users.Find(account.UserId);
                if (user.IsActive == false)
                {
                    throw new OIBSException("Can't Delete Nominee");
                }
                context.Nominees.Remove(exists);

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

        public Nominee Get(object key)
        {
            try
            {
                var exist = context.Nominees.Find(key);
                if (exist == null)
                {
                    throw new OIBSException("Nominee Not Found");
                }
                return exist;
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
            }
        }

        public IEnumerable<Nominee> Get()
        {
            return context.Nominees.ToList();
        }

        public bool Update(Nominee entity)
        {
            try
            {
                var exists = context.Nominees.AsNoTracking().FirstOrDefault(ex => ex.Id == entity.Id);
                if (exists == null)
                {
                    throw new OIBSException("Nominee Does Not Exist.");
                }
                var account = context.Accounts.Find(exists.AccountId);
                var user = context.Users.Find(account.UserId);
                if(user.IsActive == false)
                {
                    throw new OIBSException("Can't Update Nominee");
                }
                entity.AccountId = exists.AccountId;
                entity.AccountNo = exists.AccountNo;
                context.Nominees.Update(entity);

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
    }
}
