using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class SingleBrochurePage
    {
        public SingleBrochurePage()
        {
            this.standard_pages = new List<string>();
            this.zoom_page = new List<string>();
        }

        public List<string> standard_pages { get; set; }
        public List<string> zoom_page { get; set; }

    }
}
