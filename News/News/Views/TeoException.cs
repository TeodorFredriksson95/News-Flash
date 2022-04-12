using System;
using System.Runtime.Serialization;

namespace News.Views
{
    [Serializable]
    internal class TeoException : Exception
    {
        public TeoException()
        {
        }

        public TeoException(string message) : base(message)
        {
        }

        public TeoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TeoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}