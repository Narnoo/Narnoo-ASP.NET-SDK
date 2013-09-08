using Narnoo.Umbraco.Distributors.Narnoo.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{
    public partial class Narnoo_Distributor_Text : ShortcodeBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string operator_id { get; set; }
        public string product_title { get; set; }
        public NarnooTextLength lenght { get; set; }

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