using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    ////////////////////////////////////////////////////// H ///////////////////////////////////////////////////
    public class XHEH : XHEBaseDOMVisual
    {
        /////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        // server initialization
        public XHEH(string server, int number, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "H" + number.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}