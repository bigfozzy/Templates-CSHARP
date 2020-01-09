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
    /////////////////////////////////////////////// InputButton /////////////////////////////////////////////////
    public class XHEInputButton : XHEBaseDOMVisual
    {
        /////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHEInputButton(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "InputButton";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}