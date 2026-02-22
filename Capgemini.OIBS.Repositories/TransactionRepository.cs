using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capgemini.OIBS.Repositories
{
    public class TransactionRepository
    {
        OIBS_DBcontext context;
        public TransactionRepository(OIBS_DBcontext context)
        {
            this.context = context;
        }
        public bool Add(TransactionDTO entity)
        {
            try
            {
                var account = context.Accounts.FirstOrDefault(ac => ac.AccountNo == entity.AccountNo);
                if (account == null)
                {
                    throw new OIBSException("Account Not Found");
                }
                var user = context.Users.FirstOrDefault(ex=> ex.IsActive == true);
                Transaction transaction = new Transaction
                {
                    AccountNo = entity.AccountNo,
                    Amount = entity.Amount,
                    TransactionType = entity.TransactionType,
                    UserId = user.Id
                };
                if (account.UserId != user.Id)
                {
                    transaction.IsValid = false;
                    if (transaction.TransactionType == Transtype.Transfer)
                    {
                        transaction.TransactionType = Transtype.Withdraw;
                        context.Transactions.Add(transaction);
                        var account1 = context.Accounts.FirstOrDefault(ac => ac.AccountNo == entity.DestinationAccountNo);
                        if (account1 == null)
                        {
                            throw new OIBSException("Account for Deposit Not Found");
                        }
                        if(entity.Amount < 1000)
                        {
                            throw new OIBSException("Transaction amount should be greater than 999");
                        }
                        Transaction transaction1 = new Transaction
                        {
                            AccountNo = entity.DestinationAccountNo,
                            Amount = entity.Amount,
                            TransactionType = Transtype.Deposit,
                            UserId = user.Id
                        };
                        transaction1.IsValid = false;
                        context.Transactions.Add(transaction1);
                    }
                    else
                    {
                        transaction.TransferId = null;
                        context.Transactions.Add(transaction);
                    }
                }
                else
                {
                    if (transaction.TransactionType == Transtype.Transfer)
                    {
                        transaction.TransactionType = Transtype.Withdraw;
                        int? id = context.Transactions.Max(a => a.TransferId);
                        if (id == null)
                            id = 1;
                        transaction.TransferId = id+1;
                        context.Transactions.Add(transaction);
                        if (account.Balance - entity.Amount >= 5000)
                        {
                            account.Balance -= entity.Amount;
                        }
                        else
                        {
                            throw new OIBSException("Balance should be minimum 5000/-");
                        }
                        var account1 = context.Accounts.FirstOrDefault(ac => ac.AccountNo == entity.DestinationAccountNo);
                        if (account1 == null)
                        {
                            throw new OIBSException("Account for Deposit Not Found");
                        }
                        Transaction transaction1 = new Transaction
                        {
                            AccountNo = entity.DestinationAccountNo,
                            Amount = entity.Amount,
                            TransactionType = Transtype.Deposit,
                            UserId = user.Id,
                            TransferId = id+1
                        };

                        context.Transactions.Add(transaction1);
                        account1.Balance += entity.Amount;
                    }
                    else
                    {
                        transaction.TransferId = null;
                        context.Transactions.Add(transaction);
                        if (transaction.TransactionType == Transtype.Withdraw)
                        {
                            if (account.Balance - entity.Amount >= 5000)
                                account.Balance -= entity.Amount;
                            else
                                throw new OIBSException("Balance should be minimum 5000 / -");
                        }
                        else
                        {
                            account.Balance += entity.Amount;
                        }
                    }
                }

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
        public Transaction Get(int key)
        {
            try
            {
                var exist = context.Transactions.Find(key);
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

        public IEnumerable<Transaction> Get()
        {
            return context.Transactions.ToList();
        }

        public IEnumerable<ReportDTO> Report(int key)
        {
            var list = context.Transactions.Where(tr => tr.UserId == key).ToList();
            List<ReportDTO> report = new List<ReportDTO>();
            foreach (var item in list)
            {
                ReportDTO reportObject = new ReportDTO();
                reportObject.AccountNo = item.AccountNo;
                reportObject.Amount = item.Amount;
                reportObject.TransferId = item.TransferId;
                reportObject.DateOfTransaction = item.DateOfTransaction;
                reportObject.TransactionType = item.TransactionType;
                reportObject.IsValid = item.IsValid;
                report.Add(reportObject);
            }
            return report;
        }
    }
}
