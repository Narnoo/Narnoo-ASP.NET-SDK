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
    public partial class AddOperators : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.BindOperators(1);
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Pager1.PageIndexChanged += Pager1_PageIndexChanged;

            dataTab = TabViewDetails.NewTabPage("Search/Add Operators");
            dataTab.Controls.Add(this.tabOperators);

            btnAdd = dataTab.Menu.NewImageButton();
            btnAdd.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            btnAdd.ID = "btnAdd";
            //btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);
            btnAdd.AlternateText = "Add";
            btnAdd.ImageUrl = GlobalSettings.Path + "/narnoo/distributors/icons/icons_add_operator.png";
            btnAdd.ValidationGroup = "";

            this.btnSearch.Click += btnSearch_Click;

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindOperators(1);
        }

        void BindOperators(int pageIndex)
        {
            var data = this.NarnooRequest
                .SearchOperators(this.search_country.Text,
                this.search_category.Text,
                this.search_subcategory.Text,
                this.search_state.Text,
                this.search_suburb.Text,
                this.search_postal_code.Text,
                pageIndex);

            this.rptOperators.DataSource = data;
            this.rptOperators.DataBind();
            this.Pager1.DataBind(pageIndex, data.TotalPages, data.Count);
        }

        private void Pager1_PageIndexChanged(int newPageIndex)
        {
            this.BindOperators(newPageIndex);
        }

        public TabPage dataTab;
        public ImageButton btnAdd;
    }
}