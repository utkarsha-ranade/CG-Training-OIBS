using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodLab
{
    internal static class Extensions
    {
        public static int ToNumber(this string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
