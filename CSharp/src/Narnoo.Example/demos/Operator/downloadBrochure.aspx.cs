﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Example.demos.Operator
{
    public partial class downloadBrochure : OperatorNarnooRequestPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblDownload_brochure_to_pdf_path.Visible = false;
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
                var item = this.NarnooRequest.DownloadBrochure(brochure_id);

                this.lblDownload_brochure_to_pdf_path.Visible = true;
                this.lblDownload_brochure_to_pdf_path.Text = item.download_brochure_to_pdf_path;
            }
            catch (NarnooRequestException ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
    }
}