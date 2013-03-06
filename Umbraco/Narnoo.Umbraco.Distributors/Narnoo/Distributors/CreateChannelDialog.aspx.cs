﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class CreateChannelDialog : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            this.btnSubmit.Click += btnSubmit_Click;
            base.OnInit(e);
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                this.NarnooMediaRequest.createChannel(this.txtChannelName.Text);
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.success, "Congratulations", "Channel Has Created Successfully !!!.");

            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
            }
            finally
            {
                this.ClientTools.CloseModalWindow();
            }
        }
    }
}