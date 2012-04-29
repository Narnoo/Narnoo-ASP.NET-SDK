using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class Video
    {
           public string video_id { get; set; }

        public string entry_date { get; set; }

        public string video_thumb_image_path { get; set; }

        public string video_pause_image_path { get; set; }

        public string video_preview_path { get; set; }

        string _video_stream_path;
        public string video_stream_path
        {
            get
            {
                return this._video_stream_path;
            }
            set
            {
                this._video_stream_path = Utilities.DecodeCData(value);
            }
        }

        public string video_caption { get; set; }

        public string video_language { get; set; }

        
    }
}
