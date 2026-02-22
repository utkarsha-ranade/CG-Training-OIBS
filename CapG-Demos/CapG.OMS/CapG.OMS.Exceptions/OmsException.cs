using System;
using System.Runtime.Serialization;

namespace CapG.OMS.Exceptions
{
    public class OmsException : ApplicationException
    {
        public OmsException()
        {
        }

        public OmsException(string message) : base(message)
        {
        }

        public OmsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OmsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
