using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DownloadBrochure
    {
        string _download_brochure_to_pdf_path;
        public string download_brochure_to_pdf_path
        {
            get
            {
                return this._download_brochure_to_pdf_path;
            }
            set
            {
                this._download_brochure_to_pdf_path = Utilities.DecodeCData(value);
            }
        }
    }
}
