using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_Web
{
    ////////////////////////////////////////////// Ftp //////////////////////////////////////////////////////
    public class XHESFTP : XHEBaseObject
    {
        /////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
        // server initialization
        public XHESFTP(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "SFTP";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////

        // соединится с фтп сервером
        public bool connect(string server, string user = "", string password = "", int iport = 22, int timeout=-1)
        {
            string[,] aParams = new string[,] { { "server", server }, { "user", user }, { "password", password }, { "iport", iport.ToString() }, { "timeout", timeout.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отсоединится от фтп сервера
        public bool disconnect(string server)
        {
            string[,] aParams = new string[,] { { "server", server } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // отсоединится от всех подключеннных фтп серверов
        public bool disconnect_all()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        // создать папку на сервере
        public bool create_directory(string server, string dir_name)
        {
            string[,] aParams = new string[,] { { "server", server }, { "dir_name", dir_name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить папку с сервера
        public bool remove_directory(string server, string dir_name)
        {
            string[,] aParams = new string[,] { { "server", server }, { "dir_name", dir_name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        // получить файл с сервера
        public bool get_file(string server, string remote_file, string local_file, bool flag_fail_exist = true)
        {
            string[,] aParams = new string[,] { { "server", server }, { "remote_file", remote_file }, { "local_file", local_file }, { "flag_fail_exist", flag_fail_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // залить файл на сервер
        public bool put_file(string server, string local_file, string remote_file, bool flag_fail_exist = true)
        {
            string[,] aParams = new string[,] { { "server", server }, { "local_file", local_file }, { "remote_file", remote_file }, { "flag_fail_exist", flag_fail_exist.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // удалить файл с севрера
        public bool remove_file(string server, string file_name)
        {
            string[,] aParams = new string[,] { { "server", server }, { "file_name", file_name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
    };
}