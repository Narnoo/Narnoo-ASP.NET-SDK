using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Narnoo.Example.demos.distributor_media
{
    public partial class deleteBrochure : DistributorPageBase
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
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var request = new DistributorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                this.lblMessage.Text = request.deleteBrochure(brochure_id).ToString();

            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}