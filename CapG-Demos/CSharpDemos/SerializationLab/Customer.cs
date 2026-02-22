using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLab
{
    [Serializable]
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}\tName: {Name}\tDOB: {DOB.ToShortDateString()}";
        }
    }
}
