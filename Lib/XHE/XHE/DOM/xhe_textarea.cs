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
////////////////////////////////////////////// TextArea /////////////////////////////////////////////////////
    public class XHETextArea : XHEBaseDOMVisual
    {
        /////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////////
        // server initialization
        public XHETextArea(string server, string password, XHEScriptBase script)
        : base(server, password)
        {
            Script = script;
            m_Prefix = "TextArea";
        }
	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // прокрутить курсор в самый конец в текстарии с заданным номером
        public bool seek_to_end_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // прокрутить курсор в самый конец в текстарии с заданным именем
        public bool seek_to_end_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // изменить режим 'только чтение' в текстарии с заданным номером
        public bool set_readonly_by_number(int number, bool readonly_, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "readonly", readonly_.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // изменить режим 'только чтение' в текстарии с заданным именем
        public bool set_readonly_by_name(string name, bool readonly_, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name }, { "readonly", readonly_.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить режим 'только чтение' у текстарии с заданным номером
        public bool get_readonly_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить режим 'только чтение' у текстарии с заданным именем
        public bool get_readonly_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить число строк у текстарии с заданным номером
        public int get_rows_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить число строк у текстарии с заданным именем
        public int get_rows_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить число столбцов у текстарии с заданным номером
        public int get_cols_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить число столбцов у текстарии с заданным именем
        public int get_cols_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////
    };      
}