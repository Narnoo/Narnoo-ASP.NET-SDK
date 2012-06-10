using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getBrochures : DistributorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            try
            {
                var list = this.NarnooRequest.GetBrochures();
                this.lblTotal.Text = list.TotalPages.ToString();
                this.rptList.DataSource = list;
                this.rptList.DataBind();
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

        protected override Label MessageBox
        {
            get
            {
                return this.lblMessage;
            }
        }
    }
}