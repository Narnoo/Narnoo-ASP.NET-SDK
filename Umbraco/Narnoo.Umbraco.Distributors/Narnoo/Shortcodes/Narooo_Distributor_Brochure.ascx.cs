using Narnoo.Umbraco.Distributors.Narnoo.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{


    //    id:
    //width:
    //height:
    //image:thumbnail/preview
    //align:none/left/center/right
    //img_title
    //img_alt

    public partial class Narooo_Distributor_Brochure : ShortcodeBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string id { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public NarnooImageMode image { get; set; }
        public NarnooAlign align { get; set; }
        public string img_title { get; set; }
        public string img_alt { get; set; }

        public override string RenderDesignContent()
        {
            return string.Format("[narnoo_distributor_brochure id=\"{0}\" width=\"{1}\" height=\"{2}\" align=\"{3}\" img_title=\"{4}\" img_alt=\"{5}\"]",
                this.id, this.width, this.height, this.image.Value, this.align.Value, this.img_title, this.img_alt);
        }

        public override string RenderContent()
        {
            return "<div style='height: " + this.height + "px;' class='narnoo_brochure' data-width='" + this.width + "' data-height='" + this.height + "' data-operator-id='' "
            + "          data-id='" + this.id + "' data-count='0' data-image='" + this.image.Value + "' data-align='" + this.align + "' data-img-alt='" + this.img_alt + "' data-img-title='" + this.img_title + "'>"
            + "         <div style='height: " + this.height + "px; background: #ffffff url(/narnoo/images/loader.gif) no-repeat center center;'></div>"
            + "     </div>";
        }
    }
}