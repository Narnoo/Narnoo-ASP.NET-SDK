using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessRemoveFromChannle
    /// </summary>
    public class ProcessRemoveFromChannle : DistributorHanlder
    {

        public override void ProcessRequest(HttpContext context)
        {
            var channel_id = context.Request["channel_id"];
            var video_id = context.Request["video_id"];

            try
            {
                this.NarnooMediaRequest.removeFromChannel(video_id,channel_id);
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