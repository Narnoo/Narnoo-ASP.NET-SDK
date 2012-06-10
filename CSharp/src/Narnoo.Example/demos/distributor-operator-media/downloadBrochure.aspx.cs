using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class downloadBrochure : DistributorPageBase
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
            var operator_id = this.txtOperator_id.Text;
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var request = new DistributorOperatorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.DownloadBrochure(operator_id,brochure_id);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Brochure cannot found";
                }
                else
                {

                    this.lblDownload_brochure_to_pdf_path.Text = item.download_brochure_to_pdf_path;

                }

            }
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = ex.Message;
            }
        }
    }
}