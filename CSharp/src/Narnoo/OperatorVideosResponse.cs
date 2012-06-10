using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorVideosResponse:NarnooCollectionResponse
    {
        public OperatorVideosResponse()
        {
            this.operator_videos = new List<Video>();
        }

        public List<Video> operator_videos
        {
            get;
            set;
        }
    }
}
