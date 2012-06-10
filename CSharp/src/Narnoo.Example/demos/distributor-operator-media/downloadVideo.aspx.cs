using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class downloadVideo : DistributorOperatorMediaNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblDownload_video_stream_path.Visible = false;
            this.lblOriginal_video_path.Visible = false;
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
            string vedio_id = this.txtVideo_id.Text;

            try
            {
                var item = this.NarnooRequest.DownloadVideo(operator_id, vedio_id);

                this.lblDownload_video_stream_path.Visible = true;
                this.lblOriginal_video_path.Visible = true;
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