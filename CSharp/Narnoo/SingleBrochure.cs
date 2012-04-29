using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SingleBrochure
    {
        public SingleBrochure()
        {
            this.standard_pages = new standard_pages();
            this.zoom_page = new zoom_page();
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

        public string validity_date { get; set; }
        public string brochure_caption { get; set; }
        public standard_pages standard_pages { get; set; }
        public zoom_page zoom_page { get; set; }


    }

    public class standard_pages
    {
        public string page_0
        {
            get;
            set;
        }

        public string page_1
        {
            get;
            set;
        }
        public string page_2
        {
            get;
            set;
        }
        public string page_3
        {
            get;
            set;
        }
        public string page_4
        {
            get;
            set;
        }
        public string page_5
        {
            get;
            set;
        }
    }

    public class zoom_page
    {
        public string zoom_0
        {
            get;
            set;
        }


        public string zoom_1
        {
            get;
            set;
        }

        public string zoom_2
        {
            get;
            set;
        }

        public string zoom_3
        {
            get;
            set;
        }

        public string zoom_4
        {
            get;
            set;
        }

        public string zoom_5
        {
            get;
            set;
        }
    }
}
