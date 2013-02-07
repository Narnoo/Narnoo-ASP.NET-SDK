using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    /// <summary>
    /// Summary description for operators
    /// </summary>
    public class operators : NarnooRequest, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var page_no = context.Request["page_no"];

                if (string.IsNullOrWhiteSpace(page_no))
                {
                    page_no = "1";
                }

                var data = this.ApiClient.ListOperators(int.Parse(page_no));

                context.Response.Write(JsonConvert.SerializeObject(new { items = data.ToArray(), total = data.TotalPages, current = int.Parse(page_no) }));
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new { error = ex.Message }));

            }
            finally
            {
                context.Response.End();
            }
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