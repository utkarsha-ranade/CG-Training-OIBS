using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "123";
            int num = str.ToNumber();
            Console.WriteLine(num);

            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.Name = "Sam";
            emp1.DateofJoin = new DateTime(2000, 1, 10);

            Employee emp2 = new Employee             //Object initializer
            {
                Id = 2,
                Name = "Tom",
                DateofJoin = new DateTime(2000, 2, 18)
            };

            var emp3 = new                           //Anonymous Type - when type is not known
            {
                Id = 3,
                Name = "Jack",
                DateofJoin = new DateTime(2000, 6, 9)
            };

            List<Employee> emplist = new List<Employee>()
            {
                emp2,
                new Employee
                {
                    Id = 2,
                    Name = "Tom",
                    DateofJoin = new DateTime(2000, 2, 18)
                }
            };

            Console.Read();
        }
    }
}