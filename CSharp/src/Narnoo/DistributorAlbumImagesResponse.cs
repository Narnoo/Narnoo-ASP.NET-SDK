using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorAlbumImagesResponse:NarnooCollectionResponse
    {
        public DistributorAlbumImagesResponse()
        {
            this.distributor_albums_images = new List<AlbumImage>();
        }
        public List<AlbumImage> distributor_albums_images
        {
            get;
            set;
        }
    }
}
