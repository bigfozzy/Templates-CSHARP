using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////// CheckButtton ///////////////////////////////////////////////////
    public class XHECheckButton : XHEBaseDOMVisual
    {
        ///////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////////
        // server initialization
        public XHECheckButton(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "CheckButton";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� �� ���� ���������
        public bool click_all(string frame = "-1")
        {
            return z_click_all(frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������� �� ������
        public bool check_by_number(int number, bool check, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "check", check.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �� �����
        public bool check_by_name(string name, bool check, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "check", check.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �� value
        public bool check_by_value(string value, int exactly, bool check, string frame = "-1")
        {
            wait_element_exist_by_attribute("value", value, exactly, frame);

            string[,] aParams = new string[,] { { "value", value }, { "check", check.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �� �������� ���������
        public bool check_by_attribute(string attr_name, string attr_value, int exactly, bool check, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "check", check.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �� �������� ��������� � ����� � �������� ������� (no wait exist mode)
        public bool check_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, bool check, int form_number, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "check", check.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �� �������� ��������� � ����� � �������� ������ (no wait exist mode)
        public bool check_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, bool check, string form_name, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "check", check.ToString() }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // ������� ��� �������� (no wait exist mode)
        public bool check_all(bool check, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "check", check.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ���������� �� ������
        public bool is_check_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���������� �� �����
        public bool is_check_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���������� �� value
        public bool is_check_by_value(string value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute("value", value, exactly, frame);

            string[,] aParams = new string[,] { { "value", value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���������� �� �������� ���������
        public bool is_check_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}