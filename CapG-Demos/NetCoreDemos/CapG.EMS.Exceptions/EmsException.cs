using System;
using System.Runtime.Serialization;

namespace CapG.EMS.Exceptions
{
    public class EmsException : ApplicationException
    {
        public EmsException()
        {
        }

        public EmsException(string message) : base(message)
        {
        }

        public EmsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
