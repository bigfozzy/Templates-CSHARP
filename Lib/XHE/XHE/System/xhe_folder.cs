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
    ///////////////////////////////////////////////// Folder ////////////////////////////////////////////////////
    public class XHEFolder : XHEBaseObject
    {
        /////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHEFolder(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Folder";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������� �������
        public bool create(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ����������� �����
        public bool copy(string path, string new_folder_place, bool flag_fail_exist = true, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_folder_place", new_folder_place }, { "flag_fail_exist", flag_fail_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // ������� �����
        public bool move(string path, string new_folder_place, int timeout=60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_folder_place", new_folder_place } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // �������������� �����
        public bool rename(string path, string new_folder_name, int timeout=60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_folder_name", new_folder_name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // ��������
        public bool delete(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� �����������
        public bool clear(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� (�� ������� ������ ���� Rar)
        public bool rar(string path, string path_to_rar = "", string options = "u -m5 -mdE -s -r -ed -ep1")
        {
            string[,] aParams = new string[,] { { "path", path }, { "path_to_rar", path_to_rar }, { "options", options } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ������������� �����
        public bool is_exist(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��� �����
        public string get_name(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� ����� �����
        public string get_disk(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ������ �����
        public int get_size(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���������� ��������� � �����
        public int get_items_count(string path, bool include_subfolders = false, bool only_folders = false, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "include_subfolders", include_subfolders.ToString() }, { "only_folders", only_folders.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // �������� ��� �������� �� ����� 
        public string get_all_items(string path, bool include_subfolders = false, bool only_folders = false, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "include_subfolders", include_subfolders.ToString() }, { "only_folders", only_folders.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }
        // �������� ��������� ���� ����� � �����
        public string get_random_file(string path, string extension = "txt", bool include_subfolders = false, int timeout = 60)
        {
            string[,] aParams = new string[,] { { "path", path }, { "extension", extension }, { "include_subfolders", include_subfolders.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���� ��������
        public string get_creation_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ���������� ���������
        public string get_modification_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ���������� �������
        public string get_lastacess_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ���� �� ������� NORMAL
        public bool is_normal(string path)
        {
            string attr = "NORMAL";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���� �� ������� READONLY
        public bool is_readonly(string path)
        {
            string attr = "READONLY";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���� �� ������� HIDDEN
        public bool is_hidden(string path)
        {
            string attr = "HIDDEN";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���� �� ������� SYSTEM
        public bool is_system(string path)
        {
            string attr = "SYSTEM";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ���� �� ������� ARCHIVE 
        public bool is_archive(string path)
        {
            string attr = "ARCHIVE";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������ ������� NORMAL
        public bool set_normal(string path, bool on = true)
        {
            string attr = "NORMAL";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ������� READONLY
        public bool set_readonly(string path, bool on = true)
        {
            string attr = "READONLY";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ������� HIDDEN
        public bool set_hidden(string path, bool on = true)
        {
            string attr = "HIDDEN";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ������� SYSTEM
        public bool set_system(string path, bool on = true)
        {
            string attr = "SYSTEM";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������ ������� ARCHIVE 
        public bool set_archive(string path, bool on = true)
        {
            string attr = "ARCHIVE";
            string[,] aParams = new string[,] { { "path", path }, { "attr", attr }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}