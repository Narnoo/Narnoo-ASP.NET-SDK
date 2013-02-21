using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public partial class Pager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DataBind(int currentPage, int totalPages, int totalRecords, int pageSize = 30)
        {
            this.totalPages.InnerText = totalPages.ToString();
            this.totalRecords.InnerText = string.Format("{0} items",totalRecords.ToString());
            this.txtCurrent.Text = currentPage.ToString();
            this.txtCurrent.Attributes.Add("size", currentPage.ToString().Length.ToString());
            this.lnkFirst.CommandArgument = "1";
            this.lnkLast.CommandArgument = totalPages.ToString();

            this.lnkPrev.Enabled = currentPage > 1;
            this.lnkPrev.CommandArgument = (currentPage - 1).ToString();

            this.lnkNext.Enabled = currentPage < totalPages;
            this.lnkNext.CommandArgument = (currentPage + 1).ToString();

        }



        protected void lnkFirst_Command(object sender, CommandEventArgs e)
        {
            this.ChangePageIndex(int.Parse(e.CommandArgument.ToString()));
        }

        protected void lnkPrev_Command(object sender, CommandEventArgs e)
        {
            this.ChangePageIndex(int.Parse(e.CommandArgument.ToString()));
        }

        protected void lnkNext_Command(object sender, CommandEventArgs e)
        {
            this.ChangePageIndex(int.Parse(e.CommandArgument.ToString()));
        }

        protected void lnkLast_Command(object sender, CommandEventArgs e)
        {
            this.ChangePageIndex(int.Parse(e.CommandArgument.ToString()));
        }

        void ChangePageIndex(int newPageIndex)
        {
            if (this.PageIndexChanged != null)
            {
                this.PageIndexChanged(newPageIndex);
            }
        }

        public event PageIndexEventHanlder PageIndexChanged;
    }

    public delegate void PageIndexEventHanlder(int newPageIndex);
}