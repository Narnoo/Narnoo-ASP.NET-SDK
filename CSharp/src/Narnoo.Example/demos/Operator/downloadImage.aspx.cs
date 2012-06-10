using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class downloadImage : OperatorNarnooRequestPage
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
            string image_id = this.txtImage_id.Text;

            try
            {
                var item = this.NarnooRequest.DownloadImage(image_id);

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