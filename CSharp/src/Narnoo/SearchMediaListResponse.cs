using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaListResponse
    {
        public SearchMediaListResponse()
        {
            this.search_media = new List<SearchMediaResponse>();
        }

        public List<SearchMediaResponse> search_media
        {
            get;
            set;
        }
    }
}
