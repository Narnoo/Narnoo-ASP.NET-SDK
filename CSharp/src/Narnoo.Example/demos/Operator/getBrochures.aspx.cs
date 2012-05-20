using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getBrochures : OperatorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetBrochures();

                this.rptList.DataSource = list;
                this.rptList.DataBind();

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.errorCode 
                    + "</br> ErrorMessage:" + ex.Error.errorMessage;
            }
        }
        
    }
}