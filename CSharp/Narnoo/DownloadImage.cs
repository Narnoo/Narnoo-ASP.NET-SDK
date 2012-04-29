using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class DownloadImage
    {
        string _download_image_link;
        public string download_image_link
        {
            get
            {
                return this._download_image_link;
            }
            set
            {
                this._download_image_link = Utilities.DecodeCData(value);
            }
        }
    }
}
