using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorVideosResponse:NarnooCollectionResponse
    {
        public DistributorVideosResponse()
        {
            this.distributor_videos = new List<Video>();
        }

        public List<Video> distributor_videos
        {
            get;
            set;
        }
    }
}
