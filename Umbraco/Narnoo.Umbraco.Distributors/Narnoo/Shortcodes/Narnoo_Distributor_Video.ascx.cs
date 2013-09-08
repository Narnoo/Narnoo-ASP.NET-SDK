using Narnoo.Umbraco.Distributors.Narnoo.Macros;
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

    //    id:
    //width:
    //height:
    //autoplay:no/yes
    //play_btn_scale:
    //text_color:
    //play_color:
    //playover_color
    //playbk_color
    //bar_color
    //clocktotal_color
    //timesplit_color
    //clock_color
    //loaded_color
    //playhead_color
    //progress_color

    public partial class Narnoo_Distributor_Video : ShortcodeBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptContext.Current
                .Include("swfobject","/umbraco/narnoo/scripts/swfobject.js")
                .Include("Narnoo_Shortcode_Video", "/umbraco/narnoo/scripts/narnoo_video.js");
        }

        public string id { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public bool autoplay { get; set; }
        public string play_btn_scale { get; set; }
        public string text_color { get; set; }
        public string play_color { get; set; }
        public string playover_color { get; set; }
        public string playbk_color { get; set; }
        public string playbk_alpha { get; set; }
        public string playbkover_color { get; set; }
        public string rollover_color { get; set; }
        public string bar_color { get; set; }
        public string clocktotal_color { get; set; }
        public string timesplit_color { get; set; }
        public string clock_color { get; set; }
        public string loaded_color { get; set; }
        public string playhead_color { get; set; }
        public string progress_color { get; set; }

        public int VideoCount
        {
            get
            {
                var val = HttpContext.Current.Items["Narnoo_Distributor_Video"];
                if (val == null)
                {
                    HttpContext.Current.Items["Narnoo_Distributor_Video"] = 0;
                    return 0;
                }
                else
                {
                    return (int)val;
                }
            }
        }

        public void IncreaseVideoCount()
        {
            var val = this.VideoCount;
            HttpContext.Current.Items["Narnoo_Distributor_Video"] = val + 1;
        }

        public override string RenderContent()
        {
            var content = "<div style='height: " + this.height + "px; width: " + this.width + "px;'>"
                   + "  <div style='height: " + this.height + "px; width: " + this.width + "px;' class='narnoo_video' data-id='" + this.id + "' data-count='" + this.VideoCount + "' data-width='" + this.width + "' data-height='" + this.height + "' data-operator-id='' id='narnooVideoFallback" + this.VideoCount + "'>"
                   + "      <div style='height: " + this.height + "px; width: " + this.width + "px; background: #ffffff url(/umbraco/narnoo/images/loader.gif) no-repeat center center;'></div>"
                   + "  </div>"
                   + "</div>"
                   + "<script type='text/javascript'>"
                   + " if (typeof narnoo_video === 'undefined') {"
                   + "      narnoo_video = { count: 0, widths: [], heights: [], flashvars: [] };"
                   + "      narnoo_video_url = '/umbraco/narnoo/scripts/';"
                //        narnoo_video_file_url = 'D:\\Program Files\\Apache Software Foundation\\Apache2.2\\htdocs\\wordpress\\wp-content\\plugins\\narnoo-distributor\\libs\\narnoo_video\\video.php';
                   + "      narnoo_video_ajax_url = '/umbraco/narnoo/handlers/VideoHandler.ashx';"
                   + "}"
                   + "flashvars = {};  ";
            if (this.autoplay)
            {
                content += "flashvars.autoplay='yes';";
            }

            if (this.play_btn_scale.HasValue())
            {
                content += "flashvars.play_btn_scale = '" + this.play_btn_scale + "';                  ";
            }
            if (this.text_color.HasValue())
            {
                content += "flashvars.text_color = '" + this.text_color + "';                   ";
            }

            if (this.play_color.HasValue())
            {
                content += "flashvars.play_color = '" + this.play_color + "';                   ";
            }
            if (this.playover_color.HasValue())
            {
                content += "flashvars.playover_color = '" + this.playover_color + "';               ";
            }
            if (this.playbk_color.HasValue())
            {
                content += "flashvars.playbk_color = '" + this.playbk_color + "';                 ";
            }
            if (this.playbk_alpha.HasValue())
            {
                content += "flashvars.playbk_alpha = '" + this.playbk_alpha + "';                 ";
            }
            if (this.playbkover_color.HasValue())
            {
                content += "flashvars.playbkover_color = '" + this.playbkover_color + "';             ";
            }
            if (this.rollover_color.HasValue())
            {
                content += "flashvars.rollover_color = '" + this.rollover_color + "';               ";
            }
            if (this.bar_color.HasValue())
            {
                content += "flashvars.bar_color = '" + this.bar_color + "';                    ";
            }
            if (this.clocktotal_color.HasValue())
            {
                content += "flashvars.clocktotal_color = '" + this.clocktotal_color + "';             ";
            }
            if (this.timesplit_color.HasValue())
            {
                content += "flashvars.timesplit_color = '" + this.timesplit_color + "';              ";
            }
            if (this.clock_color.HasValue())
            {
                content += "flashvars.clock_color = '" + this.clock_color + "';                  ";
            }
            if (this.loaded_color.HasValue())
            {
                content += "flashvars.loaded_color = '" + this.loaded_color + "';                 ";
            }
            if (this.playhead_color.HasValue())
            {
                content += "flashvars.playhead_color = '" + this.playhead_color + "';               ";
            }
            if (this.progress_color.HasValue())
            {
                content += "flashvars.progress_color = '" + this.progress_color + "';               ";
            }

            content += "narnoo_video.heights.push('" + this.height + "');                ";
            content += "narnoo_video.widths.push('" + this.width + "');                 ";
            content += "narnoo_video.flashvars.push(flashvars);          ";
            content += "narnoo_video.count++;	                        ";
            content += "</script>";

            this.IncreaseVideoCount();

            return content;

        }



        public override string RenderDesignContent()
        {

            var content = "[narnoo_distributor_video ";

            if (this.id.HasValue())
            {
                content += " id='" + this.id + "' ";
            }

            if (this.width.HasValue())
            {

                content += " width='" + this.width + "'";

            }

            if (this.height.HasValue())
            {

                content += " height='" + this.height + "'";

            }

            if (this.autoplay)
            {
                content += "autoplay='yes' ";
            }

            if (this.play_btn_scale.HasValue())
            {
                content += "play_btn_scale='" + this.play_btn_scale + "' ";
            }

            if (this.text_color.HasValue())
            {
                content += " text_color='" + this.text_color + "' ";
            }

            if (this.play_color.HasValue())
            {
                content += "play_color='" + this.play_color + "' ";
            }
            if (this.playover_color.HasValue())
            {
                content += "playover_color='" + this.playover_color + "'";
            }
            if (this.playbk_color.HasValue())
            {
                content += "playbk_color='" + this.playbk_color + "' ";
            }
            if (this.playbk_alpha.HasValue())
            {
                content += " playbk_alpha='" + this.playbk_alpha + "' ";
            }
            if (this.playbkover_color.HasValue())
            {
                content += " playbkover_color='" + this.playbkover_color + "' ";
            }
            if (this.rollover_color.HasValue())
            {
                content += "rollover_color='" + this.rollover_color + "' ";
            }
            if (this.bar_color.HasValue())
            {
                content += " bar_color='" + this.bar_color + "'";
            }
            if (this.clocktotal_color.HasValue())
            {
                content += " clocktotal_color='" + this.clocktotal_color + "' ";
            }
            if (this.timesplit_color.HasValue())
            {
                content += "timesplit_color='" + this.timesplit_color + "' ";
            }
            if (this.clock_color.HasValue())
            {
                content += " clock_color='" + this.clock_color + "' ";
            }
            if (this.loaded_color.HasValue())
            {
                content += " loaded_color='" + this.loaded_color + "' ";
            }
            if (this.playhead_color.HasValue())
            {
                content += " playhead_color='" + this.playhead_color + "' ";
            }
            if (this.progress_color.HasValue())
            {
                content += "progress_color='" + this.progress_color + "' ";
            }


            content += "]";

            this.IncreaseVideoCount();

            return content;

        }
    }
}