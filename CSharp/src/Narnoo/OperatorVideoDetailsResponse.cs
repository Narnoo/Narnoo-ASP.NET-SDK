using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorVideoDetailsResponse:NarnooCollectionResponse
    {
        public OperatorVideoDetailsResponse()
        {
            this.operator_videos = new List<Video>();
        }
        public List<Video> operator_videos
        {
            get;set;
        }
    }
}
