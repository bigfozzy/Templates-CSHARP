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
    //////////////////////////////////////////////////// Frame //////////////////////////////////////////////////
    public class XHEFrame : XHEBaseDOMVisual
    {
        ///////////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEFrame(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Frame";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить тело фрейма по его номеру
        public string get_body_by_number(int number, bool as_html, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать тело фрейма по его номеру
        public bool set_body_by_number(int number, string html_body, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "html_body", html_body }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}