using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessAddImage
    /// </summary>
    public class ProcessAddImage : DistributorHanlder
    {

        public override void ProcessRequest(HttpContext context)
        {
            var album_id = context.Request["album_id"];
            var image_id = context.Request["image_id"];

            try
            {
                this.NarnooMediaRequest.addToAlbum(image_id, album_id);
                context.Response.Write("{}");
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonSerializer.SerializeToString(new { error = ex.Message }));
            }

            context.Response.Flush();
            context.Response.End();
        }
    }
}