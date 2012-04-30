using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaResponse
    {
        public SearchMediaImage search_media_image
        {
            get;
            set;
        }

        public SearchMediaBrochure search_media_brochure
        {
            get;
            set;
        }

        public SearchMediaVideo search_media_video
        {
            get;
            set;
        }
    }
}
