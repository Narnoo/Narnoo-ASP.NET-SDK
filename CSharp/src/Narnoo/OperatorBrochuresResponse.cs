using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorBrochuresResponse:NarnooCollectionResponse
    {
        public DistributorBrochuresResponse()
        {
            this.distributor_brochures = new List<Brochure>();
        }
        public List<Brochure> distributor_brochures
        {
            get;
            set;
        }
    }
}
