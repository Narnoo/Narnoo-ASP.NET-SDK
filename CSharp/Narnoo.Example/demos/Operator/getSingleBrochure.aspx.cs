using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getSingleBrochure : OperatorPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Visible = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        
            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var request = new OperatorNarnooRequest();
                request.SetAuth(this.appkey, this.secretkey);
                var item = request.GetSingleBrochure(brochure_id);

                if (item == null)
                {
                    this.lblMessage.Visible = true;
                    this.lblMessage.Text = "Brochure cannot found";
                }
                else
                {
                    this.detail.Visible = true;
                    this.txtBrochureId.Text = item.brochure_id;
                    this.txtbrochure_caption.Text = item.brochure_caption;
                    this.txtEntry_date.Text = item.entry_date;
                    this.txtPage_order_xml_config.Text = item.page_order_xml_config;
                    this.txtPreview_image_path.Text = item.preview_image_path;
                    this.txtStandard_pages_page_0.Text = item.standard_pages.page_0;
                    this.txtStandard_pages_page_1.Text = item.standard_pages.page_1;
                    this.txtStandard_pages_page_2.Text = item.standard_pages.page_2;
                    this.txtStandard_pages_page_3.Text = item.standard_pages.page_3;
                    this.txtStandard_pages_page_4.Text = item.standard_pages.page_4;
                    this.txtStandard_pages_page_5.Text = item.standard_pages.page_5;

                    this.txtThumb_image_path.Text = item.thumb_image_path;
                    this.txtvalidity_date.Text = item.validity_date;
                    this.txtZoom_pages_zoom_0.Text = item.zoom_page.zoom_0;
                    this.txtZoom_pages_zoom_1.Text = item.zoom_page.zoom_1;
                    this.txtZoom_pages_zoom_2.Text = item.zoom_page.zoom_2;
                    this.txtZoom_pages_zoom_3.Text = item.zoom_page.zoom_3;
                    this.txtZoom_pages_zoom_4.Text = item.zoom_page.zoom_4;
                    this.txtZoom_pages_zoom_5.Text = item.zoom_page.zoom_5;


                }

            }
            catch (InvalidNarnooRequestException ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "ErrorCode:" + ex.Error.ErrorCode
                    + "</br> ErrorMessage:" + ex.Error.ErrorMessage;
            }
        }
    }
}