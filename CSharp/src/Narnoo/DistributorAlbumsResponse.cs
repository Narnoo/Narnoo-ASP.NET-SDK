using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorAlbumsResponse:NarnooCollectionResponse
    {
        public DistributorAlbumsResponse()
        {
            this.distributor_albums = new List<Album>();
        }

        public List<Album> distributor_albums
        {
            get;
            set;
        }
    }
}
