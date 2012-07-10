using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor
{
    public partial class getDetails : DistributorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var item = this.NarnooRequest.getDetails();
                this.lbldistributor_id.Text = item.distributor_id;
                this.lbldistributor_businessname.Text = item.distributor_businessname;
                this.lbldistributor_contactname.Text = item.distributor_contactname;
                this.lblcountry_name.Text = item.country_name;
                this.lblstate.Text = item.state;
                this.lblsuburb.Text = item.suburb;
                this.lblphone.Text = item.phone;
                this.lblurl.Text = item.url;
                this.lblemail.Text = item.email;
                this.lblpostcode.Text = item.postcode;
                this.lblimage_limit.Text = item.image_limit;
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