using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{

//    operator_id:
//id:
//width:
//hieght:
//image:thumbnail/preview
//align:none/left/center/right
//img_title:
//img_alt:


    public partial class Narnoo_Operator_Brochure : Narooo_Distributor_Brochure
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string operator_id { get; set; }
    }
}