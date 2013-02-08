using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BasePages;

namespace Narnoo.Umbraco.Distributors.Narnoo.Distributors
{
    public class DistributorPage : BasePage
    {
        public DistributorPage():base()
        {
            this.NarnooRequest = new DistributorNarnooRequest();
            var settings = new ApiSettings();
            settings.Load();
            this.NarnooRequest.SetAuth(settings.Appkey, settings.Secretkey);
            this.NarnooRequest.Sandbox = false;
        }

        protected DistributorNarnooRequest NarnooRequest
        {
            get;
            set;
        }
    }
}