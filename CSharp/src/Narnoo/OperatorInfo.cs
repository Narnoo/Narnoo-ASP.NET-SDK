using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class OperatorInfo
    {
        public string operator_id { get; set; }

        public string operator_url { get; set; }

        public string operator_username { get; set; }

        public string operator_businessname { get; set; }

        public string operator_contactname { get; set; }

        public string country_name { get; set; }

        public string state { get; set; }

        public string suburb { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string postcode { get; set; }

        public int total_images { get; set; }
        public int total_brochures { get; set; }
        public int total_videos { get; set; }
        public int total_products { get; set; }
    }
}
