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

        // ������ defer � ������� � �������� �������
        public bool set_defer_by_number(int number, bool defer, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "defer", defer.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ defer � ������� � �������� src
        public bool set_defer_by_src(string src, bool defer, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "defer", defer.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ htmlFor � ������� � �������� �������
        public bool set_htmlFor_by_number(int number, string htmlFor, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "htmlFor", htmlFor }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ htmlFor � ������� � �������� src
        public bool set_htmlFor_by_src(string src, string htmlFor, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "htmlFor", htmlFor }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ event � ������� � �������� �������
        public bool set_event_by_number(int number, string event_, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "event", event_ }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ event � ������� � �������� src
        public bool set_event_by_src(string src, string event_, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "event", event_ }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ src � ������� � �������� �������
        public bool set_src_by_number(int number, string src, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "src", src }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ ����� � ������� � �������� �������
        public bool set_text_by_number(int number, string text, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "text", text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ event � ������� � �������� src
        public bool set_text_by_src(string src, string text, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "text", text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������ ��� � ������� � �������� �������
        public bool set_type_by_number(int number, string type, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "type", type }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ��� � ������� � �������� src
        public bool set_type_by_src(string src, string type, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "type", type }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� defer � ������� � �������� �������
        public bool get_defer_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� defer � ������� � �������� src
        public bool get_defer_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� htmlFor � ������� � �������� �������
        public string get_htmlFor_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� htmlFor � ������� � �������� src
        public string get_htmlFor_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� event � ������� � �������� �������
        public string get_event_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� event � ������� � �������� src
        public string get_event_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� readyState � ������� � �������� �������
        public string get_readyState_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� readyState � ������� � �������� src
        public string get_readyState_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� ����� ������� � �������� �������
        public string get_text_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� ������� � �������� src
        public string get_text_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� ��� ������� � �������� �������
        public string get_type_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��� ������� � �������� �������
        public string get_type_by_src(string src, string frame = "-1")
        {
            wait_element_exist_by_attribute("src", src, 1, frame);

            string[,] aParams = new string[,] { { "src", src }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ��� ��� ������� ��������� � ������������ ���������� (no wait exist mode)
        public bool is_all_completed()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}