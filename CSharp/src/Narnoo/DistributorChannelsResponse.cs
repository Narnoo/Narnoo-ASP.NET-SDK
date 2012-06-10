using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorChannelsResponse:NarnooCollectionResponse
    {
        public DistributorChannelsResponse()
        {
            this.distributor_channel_list = new List<Channel>();
        }
        public List<Channel> distributor_channel_list
        {
            get;
            set;
        }
    }
}
