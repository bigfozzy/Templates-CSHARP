using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;
using System.Collections.Specialized;

namespace XHE.XHE_Web
{
    //////////////////////////////////////////////////////// smsactivate ///////////////////////////////////////////////////////
    public class XHESmsActivate : XHEBaseSMS
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // constructor
        public XHESmsActivate(XHEScriptBase script, string api, string servis = "http://sms-activate.ru")
           : base(api, servis)
        {
            _Script = script;
            this.api_key = api;
            this.servis = servis;
            this.refCode = "humanemulator";
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}