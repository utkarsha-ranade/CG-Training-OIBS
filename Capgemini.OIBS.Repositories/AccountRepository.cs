using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capgemini.OIBS.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        OIBS_DBcontext context;
        public AccountRepository(OIBS_DBcontext context)
        {
            this.context = context;
        }
        public bool Add(Account entity)
        {
            try
            {
                var exist = context.Accounts.FirstOrDefault(ex=> ex.AccountNo == Convert.ToInt64(1111111111));
                if (exist == null)
                {
                    entity.AccountNo = Convert.ToInt64(1111111111);
                }
                else
                {
                    entity.AccountNo = context.Accounts.Max(ex => ex.AccountNo) + 1;
                }
                var existUser = context.Users.FirstOrDefault(ex => ex.IsActive == true);
                if (existUser == null)
                {
                    throw new OIBSException("User is not Active");
                }
                if(existUser.IsVerified == false)
                {
                    throw new OIBSException("User is not Verified");
                }
                entity.UserId = existUser.Id;
                context.Accounts.Add(entity);
                context.SaveChanges();
                var account = context.Accounts.FirstOrDefault(ex => ex.AccountNo == entity.AccountNo);
                Interest interest = new Interest
                {
                    AccountId = account.Id,
                    AccountNo = account.AccountNo,
                    AccountType = account.AccountType
                };
                if (interest.AccountType == type.Savings)
                    interest.Rate = 5;
                else
                    interest.Rate = 7;
                context.Interests.Add(interest);

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
                var exist = Get(key);
                if (exist == null)
                    throw new OIBSException("Account With Given Id Does Not Exist");
                var user = context.Users.FirstOrDefault(ex => ex.IsActive == true);
                var list = context.Accounts.Where(tr => tr.UserId == user.Id).ToList();
                Account account = null;
                foreach (var item in list)
                {
                    if (item.Id == (int)key)
                    {
                        account = item;
                        break;
                    }
                }
                if (account == null)
                {
                    throw new OIBSException("Account does not Exist for the Active user");
                }
                var nominee = context.Nominees.FirstOrDefault(ex=> ex.AccountId == exist.Id);
                user = context.Users.FirstOrDefault(ex => ex.Id == exist.UserId);
                if (nominee != null)
                {
                    context.Nominees.Remove(nominee);
                }
                context.Accounts.Remove(exist);
                
                var interest = context.Interests.FirstOrDefault(ex=> ex.AccountId == exist.Id);
                context.Interests.Remove(interest);
                context.SaveChanges();

                account = context.Accounts.FirstOrDefault(ex => ex.UserId == user.Id);
                if(account==null)
                    context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (SqlException e)
            {
                throw new OIBSException(e.Message);
            }
        }

        public Account Get(object key)
        {
            try
            {
                var exist = context.Accounts.FirstOrDefault(ex=>ex.Id == (int)key);
                if (exist == null)
                {
                    throw new OIBSException("Account Not Found");
                }
                return exist;
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
            }
        }

        public IEnumerable<Account> Get()
        {
            return context.Accounts.ToList();
        }

        public bool Update(Account entity)
        {
            try
            {
                var account = context.Accounts.AsNoTracking().FirstOrDefault(ex=> ex.Id == entity.Id);
                if (account == null)
                {
                    throw new OIBSException("Account does not Exist");
                }
                var user = context.Users.FirstOrDefault(ex => ex.IsActive == true);
                var list = context.Accounts.AsNoTracking().Where(tr => tr.UserId == user.Id).ToList();
                account = null;
                foreach (var item in list)
                {
                    if (item.Id == entity.Id)
                    {
                        account = item;
                        break;
                    }
                }
                if (account == null)
                {
                    throw new OIBSException("Account does not Exist for the Active user");
                }
                entity.AccountNo = account.AccountNo;
                entity.UserId = account.UserId;
                entity.InterestAmount = account.InterestAmount;
                
                var interest = context.Interests.Find(entity.Id);
                interest.AccountType = entity.AccountType;
                if (interest.AccountType == type.Savings)
                    interest.Rate = 5;
                else
                    interest.Rate = 7;
                
                context.Accounts.Update(entity);
                context.Interests.Update(interest);
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
