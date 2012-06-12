using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Narnoo.Example.demos
{
    public abstract class OperatorPageBase : PageBase
    {


        //protected string appkey = "1000000000"; // operator App Key which they can get from their control panel after add application
        //protected string secretkey = "3141c0bfc514c924da0ac9019384bc000af4285b"; // operator SecretKey which they can get from their control panel after add application

        protected string appkey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["operator_app_key"];
            }
        }
        protected string secretkey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["operator_secret_key"];
            }
        }

    }
}