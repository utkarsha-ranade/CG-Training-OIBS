using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capgemini.OIBS.Repositories
{
    public class InterestRepository
    {
        OIBS_DBcontext context;
        public InterestRepository(OIBS_DBcontext context)
        {
            this.context = context;
        }
        public bool Add(InterestDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public Interest Get(object key)
        {
            try
            {
                var exist = context.Interests.Find(key);
                if (exist == null)
                {
                    throw new OIBSException("Interest Entry Not Found");
                }
                return exist;
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
            }
        }

        public IEnumerable<Interest> Get()
        {
            return context.Interests.ToList();
        }

        public bool Update(InterestDTO entity)
        {
            try
            {
                var existInterest = context.Interests.FirstOrDefault(ex => ex.AccountNo == entity.AccountNo);
                if (existInterest == null)
                {
                    throw new OIBSException("Interest Entry Does Not Exist");
                }
                var existAccount = context.Accounts.FirstOrDefault(ex => ex.AccountNo == entity.AccountNo);
                if (existAccount == null)
                {
                    throw new OIBSException("Account Does Not Exist");
                }
                double interest = (existAccount.Balance + existAccount.InterestAmount) * existInterest.Rate / 1200;
                interest += existInterest.InterestAmount;
                
                existInterest.InterestAmount = interest;
                existInterest.Account.InterestAmount = interest;
                
                context.Interests.Update(existInterest);
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
