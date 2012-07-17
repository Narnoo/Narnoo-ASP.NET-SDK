using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getDetails : OperatorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var item = this.NarnooRequest.getDetails();
                this.lbloperator_id.Text = item.operator_id;
                this.lbloperator_url.Text = item.operator_url;
                this.lbloperator_username.Text = item.operator_username;
                this.lbloperator_businessname.Text = item.operator_businessname;
                this.lbloperator_contactname.Text = item.operator_contactname;
                this.lblcountry_name.Text = item.country_name;
                this.lblstate.Text = item.state;
                this.lblsuburb.Text = item.suburb;
                this.lblphone.Text = item.phone;
                this.lblemail.Text = item.email;
                this.lblpostcode.Text = item.postcode;
                this.lbltotal_images.Text = item.total_images.ToString();
                this.lbltotal_brochures.Text = item.total_brochures.ToString();
                this.lbltotal_products.Text = item.total_products.ToString();
                this.lbltotal_videos.Text = item.total_videos.ToString();
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }

        protected override Label MessageBox
        {
            get
            {
                return this.lblMessage;
            }
        }
    }
}