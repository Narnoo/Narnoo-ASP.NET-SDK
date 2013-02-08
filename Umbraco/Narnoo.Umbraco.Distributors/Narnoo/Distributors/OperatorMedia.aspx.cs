using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class OperatorMedia : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TabPage dataTab;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Albums");
            dataTab.Controls.Add(this.tabAlbums);

            InitBtnDownloadAlbums();


            dataTab = this.TabViewDetails.NewTabPage("Images");
            dataTab.Controls.Add(this.tabImages);

            InitBtnDownloadImages();

            dataTab = this.TabViewDetails.NewTabPage("Brochures");
            dataTab.Controls.Add(this.tabBrochures);

            InitBtnDownloadBrochures();

            dataTab = this.TabViewDetails.NewTabPage("Videos");
            dataTab.Controls.Add(this.tabVideos);

            InitBtnDownloadVideos();
            InitBtnAddToChannel();

            dataTab = this.TabViewDetails.NewTabPage("Text");
            dataTab.Controls.Add(this.tabText);
            
        }

        #region InitBtnDownloadAlbums
        public ImageButton btnDownloadAlbums;
        void InitBtnDownloadAlbums()
        {
            //Create a save button from the current datatab.
            btnDownloadAlbums = dataTab.Menu.NewImageButton();
            btnDownloadAlbums.ID = "btnDownloadAlbums";
            btnDownloadAlbums.Click += new ImageClickEventHandler(btnDownloadAlbums_Click);
            btnDownloadAlbums.AlternateText = "Download";
            btnDownloadAlbums.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadAlbums.ValidationGroup = "";
        }


        protected void btnDownloadAlbums_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //var settings = new ApiSettings();
                    //settings.Appkey = this.txtAppkey.Text;
                    //settings.Secretkey = this.txtSecretkey.Text;


                    //if (LoadInfo(settings))
                    //{
                    //    settings.Save();

                    //    this.ClientTools
                    //        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                    //}
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }
        #endregion

        #region InitBtnDownloadImages
        public ImageButton btnDownloadImages;
        void InitBtnDownloadImages()
        {
            //Create a save button from the current datatab.
            btnDownloadImages = dataTab.Menu.NewImageButton();
            btnDownloadImages.ID = "btnDownloadImages";
            btnDownloadImages.Click += new ImageClickEventHandler(btnDownloadImages_Click);
            btnDownloadImages.AlternateText = "Download";
            btnDownloadImages.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadImages.ValidationGroup = "";
        }


        protected void btnDownloadImages_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //var settings = new ApiSettings();
                    //settings.Appkey = this.txtAppkey.Text;
                    //settings.Secretkey = this.txtSecretkey.Text;


                    //if (LoadInfo(settings))
                    //{
                    //    settings.Save();

                    //    this.ClientTools
                    //        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                    //}
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }
        #endregion

        #region InitBtnDownloadBrochures
        public ImageButton btnDownloadBrochures;
        void InitBtnDownloadBrochures()
        {
            //Create a save button from the current datatab.
            btnDownloadBrochures = dataTab.Menu.NewImageButton();
            btnDownloadBrochures.ID = "btnDownloadBrochures";
            btnDownloadBrochures.Click += new ImageClickEventHandler(btnDownloadBrochures_Click);
            btnDownloadBrochures.AlternateText = "Download";
            btnDownloadBrochures.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadBrochures.ValidationGroup = "";
        }


        protected void btnDownloadBrochures_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //var settings = new ApiSettings();
                    //settings.Appkey = this.txtAppkey.Text;
                    //settings.Secretkey = this.txtSecretkey.Text;


                    //if (LoadInfo(settings))
                    //{
                    //    settings.Save();

                    //    this.ClientTools
                    //        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                    //}
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }
        #endregion

        #region InitBtnDownloadVideos
        public ImageButton btnDownloadVideos;
        void InitBtnDownloadVideos()
        {
            //Create a save button from the current datatab.
            btnDownloadVideos = dataTab.Menu.NewImageButton();
            btnDownloadVideos.ID = "btnDownloadVideos";
            btnDownloadVideos.Click += new ImageClickEventHandler(btnDownloadVideos_Click);
            btnDownloadVideos.AlternateText = "Download";
            btnDownloadVideos.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadVideos.ValidationGroup = "";
        }


        protected void btnDownloadVideos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //var settings = new ApiSettings();
                    //settings.Appkey = this.txtAppkey.Text;
                    //settings.Secretkey = this.txtSecretkey.Text;


                    //if (LoadInfo(settings))
                    //{
                    //    settings.Save();

                    //    this.ClientTools
                    //        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                    //}
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }
        #endregion

        #region InitBtnAddToChannel
        public ImageButton btnAddToChannel;
        void InitBtnAddToChannel()
        {
            //Create a save button from the current datatab.
            btnAddToChannel = dataTab.Menu.NewImageButton();
            btnAddToChannel.ID = "btnAddToChannel";
            btnAddToChannel.Click += new ImageClickEventHandler(btnAddToChannel_Click);
            btnAddToChannel.AlternateText = "Download";
            btnAddToChannel.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_add_to_channel.png";
            btnAddToChannel.ValidationGroup = "";
        }


        protected void btnAddToChannel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //var settings = new ApiSettings();
                    //settings.Appkey = this.txtAppkey.Text;
                    //settings.Secretkey = this.txtSecretkey.Text;


                    //if (LoadInfo(settings))
                    //{
                    //    settings.Save();

                    //    this.ClientTools
                    //        .ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "The settings has been saved succesfully");
                    //}
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        }
        #endregion
    }
}