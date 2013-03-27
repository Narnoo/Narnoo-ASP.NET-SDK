using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaVideo : ISearchMedia
    {


        public string operator_id { get; set; }
        public string video_id { get; set; }

        public string entry_date { get; set; }

   

        string _video_thumb_image_path;
        public string video_thumb_image_path
        {
            get
            {
                return this._video_thumb_image_path;
            }
            set
            {
                this._video_thumb_image_path = Utilities.DecodeCData(value);

            }
        }


        string _video_pause_image_path;
        public string video_pause_image_path
        {
            get
            {
                return this._video_pause_image_path;
            }
            set
            {
                this._video_pause_image_path = Utilities.DecodeCData(value);

            }
        }

        string _video_preview_path;
        public string video_preview_path
        {
            get
            {
                return this._video_preview_path;
            }
            set
            {
                this._video_preview_path = Utilities.DecodeCData(value);

            }
        }

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




        public string media_id
        {
            get { return this.video_id; }
        }

        public string thumb_image_path
        {
            get { return video_thumb_image_path; }
        }

        public string caption
        {
            get { return video_caption; }
        }
    }
}
