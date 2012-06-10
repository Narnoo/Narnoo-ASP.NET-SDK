using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorImagesResponse:NarnooCollectionResponse
    {
        public OperatorImagesResponse()
        {
            this.operator_images = new List<Image>();
        }

        public List<Image> operator_images
        {
            get;
            set;
        }
    }
}
