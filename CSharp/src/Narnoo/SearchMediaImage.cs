using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaImage : ISearchMedia
    {

        public string media_id { get; set; }

        public string entry_date { get; set; }

        public string operator_id { get; set; }

        string _thumb_media_path;
        public string thumb_media_path
        {
            get
            {
                return this._thumb_media_path;
            }
            set
            {
                this._thumb_media_path = Utilities.DecodeCData(value);
            }
        }

        string _preview_media_path;
        public string preview_media_path
        {
            get
            {
                return this._preview_media_path;
            }
            set
            {
                this._preview_media_path = Utilities.DecodeCData(value);
            }
        }

        string _large_media_path;
        public string large_media_path
        {
            get
            {
                return this._large_media_path;
            }
            set
            {
                this._large_media_path = Utilities.DecodeCData(value);
            }
        }

        public string media_owner_business_name { get; set; }

        public string media_caption { get; set; }


        public string thumb_image_path
        {
            get { return this.thumb_media_path; }
        }

        public string caption
        {
            get { return this.media_caption; }
        }
    }
}
