using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorChannelVideosResponse
    {
        public DistributorChannelVideosResponse()
        {
            this.distributor_channel_videos = new List<ChannelVideoResponse>();
        }
        public List<ChannelVideoResponse> distributor_channel_videos
        {
            get;set;
        }
    }
}
