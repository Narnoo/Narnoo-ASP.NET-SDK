using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public abstract class NarnooRequest
    {
        public NarnooRequest()
        {
            this.ApiClient = new DistributorNarnooRequest();
            var settings = new ApiSettings();
            settings.Load();
            this.ApiClient.SetAuth(settings.Appkey, settings.Secretkey);
            this.ApiClient.Sandbox = false;
        }

        protected DistributorNarnooRequest ApiClient
        {
            get;
            set;
        }
    }
}