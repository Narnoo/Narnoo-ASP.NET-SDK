using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorAlbumImagesResponse:NarnooCollectionResponse
    {
        public OperatorAlbumImagesResponse()
        {
            this.operator_albums_images = new List<AlbumImage>();
        }
        public List<AlbumImage> operator_albums_images
        {
            get;
            set;
        }
    }
}
