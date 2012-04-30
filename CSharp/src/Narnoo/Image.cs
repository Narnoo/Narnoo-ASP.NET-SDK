using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class Image
    {

        public string image_id { get; set; }
        public string entry_date { get; set; }

        public string thumb_image_path { get; set; }
        public string preview_image_path { get; set; }
        public string large_image_path { get; set; }

        public string image_caption { get; set; }

    }
}
