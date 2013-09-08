using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{
    public partial class Narnoo_Operator_Single_Link_Gallery : Narnoo_Distributor_Single_Link_Gallery
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string operator_id { get; set; }

        public override string RenderContent()
        {
            return "<div style='height: " + this.height + "px; width: " + this.width + "px;' class='narnoo_slg' data-operator-id='"+this.operator_id+"' data-count='0' data-width='" + this.width + "' data-height='" + this.height + "' data-album-name='" + this.album_name + "'>"
                 + "   <div style='height: " + this.height + "px; width: " + this.width + "px; background: #ffffff url(/umbraco/narnoo/images/loader.gif) no-repeat center center;'></div>"
                 + "</div>";
        }

        public override string RenderDesignContent()
        {
            return "[narnoo_distributor_single_link_gallery operator_id='"+this.operator_id+"' album_name='" + this.album_name + "' width='" + this.width + "' height='" + this.height + "']";
        }
    }
}