using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class AlbumImagesResponse
    {
        public AlbumImagesResponse()
        {
            this.distributor_albums_images = new List<AlbumImageResponse>();
        }
        public List<AlbumImageResponse> distributor_albums_images
        {
            get;
            set;
        }
    }
}
