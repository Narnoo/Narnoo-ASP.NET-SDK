using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.distributor_operator_media
{
    public partial class getAlbumImages : DistributorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var operator_id = this.txtOperator_id.Text;
            string album_name = this.txtAlbum_name.Text;

            try
            {
                var request = new DistributorOperatorMediaNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var list = request.GetAlbumImages(operator_id, album_name);

                this.rptList.DataSource = list;

                this.rptList.DataBind();

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }

    }
}