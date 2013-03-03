using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for ProcessAddOperators
    /// </summary>
    public class ProcessAddOperators : DistributorHanlder
    {

        public override void ProcessRequest(HttpContext context)
        {
            var id = context.Request["id"];

            try
            {
                this.NarnooRequest.AddOperator(id);
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