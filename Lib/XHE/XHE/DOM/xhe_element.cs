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
    ///////////////////////////////////////////////// Element ///////////////////////////////////////////////////
    public class XHEElement : XHEBaseDOMVisual
    {
        /////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHEElement(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Element";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� tag �������� �� ������
        public string get_tag_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� x ���������� �������� � �������� ����� �� ������
        public int get_x_by_tag_by_number(string tag, int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "tag", tag }, { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� y ���������� �������� � �������� ����� �� ������
        public int get_y_by_tag_by_number(string tag, int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "tag", tag }, { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ��� �������� � �������� �����
        public XHEInterfaces get_all_by_tag(string tag, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "tag", tag }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers, m_Server, m_Password);
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������������� ����� �������� � ����� ��������� �������
        public int convert_number(int number, string object_name, string frame = "-1")
        {
            XHEInterface elm = get_by_number(number, frame);
            if (!elm.is_exist())
                return - 1;

            return elm.get_number(object_name);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

	// �������� ��������� ������� ����� querySelector
	public XHEInterface get_by_query_selector(string selector,string frame="-1")
	{
		string[,] aParams = new string[,] { { "selector", selector } , { "frame", frame }};
		string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

		return new XHEInterface(internal_number, m_Server, m_Password);
	}	
	// �������� ���������� �������� ����� querySelectorAll
	public XHEInterfaces get_all_by_query_selector(string selector,string frame="-1")
	{
            	string[,] aParams = new string[,] { { "selector", selector } , { "frame", frame }};
            	string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            	return new XHEInterfaces(internal_numbers, m_Server, m_Password);
	}	
	// �������� ��������� ������� ��������� js
	public XHEInterface get_by_js(string js,string add_file="",string frame="-1")
	{
		string[,] aParams = new string[,] { { "js", js }, { "add_file", add_file } , { "frame", frame }};
		string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

		return new XHEInterface(internal_number, m_Server, m_Password);
	}	
	// �������� ���������� �������� ��������� js 
	public XHEInterfaces get_all_by_js(string js,string add_file="",string frame="-1")
	{
            	string[,] aParams = new string[,] { { "js", js }, { "add_file", add_file } , { "frame", frame }};
            	string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            	return new XHEInterfaces(internal_numbers, m_Server, m_Password);
	}	

	/////////////////////////////////////////////////////////////////////////////////////////////////////

    };
}