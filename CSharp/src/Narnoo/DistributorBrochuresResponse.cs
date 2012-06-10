using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorBrochuresResponse:NarnooCollectionResponse
    {
        public OperatorBrochuresResponse()
        {
            this.operator_brochures = new List<Brochure>();
        }
        public List<Brochure> operator_brochures
        {
            get;
            set;
        }
    }
}
