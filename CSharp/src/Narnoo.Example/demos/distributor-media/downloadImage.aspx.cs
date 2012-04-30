using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class downloadImage : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string image_id = this.txtImage_id.Text;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.DownloadImage(image_id);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Image cannot found";
                }
                else
                {

                    this.lblDownload_image_link.Text = item.download_image_link;

                }

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }
    }
}