using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.cms.businesslogic.web;
using umbraco.uicontrols;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class Operators : DistributorPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Pager1.PageIndexChanged += Pager1_PageIndexChanged;

            dataTab = TabViewDetails.NewTabPage("Operators");
            dataTab.Controls.Add(this.tabOperators);
            InitBtnMedia();
            InitBtnImport();
            InitBtnDelete();
        }

        public TabPage dataTab;
        #region InitBtnMedia
        void InitBtnMedia()
        {
            //Create a save button from the current datatab.
            btnMedia = dataTab.Menu.NewImageButton();
            btnMedia.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnMedia.ID = "btnMedia";
            btnMedia.Click += new ImageClickEventHandler(btnMedia_Click);
            btnMedia.AlternateText = "Media";
            btnMedia.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_media.png";
            btnMedia.ValidationGroup = "";
        }

        public ImageButton btnMedia;
        protected void btnMedia_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    
                }
            }
            catch (Exception)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", "faild to save settings.");
            }
        } 
        #endregion

        #region InitBtnImport
        void InitBtnImport()
        {
         
            //Create a save button from the current datatab.
            btnImport = dataTab.Menu.NewImageButton();
            btnImport.ID = "btnImport";
            btnImport.Click += new ImageClickEventHandler(btnImport_Click);
            btnImport.AlternateText = "Import";
            btnImport.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_import.png";
            btnImport.ValidationGroup = "";
        }

        public ImageButton btnImport;
        protected void btnImport_Click(object sender, ImageClickEventArgs e)
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

        #region InitBtnDelete
        void InitBtnDelete()
        {
            var currentUser = umbraco.BusinessLogic.User.GetCurrent();
            //  var permissions = umbraco.BusinessLogic.User.GetCurrent().GetPermissions();
            var permission = umbraco.BusinessLogic.UserType.GetUserType(currentUser.Id);

            if (permission.DefaultPermissions.Contains(ActionDeleteOperator.Instance.Letter))
            {
                //Create a save button from the current datatab.
                btnDelete = dataTab.Menu.NewImageButton();
                btnDelete.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                btnDelete.ID = "btnDelete";
                btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);
                btnDelete.AlternateText = "Delete";
                btnDelete.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_delete_operator.png";
                btnDelete.ValidationGroup = "";
            }
        }

        public ImageButton btnDelete;
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    var selectedIds = this.GetSelectedIds();
                    foreach (var id in selectedIds)
                    {
                        this.NarnooRequest.DeleteOperator(id);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClientTools.ShowSpeechBubble(speechBubbleIcon.error, "Error", ex.Message);
            }
        }
        #endregion


        string[] GetSelectedIds()
        {
            return this.Request.Form["selected"].Split(',');
        }

     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.DataBind(1);
            }
        }

        void DataBind(int page_no)
        {
            var data = this.NarnooRequest.ListOperators(page_no);
            this.rptItems.DataSource = data;
            this.rptItems.DataBind();
            this.Pager1.DataBind(page_no, data.TotalPages, data.Count);
        }
        void Pager1_PageIndexChanged(int newPageIndex)
        {
            this.DataBind(newPageIndex);
        }

    }
}