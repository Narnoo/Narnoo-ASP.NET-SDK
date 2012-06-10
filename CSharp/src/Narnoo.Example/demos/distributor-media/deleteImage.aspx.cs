using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class deleteImage : DistributorPageBase
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
            this.lblMessage.Visible = true;
            string image_id = this.txtImage_id.Text;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                this.lblMessage.Text = request.deleteImage(image_id).ToString();

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.ShowMessage(ex.Message);
            }
        }
    }
}