using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.BasePages;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Narnoo.Distributors
{
    public partial class Settings : BasePage
    {

        public TabPage dataTab;
        public ImageButton saveButtonData;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            #region Details Tab

            dataTab = TabViewDetails.NewTabPage("Settings");
            dataTab.Controls.Add(panelSettings);

            //Create a save button for the details tab.
            SetSaveButtonProperties("btnSaveSettings");


            dataTab = TabViewDetails.NewTabPage("Details");
            dataTab.Controls.Add(panelDetail);

            #endregion

        }

        /// <summary>
        /// Set the properites of the savebutton for a tab.
        /// </summary>
        /// <param name="saveButton"></param>
        /// <param name="id"></param>
        private void SetSaveButtonProperties(string id)
        {
            //Create a save button from the current datatab.
            saveButtonData = dataTab.Menu.NewImageButton();
            saveButtonData.ID = id;
            saveButtonData.Click += new ImageClickEventHandler(SaveButton_Click);
            saveButtonData.AlternateText = "Save";
            saveButtonData.ImageUrl = GlobalSettings.Path + "/images/editor/save.gif";
            saveButtonData.ValidationGroup = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var settings = new ApiSettings();
                settings.Load();
                this.txtAppkey.Text = settings.Appkey;
                this.txtSecretkey.Text = settings.Secretkey;

                LoadInfo(settings);

            }
        }

        protected void SaveButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    var settings = new ApiSettings();
                    settings.Appkey = this.txtAppkey.Text;
                    settings.Secretkey = this.txtSecretkey.Text;
                    settings.Save();

                    LoadInfo(settings);


                    this.ClientTools
                        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }

        private void LoadInfo(ApiSettings settings)
        {
            try
            {

                var request = new DistributorNarnooRequest();
                request.SetAuth(settings.Appkey, settings.Secretkey);
                request.Sandbox = false;

                var info = request.getDetails();

                this.lblId.Text = info.distributor_id;
                this.lblEmail.Text = info.email;
                this.lblBusinessName.Text = info.distributor_businessname;
                this.lblContactName.Text = info.distributor_contactname;
                this.lblCountry.Text = info.country_name;
                this.lblPostCode.Text = info.postcode;
                this.lblSuburb.Text = info.suburb;
                this.lblState.Text = info.state;
                this.lblPhone.Text = info.phone;
                this.lblURL.Text = info.url;
                this.lblTotalImages.Text = info.total_images.ToString();
                this.lblTotalBrochures.Text = info.total_brochures.ToString();
                this.lblTotalVideos.Text = info.total_videos.ToString();
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
            }
        }


    }
}