using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorVideosResponse
    {
        public DistributorVideosResponse()
        {
            this.distributor_videos = new List<DistributorVideoResponse>();
        }

        public List<DistributorVideoResponse> distributor_videos
        {
            get;
            set;
        }
    }
}
