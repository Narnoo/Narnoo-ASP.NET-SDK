using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorsResponse : NarnooCollectionResponse
    {
        public OperatorsResponse()
        {
            this.operators = new List<Operator>();
        }

 

        public List<Operator> operators
        {
            get;
            set;
        }
    }
}
