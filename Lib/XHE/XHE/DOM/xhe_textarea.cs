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

        // ���������� ������ � ����� ����� � ��������� � �������� �������
        public bool seek_to_end_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� ������ � ����� ����� � ��������� � �������� ������
        public bool seek_to_end_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ����� '������ ������' � ��������� � �������� �������
        public bool set_readonly_by_number(int number, bool readonly_, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "readonly", readonly_.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� '������ ������' � ��������� � �������� ������
        public bool set_readonly_by_name(string name, bool readonly_, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name }, { "readonly", readonly_.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ����� '������ ������' � ��������� � �������� �������
        public bool get_readonly_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� '������ ������' � ��������� � �������� ������
        public bool get_readonly_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� ����� ����� � ��������� � �������� �������
        public int get_rows_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� ����� � ��������� � �������� ������
        public int get_rows_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� ����� �������� � ��������� � �������� �������
        public int get_cols_by_number(int number, string frame = "-1")
        {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� �������� � ��������� � �������� ������
        public int get_cols_by_name(string name, string frame = "-1")
        {
		    wait_element_exist_by_name(name,frame);		

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////
    };      
}