using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{

    //    operator_id
    //album_name
    //width
    //height
    //border_color

    public partial class Narnoo_Distributor_Title_Gallery : ShortcodeBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string album_name { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string border_color { get; set; }

        public override string RenderContent()
        {
            throw new NotImplementedException();
        }

        public override string RenderDesignContent()
        {
            throw new NotImplementedException();
        }
    }
}