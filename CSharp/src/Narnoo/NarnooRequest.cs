using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using Newtonsoft;
using Newtonsoft.Json;

namespace Narnoo
{
    public abstract class NarnooRequest
    {

        string appkey;
        string secretkey;
        string response_type = "json";
        bool requiredSSL = false;

        bool _sandbox = true;
        public bool Sandbox
        {
            get
            {
                return this._sandbox;
            }
            set
            {
                this._sandbox = value;
            }
        }

        string api_dist_xml = "devapi.narnoo.com/dist_xml.php";
        string api_live_dist_xml = "api.narnoo.com/dist_xml.php";

        string api_xml = "devapi.narnoo.com/xml.php";
        string api_live_xml = "api.narnoo.com/xml.php";

        string api_op_xml = "devapi.narnoo.com/op_xml.php";
        string api_live_op_xml = "api.narnoo.com/op_xml.php";


        protected string getDistXmlApi()
        {
            if (this.Sandbox == true)
            {
                return this.api_dist_xml;
            }
            else
            {
                return this.api_live_dist_xml;
            }
        }

        protected string getXmlApi()
        {
            if (this.Sandbox == true)
            {
                return this.api_xml;
            }
            else
            {
                return this.api_live_xml;
            }
        }

        protected string getOpXmlApi()
        {
            if (this.Sandbox == true)
            {
                return this.api_op_xml;
            }
            else
            {
                return this.api_live_op_xml;
            }
        }



        protected T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                throw new InvalidCastException(string.Format("[{0}] can NOT be converted into {1}", json, typeof(T)));
            }
        }

        public void SetAuth(string appkey, string secretkey)
        {
            this.appkey = appkey;
            this.secretkey = secretkey;
        }

        public string GetResponse(string remote_url, string method, params RequestParameter[] options)
        {

            var url = (this.requiredSSL ? "https://" : "http://") + remote_url;

            var data = new List<string>();
            data.Add("app_key=" + this.appkey);
            data.Add("secret_key=" + this.secretkey);
            data.Add("response_type=" + this.response_type);
            data.Add("action=" + method);

            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/x-www-form-urlencoded";

            if (options != null && options.Length > 0)
            {
                foreach (var o in options)
                {
                    if (string.IsNullOrEmpty(o.Value) == false)
                    {
                        data.Add(HttpUtility.UrlEncode(o.Name) + "=" + HttpUtility.UrlEncode(o.Value));
                    }
                }
            }

            byte[] buffer = encoding.GetBytes(string.Join("&", data.ToArray()));
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                var content = reader.ReadToEnd();

                if (response_type == "json")
                {
                    // {"error":{"errorCode":"Error 202","errorMessage":"Sorry, Authentication Failed, May be Response Type Invalid OR Action Invalid !!!."}}
                    if (content.StartsWith("{\"error\":", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var error = this.Deserialize<NarnooErrorResponse>(content);

                        throw new NarnooRequestException("[" + error.error.errorCode + "]" + error.error.errorMessage);

                    }
                }
                else
                {
                    // <?xml version="1.0" encoding="UTF-8"?><error>
                    //<errorCode>Error 202</errorCode>
                    //<errorMessage>Sorry, Authentication Failed, May be Response Type Invalid OR Action Invalid !!!.</errorMessage>
                    //</error>
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content);

                    if (doc.FirstChild.Name == "error")
                    {
                        var errorCode = doc.FirstChild.FirstChild.Value;
                        var errorMessage = doc.FirstChild.LastChild.Value;
                        throw new NarnooRequestException("[" + errorCode + "]" + errorMessage);
                    }

                }

                
                return content;
            }
        }

        public void SetRequiredSSL(bool requried_ssl)
        {
            this.requiredSSL = requried_ssl;
        }
    }
}
