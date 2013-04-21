
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessRemoveImage
    /// </summary>
    public class ProcessRemoveImage : DistributorHanlder
    {

        public override void ProcessRequest(HttpContext context)
        {
            var album_id = context.Request["album_id"];
            var image_id = context.Request["image_id"];

            try
            {
                this.NarnooMediaRequest.removeFromAlbum(image_id, album_id);
                context.Response.Write("{}");
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new { error = ex.Message }));
            }

            context.Response.Flush();
            context.Response.End();
        }
    }
}