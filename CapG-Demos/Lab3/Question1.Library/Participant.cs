using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1.Library
{
    public class Participant
    {
        //Task1
        private int empId;
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private static string companyName;
        public static string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private int foundationMarks;
        public int FoundationMarks
        {
            get { return foundationMarks; }
            set { foundationMarks = value; }
        }

        private int webBasicMarks;
        public int WebBasicMarks
        {
            get { return webBasicMarks; }
            set { webBasicMarks = value; }
        }

        private int dotNetMarks;
        public int DotNetMarks
        {
            get { return dotNetMarks; }
            set { dotNetMarks = value; }
        }

        private const int totalMarks = 300;
        public int TotalMarks
        {
            get { return totalMarks; }
        }

        private int obtainedMarks;
        public int ObtainedMarks
        {
            get { return obtainedMarks; }
            set { obtainedMarks = value; }
        }

        private double percentage;
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
        //Task2
        public Participant() { }                           //Default Constructor

        public Participant(int empId, string name, int foundationMarks, int webBasicMarks, int dotNetMarks)           //Parameterised Constructor
        {
            this.empId = empId;
            this.name = name;
            this.foundationMarks = foundationMarks;
            this.webBasicMarks = webBasicMarks;
            this.dotNetMarks = dotNetMarks;
        }
        static Participant()                                //Static Constructor
        {
            companyName = "Corporate Unniversity";
        }
        //Task3
        public void CalculateTotalMarks()
        {
            obtainedMarks += foundationMarks + webBasicMarks + dotNetMarks;
        }
        public void CalculatePercentage()
        {
            percentage = ((double)obtainedMarks / (double)totalMarks) * 100.0;
        }
        public double getPercentage()
        {
            return percentage;
        }
    }
}