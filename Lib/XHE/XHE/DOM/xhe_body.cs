using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////////// Body ///////////////////////////////////////////////////////
    public class XHEBody : XHEBaseDOMVisual
    {
        //////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////
        // server initialization
        public XHEBody(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Body";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // запретить сообщение, подтверждающее желание покинуть текущую страницу (no wait exist mode)
        public bool disable_onunload_message(string frame = "-1")
        {
            string[,] aParams = new string[,] { { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////	
    };
}