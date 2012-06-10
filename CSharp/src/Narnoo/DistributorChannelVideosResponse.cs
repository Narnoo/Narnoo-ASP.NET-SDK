using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorChannelVideosResponse:NarnooCollectionResponse
    {
        public DistributorChannelVideosResponse()
        {
            this.distributor_channel_videos = new List<ChannelVideo>();
        }
        public List<ChannelVideo> distributor_channel_videos
        {
            get;set;
        }
    }
}
