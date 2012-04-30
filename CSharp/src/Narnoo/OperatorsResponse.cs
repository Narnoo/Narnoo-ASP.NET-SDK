using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorsResponse
    {
        public OperatorsResponse()
        {
            this.operators = new List<OperatorResponse>();
        }

        public List<OperatorResponse> operators
        {
            get;
            set;
        }
    }
}
