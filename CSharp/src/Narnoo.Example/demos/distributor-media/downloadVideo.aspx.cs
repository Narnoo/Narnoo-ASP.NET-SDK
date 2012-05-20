using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class downloadVideo : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string videoId = this.txtVideoId.Text;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.DownloadVideo(videoId);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Video cannot found";
                }
                else
                {
                    this.detail.Visible = true;
                    this.lblDownload_video_stream_path.Text = item.download_video_stream_path;
                    this.lblOriginal_video_path.Text = item.original_video_path;

                }

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
    }
}