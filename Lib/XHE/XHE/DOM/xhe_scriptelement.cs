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
    //////////////////////////////////////////////////// Script /////////////////////////////////////////////////
    public class XHEScriptElement : XHEBaseDOMVisual
    {
        ////////////////////////////////////// SERVICVE FUNCTIONS ///////////////////////////////////////////
        // server initialization
        public XHEScriptElement(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "ScriptElement";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать defer у скрипта с заданным номером
        public bool set_defer_by_number(int number, bool defer, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "defer", defer.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать defer у скрипта с заданным src
        public bool set_defer_by_src(string src, bool defer, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "defer", defer.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать htmlFor у скрипта с заданным номером
        public bool set_htmlFor_by_number(int number, string htmlFor, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "htmlFor", htmlFor }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать htmlFor у скрипта с заданным src
        public bool set_htmlFor_by_src(string src, string htmlFor, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "htmlFor", htmlFor }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать event у скрипта с заданным номером
        public bool set_event_by_number(int number, string event_, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "event", event_ }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать event у скрипта с заданным src
        public bool set_event_by_src(string src, string event_, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "event", event_ }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать src у скрипта с заданным номером
        public bool set_src_by_number(int number, string src, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "src", src }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать текст у скрипта с заданным номером
        public bool set_text_by_number(int number, string text, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "text", text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать event у скрипта с заданным src
        public bool set_text_by_src(string src, string text, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "text", text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать тип у скрипта с заданным номером
        public bool set_type_by_number(int number, string type, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "type", type }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать тип у скрипта с заданным src
        public bool set_type_by_src(string src, string type, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "type", type }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить defer у скрипта с заданным номером
        public bool get_defer_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить defer у скрипта с заданным src
        public bool get_defer_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить htmlFor у скрипта с заданным номером
        public string get_htmlFor_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить htmlFor у скрипта с заданным src
        public string get_htmlFor_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить event у скрипта с заданным номером
        public string get_event_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить event у скрипта с заданным src
        public string get_event_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить readyState у скрипта с заданным номером
        public string get_readyState_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить readyState у скрипта с заданным src
        public string get_readyState_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить текст скрипта с заданным номером
        public string get_text_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст скрипта с заданным src
        public string get_text_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить тип скрипта с заданным номером
        public string get_type_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить тип скрипта с заданным номером
        public string get_type_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить что все скрипты находятся в незапущенном стостоянии (no wait exist mode)
        public bool is_all_completed()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}