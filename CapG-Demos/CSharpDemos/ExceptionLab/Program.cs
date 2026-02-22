using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            try
            {
                int num = numbers[3];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                throw new UserDefEx(ex.Message);
            }
        }
    }
}
