using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorSingleBrochuresResponse
    {
        public DistributorSingleBrochuresResponse()
        {
            this.distributor_brochure = new List<DistributorSingleBrochureResponse>();
        }
        public List<DistributorSingleBrochureResponse> distributor_brochure
        {
            get;
            set;
        }
    }
}
