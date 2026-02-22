using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4.Library
{
    public class Employee
    {
        public int EmployeeNo { get; set; }
        public string Name { get; set;}
        public double BasicSalary { get; set; }
        public double PF { get; set; }
        public override string ToString() => $"EmployeeNo : {EmployeeNo}\tName : {Name}\tBasic Salary : {BasicSalary}\tPF : {PF}";
        public Employee() { }
        public Employee(int employeeno, string name, double basicsalary, double pf)
        {
            this.EmployeeNo = employeeno;
            this.Name = name;
            this.BasicSalary = basicsalary;
            this.PF = pf;
        }
    }
}
