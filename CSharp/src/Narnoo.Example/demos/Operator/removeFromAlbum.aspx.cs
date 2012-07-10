using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class removeFromAlbum : OperatorNarnooRequestPage
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
            string image_id = this.txtimage_id.Text;
            string album_id = this.txtalbum_id.Text;

            try
            {
                this.NarnooRequest.removeFromAlbum(image_id,album_id);
                this.ShowMessage("done.");
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}