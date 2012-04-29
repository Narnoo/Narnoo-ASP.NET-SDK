using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorChannelsResponse
    {
        public DistributorChannelsResponse()
        {
            this.distributor_channel_list = new List<ChannelResponse>();
        }
        public List<ChannelResponse> distributor_channel_list
        {
            get;
            set;
        }
    }
}
