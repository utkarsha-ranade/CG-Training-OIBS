using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Capgemini.OIBS.Exceptions
{
    public class OIBSException: ApplicationException
    {
        public OIBSException(string message) : base(message)
        {
        }
    }
}
