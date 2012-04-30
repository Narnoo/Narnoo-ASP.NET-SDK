using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorBrochuresResponse
    {
        public OperatorBrochuresResponse()
        {
            this.operator_brochures = new List<BrochureResponse>();
        }
        public List<BrochureResponse> operator_brochures
        {
            get;
            set;
        }
    }
}
