using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_System
{
    //////////////////////////////////////////// Clipboard //////////////////////////////////////////////////////
    public class XHEClipboard : XHEBaseObject
    {
        //////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////
        // конструктор
        public XHEClipboard(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Clipboard";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить текущий текст из буффера обмена
        public string get_text()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать тект в буффер обмена
        public bool put_text(string text)
        {
            string[,] aParams = new string[,] { { "text", text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать html в буффер обмена
        public bool put_html(string html,string url = "")
        {
            string[,] aParams = new string[,] { { "html", html } , { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}