using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class downloadImage : DistributorOperatorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblDownload_image_link.Visible = false;

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
            var operator_id = this.txtOperator_id.Text;
            string image_id = this.txtImage_id.Text;

            try
            {
                var item = this.NarnooRequest.DownloadImage(operator_id, image_id);
                this.lblDownload_image_link.Visible = true;
                this.lblDownload_image_link.Text = item.download_image_link;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}