using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class DeleteBrochuresDialog : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.rptItems.DataSource = this.SelectedIds;
                this.rptItems.DataBind();
            }
        }

        string[] _SelectedIds;
        public string[] SelectedIds
        {
            get
            {
                if (this._SelectedIds == null)
                {
                    var ids = this.Request["ids"];
                    this._SelectedIds = string.IsNullOrWhiteSpace(ids) ? new string[0] : ids.Split(',');
                }

                return this._SelectedIds;
            }
        }
    }
}