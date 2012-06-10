using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getProductTextWords : OperatorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultPanel.Visible = false;
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

            var product_title = this.txtProduct_title.Text;

            try
            {
                var item = this.NarnooRequest.GetProductTextWords(product_title);

                this.resultPanel.Visible = true;
                this.lblProduct_title.Text = item.product_title;
                this.lblWord_50.Text = item.text.word_50;
                this.lblWord_100.Text = item.text.word_100;
                this.lblWord_150.Text = item.text.word_150;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

    }
}