﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorVideosResponse
    {
        public OperatorVideosResponse()
        {
            this.operator_videos = new List<OperatorVideoResponse>();
        }

        public List<OperatorVideoResponse> operator_videos
        {
            get;
            set;
        }
    }
}
