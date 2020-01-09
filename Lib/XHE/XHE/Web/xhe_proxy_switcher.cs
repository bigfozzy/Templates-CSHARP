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
    /////////////////////////////////////////// ProxySwitcher ////////////////////////////////////////////////////
    public class XHEProxySwitcher : XHEBaseObject
    {
        //////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEProxySwitcher(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "ProxySwitcher";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        // инициализировать
        public bool init(string folder)
        {
            string[,] aParams = new string[,] { { "folder", folder } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // очистить
        public bool clear()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // добавить прокси
        public bool add_proxies(string proxies)
        {
            string[,] aParams = new string[,] { { "proxies", proxies } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // добавить прокси из файла
        public bool add_proxies_from_file(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // добавить прокси из урл
        public bool add_proxies_from_url(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать случыный режим ротации
        public bool set_random_rotate_mode(bool mode)
        {
            string[,] aParams = new string[,] { { "mode", mode.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////

        // обновить прокси
        public bool update()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать путь обновления
        public bool set_update_path(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать урл обновления
        public bool set_update_url(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать период обновления
        public bool set_update_period(int minutes)
        {
            string[,] aParams = new string[,] { { "minutes", minutes.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать миниимальное количество проксей для обновления
        public bool set_update_proxy_count(int count)
        {
            string[,] aParams = new string[,] { { "count", count.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // получить следующий прокси
        public string get_next_proxy(bool delete=false)
        {
            string[,] aParams = new string[,] { { "delete", delete.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить все прокси
        public string get_all_proxies()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить число прокси
        public int get_proxy_count()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}