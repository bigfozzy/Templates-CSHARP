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
        // конструктор
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

        // копировать файл
        public bool copy(string path, string new_path, bool fail_if_exist = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path }, { "fail_if_exist", fail_if_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // переместить файл
        public bool move(string path, string new_path, bool fail_if_exist = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path }, { "fail_if_exist", fail_if_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // переименовать файл
        public bool rename(string path, string new_path)
        {
            string[,] aParams = new string[,] { { "path", path }, { "new_path", new_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить файл
        public bool delete(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверка существования файла
        public bool is_exist(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить имя файла (без пути к файлу)
        public string get_name(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить заголовок файла (имя файла, без расширения)
        public string get_title(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить расширение файла
        public string get_ext(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить папку файла
        public string get_folder(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить имя диска, на котором находится файл
        public string get_disk(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить размер файла
        public int get_size(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить содержимое случайного файла в заданной папке
        public string get_random_file_content(string folder, string extension, bool include_subfolders, int timeout/*=COMMAND_TIME*/)
        {
            string[,] aParams = new string[,] { { "folder", folder }, { "extension", extension }, { "include_subfolders", include_subfolders.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams, timeout);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить дату создания файла
        public string get_creation_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить дату последнего изменения файла
        public string get_modification_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить дату последнего доступа к файлу
        public string get_lastacess_date(string path, bool time = false)
        {
            string[,] aParams = new string[,] { { "path", path }, { "time", time.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить что файл имеет атрибут NORMAL
        public bool is_normal(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить что файл имеет атрибут READONLY
        public bool is_readonly(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить что файл имеет атрибут HIDDEN
        public bool is_hidden(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить что файл имеет атрибут SYSTEM
        public bool is_system(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверить что файл имеет атрибут ARCHIVE 
        public bool is_archive(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // установить у файла атрибут NORMAL
        public bool set_normal(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // установить у файла атрибут READONLY
        public bool set_readonly(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // установить у файла атрибут HIDDEN
        public bool set_hidden(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // установить у файла атрибут SYSTEM
        public bool set_system(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // установить у файла атрибут ARCHIVE
        public bool set_archive(string path, bool on = true)
        {
            string[,] aParams = new string[,] { { "path", path }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}