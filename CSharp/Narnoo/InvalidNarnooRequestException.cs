using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    [Serializable]
    public class InvalidNarnooRequestException : Exception
    {
        public InvalidNarnooRequestException() { }
        public InvalidNarnooRequestException(string errorCode, string errorMessage):base(errorMessage)
        {
            this.Error = new NarnooError
            {
                ErrorCode = errorCode
                ErrorMessage = errorMessage
            };
        }
        public InvalidNarnooRequestException(string message) : base(message) {
            this.Error = new NarnooError
            {
                ErrorMessage = message
            };
        }
        public InvalidNarnooRequestException(string message, Exception inner) : base(message, inner) {
            this.Error = new NarnooError
            {
                ErrorMessage = message
            };
        }
        protected InvalidNarnooRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) {
                this.Error = new NarnooError();
        }

      

        public NarnooError Error
        {
            get;
            set;
        }

    }
}
