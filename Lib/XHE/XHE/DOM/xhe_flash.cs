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

	    // �������� ������ ���� � �������� � �������� �������
	    public string get_version_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);		

		    string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // �������� ��������� ���������� ���� �� ������
	    public string get_ready_state_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // �������� ������������� �� ���� �� ������
	    public bool is_playing_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // ��������� ���� � �������� �������
	    public bool play_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ���� ������ �� ���� � �������� �������
	    public bool forward_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ���� ����� �� ���� � �������� �������
	    public bool back_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ���������� ���� � �������� �������
	    public bool stop_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // �������� ����� ������ �� ���� � �������� �������
	    public bool go_to_frame_by_number(int frame_number,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "frame_number", frame_number.ToString() }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // �������� ������� ���� �� ���� � �������� �������
	    public long get_current_frame_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_long(MethodBase.GetCurrentMethod().Name, aParams);
        }
	    // �������� ����� ������ �� ���� � �������� �������
	    public long get_frame_count_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_long(MethodBase.GetCurrentMethod().Name, aParams);
        }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // �������� ���� ���� �� ���� � �������� �������
	    public long get_background_color_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_long(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ������� ���� ���� �� ���� � �������� �������
	    public bool set_background_color_by_number(long color,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "color", color.ToString() }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // �������� ���� ���� �� ���� � �������� �������
	    public string get_movie_by_number(int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ������� ���� ���� �� ���� � �������� �������
	    public bool set_movie_by_number(string path,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "path", path }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // �������� ������� ����� �� ���� � �������� �������
	    public string get_current_label_by_number(string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ������� ����� �� ���� � �������� �������
	    public bool call_label_by_number(string label,string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "label", label }, { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ������� ����� �� ���� � �������� �������
	    public bool call_frame_by_number(int frame_number,string time,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "frame_number", frame_number.ToString() }, { "time", time }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

            /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // �������� �������� ���������� �� ���� � �������� �������
	    public string get_variable_by_number(string name,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "name", name }, { "number", number.ToString() }, { "frame", frame } };
		    return call_get(MethodBase.GetCurrentMethod().Name,aParams);
	    }
	    // ������� ����� �� ���� � �������� �������
	    public bool set_variable_by_number(string name,string value,int number,string frame="-1")
	    {
		    wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "value", value }, { "name", name }, { "number", number.ToString() }, { "frame", frame } };
		    return call_boolean(MethodBase.GetCurrentMethod().Name,aParams);
	    }

    };
}