using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class sendVideo : DistributorMediaNarnooRequestPage
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
            string video_id = this.txtVideo_id.Text;

            try
            {
                var response =  this.NarnooRequest.sendVideo(video_id);
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