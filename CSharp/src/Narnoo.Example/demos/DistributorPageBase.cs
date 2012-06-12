using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Narnoo.Example.demos
{
    public abstract class DistributorPageBase : PageBase
    {
        //protected string  appkey = "1000000000"; // Distributor App Key which they can get from their control panel after add application
        //protected string secretkey = "6af234c9bc0361452797fc14a5cc856ece4a5908"; // Distributor SecretKey which they can get from their control panel after add application

        protected string appkey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["distributor_app_key"];
            }
        }
        protected string secretkey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["distributor_secret_key"];
            }
        }
     
    }
}