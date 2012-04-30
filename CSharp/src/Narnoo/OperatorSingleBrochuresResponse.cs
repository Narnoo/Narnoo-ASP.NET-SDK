using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorSingleBrochuresResponse
    {
        public OperatorSingleBrochuresResponse()
        {
            this.operator_brochures = new List<OperatorSingleBrochureResponse>();
        }
        public List<OperatorSingleBrochureResponse> operator_brochures
        {
            get;
            set;
        }
    }
}
