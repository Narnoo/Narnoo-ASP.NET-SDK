using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DownloadVideo
    {
        string _download_video_stream_path;
        public string download_video_stream_path
        {
            get
            {
                return this._download_video_stream_path;
            }
            set
            {
                this._download_video_stream_path = Utilities.DecodeCData(value);
            }
        }

        public string original_video_path { get; set; }
    }
}
