using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DistributorImagesResponse
    {
        public DistributorImagesResponse()
        {
            this.distributor_images = new List<ImageResponse>();
        }

        public List<ImageResponse> distributor_images
        {
            get;
            set;
        }
    }
}
