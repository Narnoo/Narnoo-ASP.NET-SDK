using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class deleteOperator : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblMessage.Visible = true;

            string operatorId = this.txtOperatorId.Text;

            try
            {

                var request = new DistributorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var result = request.DeleteOperator(operatorId);

                     
                if (result)
                {
                    this.lblMessage.Text = "Success";
                }
                else
                {
                    this.lblMessage.Text = "Failed";
                }
            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
    }
}