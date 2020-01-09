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
    ///////////////////////////////////////////////// File_os ///////////////////////////////////////////////////
    public class XHEFile_os : XHEBaseObject
    {
        ////////////////////////////////// SERVICVE FUNCTIONS ///////////////////////////////////////////////
        // �����������
        public XHEFile_os(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "File";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� ����
        public bool copy(string path, string new_path, bool fail_if_exist = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path }, { "fail_if_exist", fail_if_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ����������� ����
        public bool move(string path, string new_path, bool fail_if_exist = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path }, { "fail_if_exist", fail_if_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������������� ����
        public bool rename(string path, string new_path)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ������� ����
        public bool delete(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ������������� �����
        public bool is_exist(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��� ����� (��� ���� � �����)
        public string get_name(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��������� ����� (��� �����, ��� ����������)
        public string get_title(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���������� �����
        public string get_ext(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ����� �����
        public string get_folder(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ��� �����, �� ������� ��������� ����
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
        // �������� ���������� ���������� ����� � �������� �����
        public string get_random_file_content(string folder, string extension, bool include_subfolders, int timeout/*=COMMAND_TIME*/)
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "extension", extension }, { "include_subfolders", include_subfolders.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���� �������� �����
        public string get_creation_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ���������� ��������� �����
        public string get_modification_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // �������� ���� ���������� ������� � �����
        public string get_lastacess_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ��� ���� ����� ������� NORMAL
        public bool is_normal(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ��� ���� ����� ������� READONLY
        public bool is_readonly(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ��� ���� ����� ������� HIDDEN
        public bool is_hidden(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ��� ���� ����� ������� SYSTEM
        public bool is_system(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ��������� ��� ���� ����� ������� ARCHIVE 
        public bool is_archive(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� � ����� ������� NORMAL
        public bool set_normal(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� � ����� ������� READONLY
        public bool set_readonly(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� � ����� ������� HIDDEN
        public bool set_hidden(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� � ����� ������� SYSTEM
        public bool set_system(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // ���������� � ����� ������� ARCHIVE
        public bool set_archive(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}