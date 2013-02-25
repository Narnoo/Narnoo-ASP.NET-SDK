using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for LinkBuilder
    /// </summary>
    public class LinkBuilder : DistributorHanlder
    {



        public override void ProcessRequest(HttpContext context)
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

            context.Response.Write( JsonSerializer.SerializeToString(link));
            context.Response.Flush();
            context.Response.End();
        }


    }
}