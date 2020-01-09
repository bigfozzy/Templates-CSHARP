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
    public class XHECheapsms : XHEBaseSMS
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // constructor
        public XHECheapsms(XHEScriptBase script, string api, string servis = "http://cheapsms.ru")
           : base(api, servis)
        {
            _Script = script;
            this.api_key = api;
            this.servis = servis;
            this.refCode = "humanem";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}