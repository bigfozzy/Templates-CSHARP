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
    /////////////////////////////////////////// Harvestor ////////////////////////////////////////////////////
    public class XHEHarvestor : XHEBaseObject
    {
        //////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEHarvestor(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Harvestor";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        // проверить запущено ли сейчас тестирование
        public bool init(string in_file,string proxy_file = "", bool proceed_js = true)
        {
            string[,] aParams = new string[,] { { "in_file", in_file } , { "proxy_file", proxy_file } , { "proceed_js", proceed_js.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
	// задать настройку - делать скриншоты
	public bool make_screenshots(bool enable = true)
	{
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
	// задать настройку - размер браузера
	public bool set_browser_size(int width,int height)
	{
            string[,] aParams = new string[,] { { "width", width.ToString() } , { "height", height.ToString() }  };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}

        ////////////////////////////////////////////////////////////////////////////////////////////

        // запустить тестирование
        public bool start(bool is_wait = false)
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);

            // ждать окончания тестирования
            while (is_wait && !is_finished())
                Thread.Sleep(10000);

            return res;
        }
        // остановить тестирование
        public bool stop()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        
        ////////////////////////////////////////////////////////////////////////////////////////////

        // добавить прокси в список
        public string get_html(int position)
        {
            string[,] aParams = new string[,] { { "position", position.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
	// получить путь к скриншоту
	public string get_screenshot_path(int position)
	{
            string[,] aParams = new string[,] { { "position", position.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // добавить прокси в список из файла
        public bool is_finished()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // убрать дубликаты из спсика прокси
        public int get_completed_count()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
    };
}