using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorImagesResponse
    {
        public OperatorImagesResponse()
        {
            this.operator_images = new List<ImageResponse>();
        }

        public List<ImageResponse> operator_images
        {
            get;
            set;
        }
    }
}
