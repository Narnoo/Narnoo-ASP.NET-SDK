using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (this.IsPostBack == false)
            {
                this.rptAlbumImages.Visible = false;
                this.rptImages.Visible = false;
                this.rptBrochures.Visible = false;
                this.rptVideos.Visible = false;
                

                this.pagerAlbumImages.Visible = false;
                this.pagerBrochures.Visible = false;
                this.pagerImages.Visible = false;
                this.pagerVideos.Visible = false;

                this.BindAlbums();
            }
        }



        StringBuilder ErrorMessages = new StringBuilder();

        string OperatorId
        {
            get
            {
                return this.Request.QueryString["id"];
            }
        }

        string ActivedTabView
        {
            get
            {
                return this.Request.Form["body_TabViewDetails_activetab"];
            }
        }

        public TabPage dataTab;
        protected override void OnInit(EventArgs e)
        {
            dataTab = this.TabViewDetails.NewTabPage("Albums");
            dataTab.Controls.Add(this.tabAlbums);
            InitBtnDownloadAlbums();
            this.ddlAlbumsPageIndex.SelectedIndexChanged += ddlAlbumsPageIndex_SelectedIndexChanged;
            this.btnChangeAlbums.Click += btnChangeAlbums_Click;
            this.pagerAlbumImages.PageIndexChanged += pagerAlbumImages_PageIndexChanged;


            dataTab = this.TabViewDetails.NewTabPage("Images");
            dataTab.Controls.Add(this.tabImages);
            InitBtnDownloadImages();
            this.pagerImages.PageIndexChanged += pagerImages_PageIndexChanged;


            dataTab = this.TabViewDetails.NewTabPage("Brochures");
            dataTab.Controls.Add(this.tabBrochures);
            InitBtnDownloadBrochures();
            this.pagerBrochures.PageIndexChanged += pagerBrochures_PageIndexChanged;

            dataTab = this.TabViewDetails.NewTabPage("Videos");
            dataTab.Controls.Add(this.tabVideos);
            InitBtnDownloadVideos();
            InitBtnAddToChannel();
            this.pagerVideos.PageIndexChanged += pagerVideos_PageIndexChanged;


            dataTab = this.TabViewDetails.NewTabPage("Text");
            dataTab.Controls.Add(this.tabText);

            this.btnReloadTabView.Click += ReloadTabView;

        }



        void ReloadTabView(object sender, EventArgs e)
        {

            switch (this.ActivedTabView)
            {
                case "body_TabViewDetails_tab01"://albums
                    this.BindAlbums();
                    break;
                case "body_TabViewDetails_tab02"://images
                    this.BindImages(1);
                    break;
                case "body_TabViewDetails_tab03"://brochures
                    this.BindBrochures(1);
                    break;
                case "body_TabViewDetails_tab04"://videos
                    this.BindVideos(1);
                    break;
                case "body_TabViewDetails_tab05"://text
                    this.BindText();
                    break;
                default:
                    break;

            }
        }

        private void BindText()
        {
            //throw new NotImplementedException();
        }

        #region TabView 01:Albums
        private void BindAlbums()
        {
            if (string.IsNullOrWhiteSpace(this.OperatorId))
            {
                this.toobarAlbums.Visible = false;
            }
            else
            {
                this.toobarAlbums.Visible = true;
        
                try
                {
                    var albums = this.LoadAlbums();

                    this.lblCurrentAlbumName.Text = albums.Select(i => i.album_name).FirstOrDefault();

                    this.rptAlbumImages.Visible = false;
                    this.BindAlbumImages(1);
                    this.pagerAlbumImages.Visible = true;
                   
                    
                }
                catch (Exception ex)
                {
                    this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                    //this.ErrorMessages.AppendLine(ex.Message);
                }
            }

        }

        private NarnooCollection<Album> LoadAlbums(int pageIndex = 1)
        {
            var albums = this.NarnooOperatorMediaRequest.GetAlbums(this.OperatorId);

            this.ddlAlbumsPageIndex.Items.Clear();
            for (var i = 0; i < albums.TotalPages; i++)
            {
                this.ddlAlbumsPageIndex.Items.Add(string.Format("Album page {0}", i + 1));
            }

            this.ddlAlbumsPageIndex.SelectedIndex = this.pagerAlbumImages.CurrentPageIndex;

            this.ddlAlbums.DataSource = albums;
            this.ddlAlbums.DataBind();
            return albums;
        }
        void ddlAlbumsPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAlbums(this.ddlAlbumsPageIndex.SelectedIndex);
        }

        void pagerAlbumImages_PageIndexChanged(int newPageIndex)
        {
            this.BindAlbumImages(newPageIndex);
        }

        void BindAlbumImages(int page_no)
        {
            try
            {
                var data = this.NarnooOperatorMediaRequest.GetAlbumImages(this.OperatorId, this.lblCurrentAlbumName.Text, page_no);
                this.rptAlbumImages.Visible = true;
                this.rptAlbumImages.DataSource = data;
                this.rptAlbumImages.DataBind();

                this.pagerAlbumImages.DataBind(page_no, data.TotalPages, data.Count);
                this.status_body_TabViewDetails_tab01.Value = "1";
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                //this.ErrorMessages.AppendLine(ex.Message);
            }
        }
        #endregion

        #region TabView 02:Images
        private void BindImages(int pageIndex)
        {

            if (string.IsNullOrWhiteSpace(this.OperatorId) == false)
            {
                try
                {
                    var images = this.NarnooOperatorMediaRequest.GetImages(this.OperatorId, pageIndex);
                    this.rptImages.Visible = true;
                    this.loadingImages.Visible = false;

                    this.rptImages.DataSource = images;
                    this.rptImages.DataBind();
                    this.pagerImages.DataBind(pageIndex, images.TotalPages, images.Count);
                    this.status_body_TabViewDetails_tab02.Value = "1";
                    this.pagerImages.Visible = true;
                   
                }
                catch (Exception ex)
                {
                    this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                    //this.ErrorMessages.AppendLine(ex.Message);
                }
            }
        }

        void pagerImages_PageIndexChanged(int newPageIndex)
        {
            this.BindImages(newPageIndex);
        }
        #endregion

        #region TabView 03:Brochures
        private void BindBrochures(int pageIndex)
        {
            if (string.IsNullOrWhiteSpace(this.OperatorId) == false)
            {
                try
                {
                    var brochures = this.NarnooOperatorMediaRequest.GetBrochures(this.OperatorId, pageIndex);
                    this.rptBrochures.Visible = true;
                    this.loadingBrochures.Visible = false;
                    this.rptBrochures.DataSource = brochures;
                    this.rptBrochures.DataBind();
                    this.pagerBrochures.DataBind(pageIndex, brochures.TotalPages, brochures.Count);
                    this.status_body_TabViewDetails_tab03.Value = "1";
                    this.pagerBrochures.Visible = true;
                   
                }
                catch (Exception ex)
                {
                    this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                }
            }
        }

        void pagerBrochures_PageIndexChanged(int newPageIndex)
        {
            this.BindBrochures(newPageIndex);
        }
        #endregion

        #region TabView 04:Videos
        private void BindVideos(int pageIndex)
        {
            if (string.IsNullOrWhiteSpace(this.OperatorId) == false)
            {
                try
                {
                    var videos = this.NarnooOperatorMediaRequest.GetVideos(this.OperatorId, pageIndex);
                    this.loadingVideos.Visible = false;
                    this.rptVideos.Visible = true;
                    this.rptVideos.DataSource = videos;
                    this.rptVideos.DataBind();
                    this.pagerVideos.DataBind(pageIndex, videos.TotalPages, videos.Count);
                    this.status_body_TabViewDetails_tab04.Value = "1";
                    this.pagerVideos.Visible = true;
                  
                }
                catch (Exception ex)
                {
                    this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
                }
            }
        }

        void pagerVideos_PageIndexChanged(int newPageIndex)
        {
            this.BindVideos(newPageIndex);
        }
        #endregion

        void btnChangeAlbums_Click(object sender, EventArgs e)
        {
            this.lblCurrentAlbumName.Text = this.ddlAlbums.SelectedValue;
            this.BindAlbumImages(1);
        }



        #region InitBtnDownloadAlbums
        public ImageButton btnDownloadAlbums;
        void InitBtnDownloadAlbums()
        {
            //Create a save button from the current datatab.
            btnDownloadAlbums = dataTab.Menu.NewImageButton();
            btnDownloadAlbums.ID = "btnDownloadAlbumImage";
            btnDownloadAlbums.AlternateText = "Download";
            btnDownloadAlbums.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownloadAlbums.ValidationGroup = "";
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