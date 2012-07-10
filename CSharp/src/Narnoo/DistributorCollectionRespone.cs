using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorCollectionRespone:NarnooCollectionResponse
    {
        public DistributorCollectionRespone()
        {
            this.distributors = new List<Distributor>();
        }

        public List<Distributor> distributors
        {
            get;
            set;
        }
    }
}
