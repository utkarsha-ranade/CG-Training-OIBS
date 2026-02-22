using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOdd.Library
{
    public class EvenOdd
    {
        public static Boolean isEven(int Num)
        {
            if(Num % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
