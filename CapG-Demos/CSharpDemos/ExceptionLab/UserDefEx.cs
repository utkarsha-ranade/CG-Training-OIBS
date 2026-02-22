using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLab
{
    internal class UserDefEx : ApplicationException
    {
        public UserDefEx()
        {
        }

        public UserDefEx(string message) : base(message)
        {
        }

        public UserDefEx(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserDefEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
