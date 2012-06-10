using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaImagesResponse:NarnooCollectionResponse
    {
        public SearchMediaImagesResponse()
        {
            this.search_media = new List<SearchMediaImage>();
        }

        public List<SearchMediaImage> search_media
        {
            get;
            set;
        }
    }

    public class SearchMediaVideosResponse : NarnooCollectionResponse
    {
        public SearchMediaVideosResponse()
        {
            this.search_media = new List<SearchMediaVideo>();
        }

        public List<SearchMediaVideo> search_media
        {
            get;
            set;
        }
    }

    public class SearchMediaBrochuresResponse : NarnooCollectionResponse
    {
        public SearchMediaBrochuresResponse()
        {
            this.search_media = new List<SearchMediaBrochure>();
        }

        public List<SearchMediaBrochure> search_media
        {
            get;
            set;
        }
    }

    
}
