using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorAlbumImagesResponse
    {
        public OperatorAlbumImagesResponse()
        {
            this.operator_albums_images = new List<AlbumImageResponse>();
        }
        public List<AlbumImageResponse> operator_albums_images
        {
            get;
            set;
        }
    }
}
