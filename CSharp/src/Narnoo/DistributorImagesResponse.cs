using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorImagesResponse:NarnooCollectionResponse
    {
        public DistributorImagesResponse()
        {
            this.distributor_images = new List<Image>();
        }

        public List<Image> distributor_images
        {
            get;
            set;
        }
    }
}
