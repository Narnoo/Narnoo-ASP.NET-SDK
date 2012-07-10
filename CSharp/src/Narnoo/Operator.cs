using System;
using System.Collections.Generic;
using System.Text;

namespace Narnoo
{
    public class Operator
    {
        public string operator_id
        {
            get;
            set;
        }

        public string category { get; set; }

        public string sub_category { get; set; }

        public string operator_url { get; set; }

        public string operator_username { get; set; }

        public string operator_contactname { get; set; }

        public string operator_businessname { get; set; }

        public string country_name { get; set; }

        public string state { get; set; }

        public string suburb { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string postcode { get; set; }

        public string keywords { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
    }
}
