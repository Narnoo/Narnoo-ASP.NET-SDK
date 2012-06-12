using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class getSingleBrochure : OperatorNarnooRequestPage
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

            string brochure_id = this.txtBrochure_id.Text;

            try
            {
                var item = this.NarnooRequest.GetSingleBrochure(brochure_id);

                this.resultPanel.Visible = true;
                this.txtBrochureId.Text = item.brochure_id;
                this.txtbrochure_caption.Text = item.brochure_caption;
                this.txtEntry_date.Text = item.entry_date;
                this.txtPage_order_xml_config.Text = item.page_order_xml_config;
                this.txtPreview_image_path.Text = item.preview_image_path;
                this.lblFormat.Text = item.format;
                this.txtThumb_image_path.Text = item.thumb_image_path;
                this.txtvalidity_date.Text = item.validity_date;

                if (item.pages != null)
                {
                    this.rptStandardPages.DataSource = item.pages.standard_pages;
                    this.rptStandardPages.DataBind();
                    this.rptZoomPages.DataSource = item.pages.zoom_page;
                    this.rptZoomPages.DataBind();
                }
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}