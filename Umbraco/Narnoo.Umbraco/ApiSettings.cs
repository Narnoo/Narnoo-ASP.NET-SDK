using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using umbraco;

namespace Narnoo.Umbraco
{
    public class ApiSettings
    {
        public string Appkey { get; set; }
        public string Secretkey { get; set; }


        public void Load()
        {
            this.Appkey = System.Configuration.ConfigurationManager.AppSettings["narnoo_appkey"];
            this.Secretkey = System.Configuration.ConfigurationManager.AppSettings["narnoo_secretkey"];
        }

        public void Save()
        {
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            SaveSetting("narnoo_appkey", this.Appkey);
            SaveSetting("narnoo_secretkey", this.Secretkey);

            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void SaveSetting(string key, string value)
        {
            string fullWebConfigFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            XDocument xDocument = XDocument.Load(fullWebConfigFileName, LoadOptions.PreserveWhitespace);
            XElement appSettings = xDocument.Root.Descendants("appSettings").Single<XElement>();
            XElement setting = appSettings.Descendants("add").FirstOrDefault((XElement s) => s.Attribute("key").Value == key);
            if (setting == null)
            {
                appSettings.Add(new XElement("add", new object[]{
                    new XAttribute("key", key),
                    new XAttribute("value", value)
                }));
            }
            else
            {
                setting.Attribute("value").Value = value;
            }
            xDocument.Save(fullWebConfigFileName, SaveOptions.DisableFormatting);

        }
    }
}