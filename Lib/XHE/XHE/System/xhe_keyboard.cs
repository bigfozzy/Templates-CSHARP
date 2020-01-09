using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_System
{
    ///////////////////////////////////////////////////// Keyboard //////////////////////////////////////////////
    public class XHEKeyboard : XHEBaseObject
    {
        //////////////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////
        // server initialization
        public XHEKeyboard(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Keyboard";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� ���� ���� �������� �� ���������� ������� ������
        public bool input(string string_, string timeout = "20:40", bool inFlash = false, bool auto_change = true)
        {
            string[,] aParams = new string[,] { { "string", string_ }, { "timeout", timeout }, { "inFlash", inFlash.ToString() }, { "auto_change", auto_change.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            Thread.Sleep(1000);
            return res;
        }
        // ���������� ���� ����� ������ �� �� ���� ���� (deprecated)
        public bool press_key_by_code(int code)
        {
            string[,] aParams = new string[,] { { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� ���� ����� ������ �� �� ���� ����
        public bool key(int code)
        {
            string[,] aParams = new string[,] { { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ������� �������
        public bool key_down(string key)
        {
            string[,] aParams = new string[,] { { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ������� �������
        public bool key_up(string key)
        {
            string[,] aParams = new string[,] { { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���� ������ � �������, ���� ���� �� �����
        public bool send_input(string string_, string timeout = "0:2", bool inFlash = false, bool auto_change = true)
        {
            string[,] aParams = new string[,] { { "string", string_ }, { "timeout", timeout }, { "inFlash", inFlash.ToString() }, { "auto_change", auto_change.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            Thread.Sleep(1000);
            return res;
        }
        // �������� ���� ������� � �������, ���� ���� �� �����
        public bool send_key(string key, bool is_key = false, bool ctrl = false, bool alt = false, bool shift = false)
        {
            string[,] aParams = new string[,] { { "key", key }, { "is_key", is_key.ToString() }, { "ctrl", ctrl.ToString() }, { "alt", alt.ToString() }, { "shift", shift.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������� ������� � �������, ���� ���� �� �����
        public bool send_key_down(string key, bool is_key = false)
        {
            string[,] aParams = new string[,] { { "key", key }, { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������� ������� � �������, ���� ���� �� ����� 
        public bool send_key_up(string key, bool is_key = false)
        {
            string[,] aParams = new string[,] { { "key", key }, { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� ������� ��� ������� CTRL
        public bool set_ctrl_prefix(bool on)
        {
            string[,] aParams = new string[,] { { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� ������� ��� ������� ALT
        public bool set_alt_prefix(bool on)
        {
            string[,] aParams = new string[,] { { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� ������� ��� ������� SHIFT 
        public bool set_shift_prefix(bool on)
        {
            string[,] aParams = new string[,] { { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� ������� ������ CAPS LOCK
        public bool press_caps_lock()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // ���������� ������� ������ NUM LOCK
        public bool press_num_lock()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // ���������� ������� ������ SCROLL LOCK
        public bool press_scroll_lock()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        // ��������� ������� ������ CAPS LOCK
        public bool is_caps_lock_pressed()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // ��������� ������� ������ NUM LOCK
        public bool is_num_lock_pressed()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // ��������� ������� ������ SCROLL LOCK
        public bool is_scroll_lock_pressed()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ������� ���� �����
        public string get_current_language()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // ������ ������� ���� �����
        public bool set_current_language(string language)
        {
            string[,] aParams = new string[,] { { "language", language } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}