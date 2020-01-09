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
    //////////////////////////////////////////////////// InputImage /////////////////////////////////////////////
    public class XHEInputImage : XHEBaseDOMVisual
    {
        //////////////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////
        // server initialization
        public XHEInputImage(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "InputImage";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}