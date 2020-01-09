using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    /////////////////////////////////////////// Anchor //////////////////////////////////////////////////////////
    public class XHEAnchor : XHEBaseDOMVisual
    {
        //////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////////////
        // initialization
        public XHEAnchor(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Anchor";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить все href (no wait exist mode)
        public string get_all_hrefs(string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        //  получить все href с заданными внутренними текстами (no wait exist mode)
        public string get_all_hrefs_by_inner_text(string inner_text, string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить все href с заданными внутренними текстами (no wait exist mode)
        public string get_all_hrefs_by_inner_text_2(string inner_text, int exactly = 1, string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить все href с заданными значениями аттрибута (no wait exist mode)
        public string get_all_hrefs_by_attribute(string attr_name, string attr_value, int exactly = 1, string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_name", attr_name }, { "exactly", exactly.ToString() }, { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить все внутренние тексты по href (no wait exist mode)
        public string get_all_inner_texts_by_href(string href, string separator = "<br>", int exactly = 1, string frame = "-1")
        {
            return z_get_all_inner_texts_by_href(href, separator, exactly, frame);
        }

        // получить все внешние ссылки, относительно заданного урла (no wait exist mode)
        public string get_all_external_inner_texts_and_hrefs(string href, bool navigate = false, string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "href", href }, { "navigate", navigate.ToString() }, { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить все внутренние ссылки, относительно заданного урла (no wait exist mode)
        public string get_all_internal_inner_texts_and_hrefs(string href, bool navigate = false, string separator = "<br>", string frame = "-1")
        {
            string[,] aParams = new string[,] { { "href", href }, { "navigate", navigate.ToString() }, { "separator", separator }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    };

}