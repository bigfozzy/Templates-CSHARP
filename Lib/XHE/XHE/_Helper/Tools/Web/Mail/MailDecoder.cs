using System;
using System.Collections.Generic;
using System.Text;

namespace XHE._Helper.Tools.Web.Mail
{
    public class MailDecoder
    {
        public static byte[] ConvertFromBase64String(string base64String)
        {
            base64String = base64String.Trim(new char[] {'\r','\n'});
            base64String = base64String.Replace("\r\n", "");
            return Convert.FromBase64String(base64String);
        }
    }
}
