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
            var operatorIds = new List<string>();

            if (string.IsNullOrWhiteSpace(this.Request.QueryString["operator_id"]))
            {
                operatorIds = this.Request.QueryString["operatorIds"] == null ? new List<string>() : this.Request.QueryString["operatorIds"].Split(',').ToList();
            }
            else
            {
                foreach (var i in ids)
                {
                    operatorIds.Add(this.Request.QueryString["operator_id"]);
                }
            }



            this.rptItems.DataSource = ids.Select((it, i) => new
            {
                ItemId = it,
                OperatorId = operatorIds.Where((item, index) => i == index).FirstOrDefault()
            });

            this.rptItems.DataBind();

            this.lblTitle.InnerText = string.Format("Requesting download links for the following {0} {1} :", ids.Length, this.Request["title"]);
        }


    }
}