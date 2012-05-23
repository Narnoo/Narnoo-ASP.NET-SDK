using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Narnoo
{
    public class Utilities
    {
        public static string DecodeCData(string cdata)
        {

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"\<\!\[CDATA\[(?<text>[^\]]*)\]\]\>", options);
 

            // Check for match
            bool isMatch = regex.IsMatch(cdata);
            if (isMatch)
            {
                var match = regex.Match(cdata);
                string text = match.Groups["text"].Value;
                return HttpUtility.HtmlDecode(text);
            }
            else
            {
                return HttpUtility.HtmlDecode(cdata);
            }

        }
    }
}
