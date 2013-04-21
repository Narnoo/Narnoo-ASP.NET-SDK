
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessDeleteImage
    /// </summary>
    public class ProcessDeleteImage : DistributorHanlder
    {
        public override void ProcessRequest(HttpContext context)
        {
         
            var image_id = context.Request["image_id"];

            try
            {
                this.NarnooMediaRequest.DeleteImage(image_id);
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