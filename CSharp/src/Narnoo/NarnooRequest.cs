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



        protected T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
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
            data.Add("secret_key="+this.secretkey);
            data.Add("response_type="+this.response_type);
            data.Add("action="+method);


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
                    // {"Error":{"ErrorCode":"Error 202","ErrorMessage":"Sorry, Authentication Failed, May be Response Type Invalid OR Action Invalid !!!."}}
                    if (content.StartsWith("{\"Error\":"))
                    {
                        var error = this.Deserialize<NarnooErrorResponse>(content);

                        throw new InvalidNarnooRequestException(error.Error.ErrorCode,error.Error.ErrorMessage);

                    }
                }
                else
                {
                    // <?xml version="1.0" encoding="UTF-8"?><Error>
                    //<ErrorCode>Error 202</ErrorCode>
                    //<ErrorMessage>Sorry, Authentication Failed, May be Response Type Invalid OR Action Invalid !!!.</ErrorMessage>
                    //</Error>
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content);

                    if (doc.FirstChild.Name == "Error")
                    {
                        var errorCode = doc.FirstChild.FirstChild.Value;
                        var errorMessage = doc.FirstChild.LastChild.Value;
                        throw new InvalidNarnooRequestException(errorCode, errorMessage);
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
