using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    ////////////////////////////////////////////////////// Head /////////////////////////////////////////////
    public class XHEHead : XHEBaseDOMVisual
    {
        /////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        // server initialization
        public XHEHead(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Head";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}