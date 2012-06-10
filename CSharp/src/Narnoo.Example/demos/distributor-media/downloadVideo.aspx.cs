using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class downloadVideo : DistributorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.detail.Visible = false;
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
            string videoId = this.txtVideoId.Text;

            try
            {
                var item = this.NarnooRequest.DownloadVideo(videoId);

                this.detail.Visible = true;

                this.lblDownload_video_stream_path.Text = item.download_video_stream_path;
                this.lblOriginal_video_path.Text = item.original_video_path;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}