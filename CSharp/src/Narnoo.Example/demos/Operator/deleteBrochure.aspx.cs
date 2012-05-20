using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class deleteBrochure : OperatorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblMessage.Visible = true;
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                this.lblMessage.Text = request.deleteBrochure(brochure_id).ToString();

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode 
                    + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
    }
}