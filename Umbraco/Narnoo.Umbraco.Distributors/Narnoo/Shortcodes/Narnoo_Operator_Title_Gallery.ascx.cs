﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{
    public partial class Narnoo_Operator_Title_Gallery : Narnoo_Distributor_Title_Gallery
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string operator_id { get; set; }
    }
}