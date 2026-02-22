using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    internal class BooksDemo
    {
        private string[] colName = { "BookTitle", "Author", "Publisher", "Price" };
        private string[,] bookDetails = new string[2,4];
        static void Main(string[] args)
        {
            BooksDemo demo = new BooksDemo();
            //Read Data
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < demo.colName.Length; j++)
                {
                    Console.WriteLine($"Enter {demo.colName[j]} : ");
                    demo.bookDetails[i, j] = Console.ReadLine();
                }
            }
            Console.WriteLine();

            //Display Data
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < demo.colName.Length; j++)
                {
                    Console.WriteLine($"{demo.colName[j]} : {demo.bookDetails[i, j]}");
                }
            }
            Console.Read();
        }
    }
}
