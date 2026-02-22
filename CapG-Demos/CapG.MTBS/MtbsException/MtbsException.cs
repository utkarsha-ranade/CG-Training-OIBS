using System;
using System.Runtime.Serialization;

namespace CapG.MTBS.Exceptions
{
    public class MtbsException : ApplicationException
    {
        public MtbsException()
        {
        }

        public MtbsException(string message) : base(message)
        {
        }

        public MtbsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MtbsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
