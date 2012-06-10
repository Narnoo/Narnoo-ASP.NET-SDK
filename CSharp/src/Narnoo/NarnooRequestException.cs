using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{

    [Serializable]
    public class NarnooRequestException : Exception
    {
        public NarnooRequestException() { }
        public NarnooRequestException(string message) : base(message) { }
        public NarnooRequestException(string message, Exception inner) : base(message, inner) { }
        protected NarnooRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
