using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    ////////////////////////////////////////////////////// Blockquote ///////////////////////////////////////
    public class XHEBlockquote : XHEBaseDOMVisual
    {
        /////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        // server initialization
        public XHEBlockquote(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Blockquote";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}