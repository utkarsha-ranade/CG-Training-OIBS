using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNo.Library
{
    public class Prime
    {
        public static Boolean isPrime(int Num)
        {
            if (Num <= 1)
                return false;

            for (int i = 2; i < Num; i++)
            {
                if (Num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
