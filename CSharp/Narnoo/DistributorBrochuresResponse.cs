using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorBrochuresResponse
    {
        public DistributorBrochuresResponse()
        {
            this.distributor_brochures = new List<BrochureResponse>();
        }
        public List<BrochureResponse> distributor_brochures
        {
            get;
            set;
        }
    }
}
