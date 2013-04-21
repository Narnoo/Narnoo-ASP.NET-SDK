
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessDeleteVideo
    /// </summary>
    public class ProcessDeleteVideo : DistributorHanlder
    {
        public override void ProcessRequest(HttpContext context)
        {

            var video_id = context.Request["video_id"];

            try
            {
               // this.NarnooMediaRequest.DeleteVideo(video_id);
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