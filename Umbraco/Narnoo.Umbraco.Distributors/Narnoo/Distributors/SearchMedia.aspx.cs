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
    public partial class SearchMedia : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TabPage dataTab;
        ImageButton btnDownload;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Pager1.PageIndexChanged += Pager1_PageIndexChanged;

            dataTab = TabViewDetails.NewTabPage("Narnoo Media - Search");
            dataTab.Controls.Add(this.tabSearch);

            btnDownload = dataTab.Menu.NewImageButton();
            btnDownload.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnDownload.ID = "btnDownload";
            //btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);
            btnDownload.AlternateText = "Download";
            btnDownload.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_download.png";
            btnDownload.ValidationGroup = "";

            this.btnSearch.Click += btnSearch_Click;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Pager1_PageIndexChanged(int newPageIndex)
        {
            throw new NotImplementedException();
        }

        void BindMedia(int pageIndex = 1)
        {
           
        }
    }
}