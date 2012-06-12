using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SingleBrochure
    {
        public SingleBrochure()
        {
            this.pages = new SingleBrochurePages();
        }
        public string brochure_id { get; set; }
        public string entry_date { get; set; }
        public string thumb_image_path { get; set; }
        public string preview_image_path { get; set; }
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

        public string format { get; set; }
        public string validity_date { get; set; }
        public string brochure_caption { get; set; }

        public SingleBrochurePages pages { get; set; }
       
    }
}
