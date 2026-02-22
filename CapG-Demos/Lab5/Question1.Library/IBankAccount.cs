using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1.Library
{
    public enum BankAccountTypeEnum
    {
        Current = 1, Saving = 2
    }
    public interface IBankAccount
    {
        double GetBalance();
        bool Withdraw(double amount);
        bool Transfer(IBankAccount toAccount, double amount);
        BankAccountTypeEnum AccountType { get; set; }
    }

    public abstract class BankAccount : IBankAccount
    {
        protected double balance;
        public BankAccountTypeEnum AccountType { get; set; }

        public BankAccount(double amount)
        {
            balance = amount;
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("The amount has been deposited.");
                return true;
            }
            return false;
        }

        public abstract bool Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("The amount has been withdrawed.");
                return true;
            }
            return false;
        }
        public abstract bool Transfer(IBankAccount toAccount, double amount);
        //{
            //return (this.Deposit(amount) && toAccount.Withdraw(amount));
        //}
        public double GetBalance()
        {
            return balance;
        }
    }

    class ICICI : BankAccount // Inherit this from BankAccount
    {
        public ICICI(double amount) : base(amount)
        { }
        public override bool Withdraw(double amount)
        {
            // If Balance – amount is >= 0 then only WithDraw is possible.
            // Write the code to achieve the same.
            if (balance - amount >= 0)
            {
                balance -= amount;
                Console.WriteLine("The amount has been withdrawed.");
                return true;
            }
            return false;
        }

        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            // If Balance – Withdraw is >= 1000 then only transfer can take place.
            // Write the code to achieve the same.
            if (balance - amount >= 1000)
            {
                return (this.Deposit(amount) && toAccount.Withdraw(amount));
            }
            return false;
        }
    }

    class HSBC : BankAccount // Inherit this from BankAccount
    {
        public HSBC(double amount) : base(amount)
        {}
        public override bool Withdraw(double amount)
        {
            // If Balance – amount is >= 5000 then only WithDraw is possible.
            // Write the code to achieve the same.

            if (balance - amount >= 5000)
            {
                balance -= amount;
                Console.WriteLine("The amount has been withdrawed.");
                return true;
            }
            return false;
        }

        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            // If Balance – Withdraw is >= 5000 then only transfer can take place.
            // Write the code to achieve the same.
            if (balance - amount >= 5000)
            {
                return (this.Deposit(amount) && toAccount.Withdraw(amount));
            }
            return false;
        }
    }
}
