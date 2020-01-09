using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using System.Threading;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////////////// Form ///////////////////////////////////////////////////
    public class XHEForm : XHEBaseDOMVisual
    {
        ///////////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEForm(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Form";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // сделать сабмит формы с заданным номером
        public bool submit_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // сделать сабмит формы с заданным именем
        public bool submit_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // сделать сабмит формы с заданным id
        public bool submit_by_id(string id, string frame = "-1")
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // сделать сабмит формы с заданным action
        public bool submit_by_action(string action, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute("action", action, exactly, frame);

            string[,] aParams = new string[,] { { "action", action }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // сделать сабмит формы с заданным значением аттрибута
        public bool submit_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // сделать сброс формы с заданным номером
        public bool reset_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сделать сброс формы с заданным именем
        public bool reset_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить action формы с заданным номером
        public string get_action_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить action формы с заданным именем
        public string get_action_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить action формы с заданным id
        public string get_action_by_id(string id, string frame = "-1")
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}