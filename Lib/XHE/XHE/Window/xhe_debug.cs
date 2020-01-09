using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////////////// Debug /////////////////////////////////////////////////
    public class XHEDebug : XHEBaseObject
    {
        ////////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        public XHEDebug(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Debug";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // открыть отладочную закладку
        public bool open_tab(string page)
        {
            string[,] aParams = new string[,] { { "page", page } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить текст в отладочную закладку
        public bool set_tab_content(string page, string text)
        {
            string[,] aParams = new string[,] { { "page", page }, { "text", text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сохранить содержимое отладочной закладки в файл
        public bool save_tab_content_to_file(string page, string filepath, bool add = false)
        {
            string[,] aParams = new string[,] { { "page", page }, { "filepath", filepath }, { "add", add.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить содержимое отладочной закладки
        public string get_tab_content(string page)
        {
            string[,] aParams = new string[,] { { "page", page } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // очистить текст в отладочной закладке
        public bool clear_tab_content(string page)
        {
            string[,] aParams = new string[,] { { "page", page } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // закрыть отладочную закладку
        public bool close_tab(string page)
        {
            string[,] aParams = new string[,] { { "page", page } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать кодировку отладочной закладки
        public bool set_encoding(string page, string charset)
        {
            string[,] aParams = new string[,] { { "page", page }, { "charset", charset } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать режим отображения отладочной закладки
        public bool view_tab_as_text(string page, bool as_text = true)
        {
            string[,] aParams = new string[,] { { "page", page }, { "as_text", as_text.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // закрыть все отладочные закладки
        public bool close_tabs()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // вывести диалоговое сообщение 
        public bool message_box(string text)
        {
            string[,] aParams = new string[,] { { "text", text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // вывести сообщение - уведомление
        public bool notification_box(string rtf_text, int show_time = 9999)
        {
            string[,] aParams = new string[,] { { "rtf_text", rtf_text }, { "show_time", show_time.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить минимальный размер памяти, которую занимала программа в процессе работы
        public Int64 get_min_mem_size()
        {
            return Convert.ToInt64(call_get(MethodBase.GetCurrentMethod().Name, null));
        }
        // получить максимальный размер памяти, которую занимала программа в процессе работы
        public Int64 get_max_mem_size()
        {
            return Convert.ToInt64(call_get(MethodBase.GetCurrentMethod().Name, null));
        }

        // получить текущий размер памяти, занимаемый программой
        public Int64 get_cur_mem_size()
        {
            return Convert.ToInt64(call_get(MethodBase.GetCurrentMethod().Name, null));
        }
        // получить размер свободной физической памяти
        public Int64 get_free_physical_mem_size()
        {
            return Convert.ToInt64(call_get(MethodBase.GetCurrentMethod().Name, null));
        }
        // оптимизировать размер памяти, занимаемый программой
        public bool optimize_memory()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить число ресурсов, использованных хуманом (0 - GDI, 1 - USER ,  2 - бывший максимум GDI , 4 - бывший максимум USER )
        public int get_gui_resources(int type)
        {
            string[,] aParams = new string[,] { { "type", type.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

	// получить id процесса хумана
        public int get_process_id()
        {
            return Convert.ToInt32(call_get(MethodBase.GetCurrentMethod().Name, null));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать хук на отладочные действия
        public bool set_hook(string action, string php_script)
        {
            string[,] aParams = new string[,] { { "action", action }, { "php_script", php_script } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить путь к текущему скрипту
        public string get_cur_script_path()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить путь к папке в котрой находится текущий скрипт
        public string get_cur_script_folder()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // проверить, выполняется ли сейчас скрипт
        public bool is_script_run()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // запустить текущий скрипт на выполнение
        public bool run_current_script(string params_)
	    {
            string[,] aParams = new string[,] { { "params", params_} };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}