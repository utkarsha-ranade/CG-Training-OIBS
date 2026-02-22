using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Program
    {
        public delegate void SendMessage(string message);
        public class CreditCard
        {
            public string CreditCardNo { get; set; }
            public string CardHolderName { get; set; }
            public double BalanceAmount { get; set; }
            public double CreditLimit { get; set; }
            public CreditCard(string creditcardno, string cardholdername, double balanceamount, double creditlimit)
            {
                this.CreditCardNo = creditcardno;
                this.CardHolderName = cardholdername;
                this.BalanceAmount = balanceamount;
                this.CreditLimit = creditlimit;
            }
            public double GetBalance()
            {
                return BalanceAmount;
            }
            public double GetCreditCardLimit()
            {
                return CreditLimit;
            }
            public void MakePayment(double amount)
            {
                if (paymentIsMade != null)
                {
                    if (amount <= CreditLimit)
                    {
                        this.BalanceAmount -= amount;
                        paymentIsMade(string.Format("{0} has made payment for amount {1}. The balance is {2} now", this.CardHolderName, amount, this.BalanceAmount));
                    }
                    else
                    {
                        paymentIsMade(string.Format("The customer wiht credit card no {0} has a credit limit {1}!", this.CreditCardNo, CreditLimit));
                    }
                }
            }
            public event SendMessage paymentIsMade;
        }
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard("1479632582", "Sid Adams", 15000, 5000);
            creditCard.paymentIsMade += ShowSMS;
            creditCard.MakePayment(250);
            creditCard.MakePayment(2000);
            Console.ReadLine();
        }
        static void ShowSMS(string message)
        {
            Console.WriteLine(message);
        }
    }
}
