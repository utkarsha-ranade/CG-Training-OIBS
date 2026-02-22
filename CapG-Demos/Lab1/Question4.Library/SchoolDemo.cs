using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4.Library
{
    public class SchoolDemo
    {
        public int rollNumber { get; set; }
        public string studentName { get; set; }
        public byte age { get; set; }
        public char gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string address { get; set; }
        public float percentage { get; set; }
        public override string ToString()
        {
            return $"RollNo : {rollNumber}\nName : {studentName}\nAge : {age}\nGender : {gender}\nDOB : {dateOfBirth}\nAddress : {address}\nPercentage : {percentage}";
        }
    }
}
