using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class sendBrochure : DistributorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override Label MessageBox
        {
            get
            {
                return this.lblMessage;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var response =  this.NarnooRequest.sendBrochure(brochure_id);
                this.lblExpiry_date.Text = response.expiry_date;
                this.lnkDownload_link.NavigateUrl = response.download_link;
                this.lnkDownload_link.Text = response.download_link;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}