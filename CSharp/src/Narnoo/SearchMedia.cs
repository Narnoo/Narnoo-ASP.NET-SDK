using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public interface ISearchMedia
    {
        string media_id { get; }

        string entry_date { get; }

        string thumb_image_path { get; }

        string caption { get;  }

        string operator_id { get; }
    }
}
