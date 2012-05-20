using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getProductTextWords : OperatorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         
            var product_title = this.txtProduct_title.Text;

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.GetProductTextWords(product_title);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "ProductTextWords cannot found";
                }
                else
                {
                    this.detail.Visible = true;
                    this.lblProduct_title.Text = item.product_title;
                    this.lblWord_50.Text = item.text.word_50;
                    this.lblWord_100.Text = item.text.word_100;
                    this.lblWord_150.Text = item.text.word_150;
                }

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