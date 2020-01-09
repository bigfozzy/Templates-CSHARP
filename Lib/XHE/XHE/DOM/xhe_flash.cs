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
    ////////////////////////////////////////////////////// Label ////////////////////////////////////////////////
    public class XHEFlash : XHEBaseDOMVisual
    {
        ///////////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEFlash(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Flash";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить версию флэш у элемента с заданным номером
	    public string get_version_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);		

		    string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // получить состояние готовности флэш по номеру
	    public string get_ready_state_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // получить проигрывается ли флэш по номеру
	    public bool is_playing_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // запустить флэш с заданным номером
	    public bool play_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // кадр вперед во флэш с заданным номером
	    public bool forward_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // кадр назад во флэш с заданным номером
	    public bool back_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // остановить флэш с заданным номером
	    public bool stop_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить число кадров во флэш с заданным номером
	    public bool go_to_frame_by_number(int frame_number,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "frame_number", frame_number.ToString() }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // получить текущий кадр во флэш с заданным номером
	    public long get_current_frame_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_long(MethodBase.GetCurrentMethod().Name, aParams);
        }
	    // получить число кадров во флэш с заданным номером
	    public long get_frame_count_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_long(MethodBase.GetCurrentMethod().Name, aParams);
        }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить цвет фона во флэш с заданным номером
	    public long get_background_color_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_long(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // зададим цвет фона во флэш с заданным номером
	    public bool set_background_color_by_number(long color,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "color", color.ToString() }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить цвет фона во флэш с заданным номером
	    public string get_movie_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // зададим цвет фона во флэш с заданным номером
	    public bool set_movie_by_number(string path,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "path", path }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить текущую метку во флэш с заданным номером
	    public string get_current_label_by_number(string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // вызвать метку во флэш с заданным номером
	    public bool call_label_by_number(string label,string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "label", label }, { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // вызвать фрейм во флэш с заданным номером
	    public bool call_frame_by_number(int frame_number,string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "frame_number", frame_number.ToString() }, { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить значение переменной во флэш с заданным номером
	    public string get_variable_by_number(string name,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "name", name }, { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // вызвать фрейм во флэш с заданным номером
	    public bool set_variable_by_number(string name,string value,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "value", value }, { "name", name }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

    };
}