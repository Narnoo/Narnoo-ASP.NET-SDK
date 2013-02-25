using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class DownloadFiles :  DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ids = this.Request.QueryString["ids"].Split(',');
            this.rptItems.DataSource = ids;
            this.rptItems.DataBind();

            this.lblTitle.InnerText = string.Format("Requesting download links for the following {0} {1} :", ids.Length, this.Request["title"]);
        }


    }
}