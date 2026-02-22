using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1.Library
{
    public class Contact
    {
        public int ContactNo { get; set; }
        public string ContactName { get; set; }
        public string CellNo { get; set; }

        public override string ToString() => $"Contact : (No: {ContactNo}, Name: {ContactName}, Cell No: {CellNo})";
    }
}
