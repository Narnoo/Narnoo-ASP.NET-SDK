using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class getImages : DistributorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                var list = this.NarnooRequest.GetImages();
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