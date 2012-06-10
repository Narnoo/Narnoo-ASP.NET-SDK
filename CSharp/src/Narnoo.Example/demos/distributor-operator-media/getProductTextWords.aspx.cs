using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class getProductTextWords : DistributorPageBase
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
            var product_title = this.txtProduct_title.Text;

            try
            {
                var request = new DistributorOperatorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.GetProductTextWords(operator_id, product_title);

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
            catch (NarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.ShowMessage(ex.Message);
            }
        }

    }
}