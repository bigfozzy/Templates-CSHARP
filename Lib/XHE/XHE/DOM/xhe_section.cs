using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    ////////////////////////////////////////////////////// Section /////////////////////////////////////////////
    public class XHESection : XHEBaseDOMVisual
    {
        /////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        // server initialization
        public XHESection(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Section";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}