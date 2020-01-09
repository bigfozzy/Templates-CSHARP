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
    public class XHERaw : XHEBaseObject
    {
        //////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHERaw(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Raw";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////

        // включить логирование всех RAW потоков (http и https)
        public bool enable_all_streams(bool enable=true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить логирование RAW потока http
        public bool enable_http_stream(bool enable=true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // включить логирование RAW потока https
        public bool enable_https_stream(bool enable=true)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // сохранять информацию приходящую с сервера в окно RAW лога
        public bool save_server_log_to_window()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // сохранять информацию отдаваемую браузером в окно RAW лога
        public bool save_browser_log_to_window()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // сохранять информацию приходящую с сервера в заданный файл
        public bool save_server_log_to_file(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сохранять информацию отдаваемую браузером в заданный файл
        public bool save_browser_log_to_file(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // получить последний запрошенный урл по номеру в массиве последних запросов
        public string get_last_request_url(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний запрошенный заголовок по номеру в массиве последних запросов
        public string get_last_request_header(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // получить последний отвеченный урл по номеру в массиве последних ответов
        public string get_last_response_url(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний отвеченный буффер по номеру в массиве последних ответов
        public string get_last_response_buffer(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний отвеченный заголовок по номеру в массиве последних ответов
        public string get_last_response_header(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний урл редиректа по номеру в массиве последних ответов
        public string get_last_redirect_url(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний заголовок редиректа по номеру в массиве последних ответов
        public string get_last_redirect_header(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить последний прочитанный с сервера текст
        public string get_last_readed(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // задать число хранимых запросов в массивах
        public bool set_arrays_count(int num)
        {
            string[,] aParams = new string[,] { { "num", num.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // очистить массив последних запросов
        public bool clear_last_requests_array()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // очистить массив последних ответов
        public bool clear_last_responses_array()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        // задать хук на начало запроса информации браузером у севрера
        public bool set_hook_on_begin_transaction(string php_script_path)
        {
            string[,] aParams = new string[,] { { "php_script_path", php_script_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать хук на начало приема информации браузером от сервера
        public bool set_hook_on_response(string php_script_path)
        {
            string[,] aParams = new string[,] { { "php_script_path", php_script_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
     	// задать хук на загрузку контента в барузер
        public bool set_hook_on_readed(string php_script_path)
        {
            string[,] aParams = new string[,] { { "php_script_path", php_script_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

     	// задать хук на начало запроса информации браузером у севрера
	public bool add_disabled_request_url(string url,bool exactly=false)
	{
            string[,] aParams = new string[,] { { "url", url } , { "exactly", exactly.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
     	// задать хук на начало приема информации браузером от сервера
	public bool clear_disabled_request_urls_array()
	{
	    return call_boolean(MethodBase.GetCurrentMethod().Name, null);
	}
     	// задать хук на начало запроса информации браузером у севрера
	public bool add_disabled_response_url(string url,bool exactly=false)
	{
            string[,] aParams = new string[,] { { "url", url } , { "exactly", exactly.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
     	// задать хук на начало приема информации браузером от сервера
	public bool clear_disabled_response_urls_array()
	{
    	    return call_boolean(MethodBase.GetCurrentMethod().Name, null);
	}

     	// задать правило замены
	public bool add_replace_rule(string url, bool exactly_url, string find, string replace)
	{
            string[,] aParams = new string[,] { { "url", url } , { "exactly_url", exactly_url.ToString() } , { "find", find } , { "replace", replace } };
	    	return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
     	// очистить правила замены
	public bool clear_replace_rules(string url, bool exactly_url = false)
	{
            string[,] aParams = new string[,] { { "url", url } , { "exactly_url", exactly_url.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}


        ////////////////////////////////////////////////////////////////////////////////////////////

     	// задать дополнительный заголовок, котрый будет отправляться браузером при запросах
	public bool set_additional_request_header(string header="")
	{
            string[,] aParams = new string[,] { { "header", header }  };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}

        ////////////////////////////////////////////////////////////////////////////////////////////

    };
}