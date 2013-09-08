using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using EBA.Helpers;

namespace Narnoo.Umbraco.Distributors.Narnoo.handlers
{
    /// <summary>
    /// Summary description for Video
    /// </summary>
    public class VideoHandler : HandlerBase
    {

        protected override void Process(HttpRequest request, HttpResponse response)
        {
            var serializer = new JavaScriptSerializer();

            var narnoo_video_shortcode_count = request.Form["narnoo_video_shortcode_count"];
            var id = request.Form["video_id"];
            var width = request.Form["width"];
            var height = request.Form["height"];
            var operator_id = request.Form["operator_id"];
            Video video = null;

            // request video details from API

            if (operator_id.HasValue())
            {
                try
                {
                    video = this.NarnooOperatorMediaRequest.GetVideoDetails(operator_id,id);
                }
                catch (Exception ex)
                {
                    response.Write(serializer.Serialize(new { response = ex.Message }));
                    return;
                }
            }
            else
            {
                try
                {
                    video = this.NarnooMediaRequest.GetVideoDetails(id);
                }
                catch (Exception ex)
                {
                    response.Write(serializer.Serialize(new { response = ex.Message }));
                    return;
                }

            }


            var pause_image_dir = request.MapPath("/umbarco/narnoo/temp/tmp_pause_img/");   // relative directory containing temporary pause images


            if (Directory.Exists(pause_image_dir) == false)
            {
                Directory.CreateDirectory(pause_image_dir);
            }

            // need to download pause image to local server, in order to pass to flashvars
            // first we delete all previously downloaded pause image files older than 5 minutes

            foreach (var file in Directory.GetFiles(pause_image_dir))
            {
                var info = new FileInfo(file);
                if (info.LastWriteTime.AddMinutes(5) < DateTime.Now)
                {
                    File.Delete(file);
                }
            }

            Uri uri = new Uri(video.video_pause_image_path);
            string pause_image_filename = System.IO.Path.GetFileName(uri.LocalPath);

            var pause_image_fileurl = "/umbarco/narnoo/temp/tmp_pause_img/" + pause_image_filename;
            var pause_image_filepath = request.MapPath(pause_image_fileurl);


            var client = new WebClient();
            // Response.AddHeader("content-disposition", "attachment; filename=" + vide);
            client.DownloadFile(video.video_pause_image_path, pause_image_filepath);


            var content = "<script type='text/javascript'>"
            + "narnoo_video.flashvars[" + narnoo_video_shortcode_count + "].swfMovie = encodeURIComponent('" + HttpUtility.HtmlDecode(Utilities.DecodeCData(video.video_stream_path)) + "');"
            + "narnoo_video.flashvars[" + narnoo_video_shortcode_count + "].swfMovieHQ = encodeURIComponent('" + HttpUtility.HtmlDecode(Utilities.DecodeCData(video.video_hqstream_path)) + "');"
            + "narnoo_video.flashvars[" + narnoo_video_shortcode_count + "].swfThumb = encodeURIComponent('" + pause_image_fileurl + "');"
            + "</script>"
            + "<video width='" + width + "' height='" + height + "' controls='controls' poster='" + pause_image_fileurl + "'>"
            + "	<source src='" + HttpUtility.HtmlDecode(Utilities.DecodeCData(video.video_stream_path)) + "' type='video/mp4' />"
            + "  <source src='" + HttpUtility.HtmlDecode(Utilities.DecodeCData(video.video_webm_path)) + "' type='video/webm' />"
            + "	Your browser does not support the html5 video tag."
            + "</video>";

       
            response.Write(serializer.Serialize(new { response = content }));

        }
    }
}