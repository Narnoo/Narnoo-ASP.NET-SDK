using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorAlbumsResponse
    {
        public DistributorAlbumsResponse()
        {
            this.distributor_albums = new List<AlbumResponse>();
        }

        public List<AlbumResponse> distributor_albums
        {
            get;
            set;
        }
    }
}
