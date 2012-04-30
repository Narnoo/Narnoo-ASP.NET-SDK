using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorVideoDetailsResponse
    {
        public DistributorVideoDetailsResponse()
        {
            this.distributor_video_details = new List<DistributorVideoResponse>();
        }
        public List<DistributorVideoResponse> distributor_video_details
        {
            get;
            set;
        }
    }
}
