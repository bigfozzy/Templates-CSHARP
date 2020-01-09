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
    public class XHE5Simnet : XHEBaseSMS
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // constructor
        public XHE5Simnet(XHEScriptBase script, string api, string servis= "http://sms-activate.api.5sim.net")
           : base(api, servis)
        {
            _Script = script;
            this.api_key = api;
            this.servis = servis;
            this.refCode = "ze7luo";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}