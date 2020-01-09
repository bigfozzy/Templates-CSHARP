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
    /////////////////////////////////////////// Raw ////////////////////////////////////////////////////
    public class XHEProxyCheker : XHEBaseObject
    {
        //////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEProxyCheker(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "ProxyCheker";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////

        // запустить тестирование
        public bool run(bool is_wait = false)
        {
            string[,] aParams = new string[,] { { "is_wait", is_wait.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            // ждать окончания тестирования
            while (is_wait && is_running())
                Thread.Sleep(10000);

            return res;
        }
        // остановить тестирование
        public bool stop()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        // проверить запущено ли сейчас тестирование
        public bool is_running()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        // задать скорость тестирования
        public bool set_speed_testing(int speed)
        {
            string[,] aParams = new string[,] { { "speed", speed.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать качество тестирования
        public bool set_quality_testing(int quality)
        {
            string[,] aParams = new string[,] { { "quality", quality.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // добавить прокси в список
        public bool add_proxy(string str_proxy)
        {
            string[,] aParams = new string[,] { { "str_proxy", str_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить прокси в список из файла
        public bool add_proxy_from_file(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить прокси из урла в список
        public bool add_proxy_from_url(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // удалить прокси заданного типа из списка
        public bool delete_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // sсохранить прокси заданного типа в файл
        public bool save_proxy(string path, string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "path", path }, { "param_proxy", param_proxy } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // убрать дубликаты из спсика прокси
        public bool dedupe_proxy()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // получить количество прокси заданного типа
        public int get_count_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить прокси заданного типа
        public string get_proxy(int n, string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "n", n.ToString() }, { "param_proxy", param_proxy } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить самый быстрый прокси заданного типа
        public string get_fastest_proxy(string param_proxy = "all")
        {
            string[,] aParams = new string[,] { { "param_proxy", param_proxy } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}