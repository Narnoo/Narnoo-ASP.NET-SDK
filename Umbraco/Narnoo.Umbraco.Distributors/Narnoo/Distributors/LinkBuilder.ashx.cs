using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for LinkBuilder
    /// </summary>
    public class LinkBuilder : IHttpHandler
    {

        public LinkBuilder()
        {
            var settings = new ApiSettings();
            settings.Load();

            this.NarnooRequest = new DistributorNarnooRequest();
            this.NarnooRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooRequest.Sandbox = false;

            this.NarnooMediaRequest = new DistributorMediaNarnooRequest();
            this.NarnooMediaRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooMediaRequest.Sandbox = false;

            this.NarnooOperatorMediaRequest = new DistributorOperatorMediaNarnooRequest();
            this.NarnooOperatorMediaRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooOperatorMediaRequest.Sandbox = false;
        }

        #region NarnooRequest

        protected DistributorNarnooRequest NarnooRequest
        {
            get;
            set;
        }

        protected DistributorMediaNarnooRequest NarnooMediaRequest
        {
            get;
            set;
        }

        protected DistributorOperatorMediaNarnooRequest NarnooOperatorMediaRequest
        {
            get;
            set;
        } 
        #endregion

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var data = request["data"];
            var id = request["id"];
            var operator_id = request["operator_id"];
            var link = string.Empty;
            switch (data)
            {
                case "dist_operator_image":
                    var image = this.NarnooOperatorMediaRequest.DownloadImage(operator_id, id);
                    link = image.download_image_link;
                    break;
                case "dist_operator_brochure":
                    var brochure = this.NarnooOperatorMediaRequest.DownloadBrochure(operator_id, id);
                    link = brochure.download_brochure_to_pdf_path;
                    break;
                case "dist_operator_video":
                    var video = this.NarnooOperatorMediaRequest.DownloadVideo(operator_id, id);
                    link = video.download_video_stream_path;
                    break;
                default:
                    break;
            }

            context.Response.Write(string.Format("\"{0}\"", link.Replace("\"", "\\\"")));
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}