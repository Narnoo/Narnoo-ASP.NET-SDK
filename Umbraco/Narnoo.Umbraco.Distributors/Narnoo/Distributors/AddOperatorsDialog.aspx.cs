using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class AddOperatorsDialog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ids = this.Request.QueryString["ids"].Split(',').Where(i => string.IsNullOrWhiteSpace(i) == false).OrderBy(i => i).Distinct();
            this.rptItems.DataSource = ids;
            this.rptItems.DataBind();

        }
    }
}