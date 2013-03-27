using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SearchMediaBrochure : ISearchMedia
    {

        public string operator_id { get; set; }

        public string brochure_id { get; set; }
        public string entry_date { get; set; }

        string _thumb_image_path;
        public string thumb_image_path
        {
            get
            {
                return this._thumb_image_path;
            }
            set
            {
                this._thumb_image_path = Utilities.DecodeCData(value);
            }
        }

        string _preview_image_path;
        public string preview_image_path
        {
            get
            {
                return this._preview_image_path;
            }
            set
            {
                this._preview_image_path = Utilities.DecodeCData(value);
            }
        }

        public List<string> standard_pages
        {
            get;
            set;
        }

        public zoom_page zoom_page
        {
            get;
            set;
        }




        public string media_id
        {
            get { return this.brochure_id; }
        }


        public string brochure_caption { get; set; }

        public string caption
        {
            get { return this.brochure_caption; }
        }
    }

    public class zoom_page
    {
        public string page_order_xml_config { get; set; }

        string _file_path_to_pdf;
        public string file_path_to_pdf
        {
            get
            {
                return this._file_path_to_pdf;
            }
            set
            {
                this._file_path_to_pdf = Utilities.DecodeCData(value);
            }
        }

        public string validity_date { get; set; }

        public string brochure_caption { get; set; }
    }
}
