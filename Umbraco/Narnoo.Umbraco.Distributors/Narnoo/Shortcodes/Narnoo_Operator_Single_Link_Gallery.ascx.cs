using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbracoEx.Web;
using EBA.Helpers;

namespace Narnoo.Umbraco.Distributors.Narnoo.Shortcodes
{
    public partial class Narnoo_Operator_Single_Link_Gallery : ShortcodeBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptContext.Current
             .Include("imagebox", "/umbraco/narnoo/scripts/imagebox/imagebox.min.js")
             .Include("Narnoo_Shortcode_Video", "/umbraco/narnoo/scripts/narnoo_slideshow.js");
        }

        public string operator_id { get; set; }
        public string album_name { get; set; }
        public string width { get; set; }
        public string height { get; set; }



        public int GalleryIndex
        {
            get
            {
                var val = HttpContext.Current.Items["Narnoo_Single_Link_Gallery"];
                if (val == null)
                {
                    HttpContext.Current.Items["Narnoo_Single_Link_Gallery"] = 0;
                    return 0;
                }
                else
                {
                    return (int)val;
                }
            }
        }

        public void IncreaseGalleryIndex()
        {
            var val = this.GalleryIndex;
            HttpContext.Current.Items["Narnoo_Single_Link_Gallery"] = val + 1;
        }


        public override string RenderContent()
        {
            var content = "<div style='" + (this.height.HasValue() ? "height: " + this.height + "px;" : "") + (this.width.HasValue() ? " width: " + this.width + "px;" : "") + "' class='narnoo_slg' ";
            content += " data-operator-id='" + this.operator_id + "' data-count='" + this.GalleryIndex + "' ";
            if (this.width.HasValue())
            {
                content += " data-width='" + this.width + "' ";
            }
            if (this.width.HasValue())
            {
                content += " data-height='" + this.height + "' ";
            }
            if (this.width.HasValue())
            {
                content += " data-album-name='" + this.album_name + "'>";
            }
            content += "   <div style='" + (this.height.HasValue() ? "height: " + this.height + "px;" : "") + (this.width.HasValue() ? " width: " + this.width + "px;" : "") + " background: #ffffff url(/umbraco/narnoo/images/loader.gif) no-repeat center center;'></div>";
            content += " </div>";

            content += "<script type='text/javascript'>";
            content += "if (typeof narnoo_slideshow === 'undefined') {";
            content += "    narnoo_slideshow = { count: 0, album_names: [] };";
            content += "    narnoo_slideshow_ajax_url = '/umbraco/narnoo/handlers/galleryhandler.ashx';";
            content += "}";

            if (this.album_name.HasValue())
            {
                content += "narnoo_slideshow.album_names.push('" + this.album_name + "');";
            }
            content += "narnoo_slideshow.count++;";
            content += "</script>";

            this.IncreaseGalleryIndex();

            return content;
        }

        public override string RenderDesignContent()
        {
            return "[narnoo_operator_single_link_gallery album_name='" + this.album_name + "' "
                + (this.width.HasValue() ? " width='" + this.width + "'" : "")
                + (this.height.HasValue() ? " height='" + this.height + "'" : "") 
                + (this.operator_id.HasValue()?" operator_id='"+this.operator_id+"'":"")
                + "]";
        }
    }
}