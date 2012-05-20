using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class deleteImage : OperatorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblMessage.Visible = true;
            string image_id = this.txtImage_id.Text;

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                this.lblMessage.Text = request.deleteImage(image_id).ToString();

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }

        }
    }
}