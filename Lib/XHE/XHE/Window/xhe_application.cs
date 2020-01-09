using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////////////// App /////////////////////////////////////////////////
    public class XHEApplication : XHEBaseObject
    {
        //////////////////////////////////// SERVICE VARIABLES ///////////////////////////////////////////
        // enable exit
        public bool enable_exit = true;
        //////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////
        // server initialization
        public XHEApplication(string server, string password , XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            enable_exit = true;
            m_Prefix = "Application";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////

        // получить ответ на вопрос через диалог
        public string dlg_question(string message)
        {
            string[,] aParams = new string[,] { { "message", message } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // получить строку из диалога
        public string get_dlg_input_string(string dlg_name, string dlg_text, string default_answer = "")
        {
            string[,] aParams = new string[,] { { "dlg_name", dlg_name }, { "dlg_text", dlg_text }, { "default_answer", default_answer } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // получить путь к файлу через диалог
        public string get_dlg_select_file(string path, string action)
        {
            string[,] aParams = new string[,] { { "path", path }, { "action", action } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // получить путь к папке через диалог
        public string get_dlg_select_folder(string path, string caption, string action)
        {
            string[,] aParams = new string[,] { { "path", path }, { "caption", caption }, { "action", action } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // вызвать произвольный диалог на основе xml
        public string show_free_dlg(string xml, bool is_ret_xml = true, string separator = "\r\n")
        {
            string[,] aParams = new string[,] { { "xml", xml }, { "is_ret_xml", is_ret_xml.ToString() }, { "separator", separator } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // вывести капчу в диалог из заданного номера картинки и получить ее значение
        public string dlg_captcha_from_image_number(int number, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // вывести капчу в диалог из заданного урла картинки и получить ее значение
        public string dlg_captcha_from_url(string url)
        {
            string[,] aParams = new string[,] { { "url", url } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }
        // вывести капчу в диалог из заданного урла или его части картинки и получить ее значение
        public string dlg_captcha_from_url_exactly(string url, bool exactly = true, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "url", url }, { "exactly", exactly.ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams, 99999);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            return res;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // задать расположение программы на рабочем столе
        public bool set_window_position(int x, int y, int width, int height)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "width", width.ToString() }, { "height", height.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать заголовок программы
        public bool set_title(string title)
        {
            string[,] aParams = new string[,] { { "title", title } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // инициировать мигание иконки программы в панели задач
        public bool set_blink(bool blink)
        {
            string[,] aParams = new string[,] { { "blink", blink.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать или спрятать левую панель
        public bool show_left_pane(bool show)
        {
            string[,] aParams = new string[,] { { "show", show.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать или спрятать нижнюю панель
        public bool show_bottom_pane(bool show)
        {
            string[,] aParams = new string[,] { { "show", show.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // перейти в полноэкранный режим
        public bool enable_full_screen(bool enable)
        {
            string[,] aParams = new string[,] { { "enable", enable.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // минимизировать программу в трей
        public bool minimize_to_tray()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // инимизировать программу в трей при старте
        public bool minimize_to_tray_by_start(bool minimize=true)
        {
            string[,] aParams = new string[,] { { "minimize", minimize.ToString() } };	
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // показать программу из трея
        public bool show_from_tray()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // максимизировать окно хумана
        public bool maximize()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // показать иконку в трее
        public bool show_tray_icon(bool show)
        {
            string[,] aParams = new string[,] { { "show", show.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать иконку в трее
        public bool set_tray_icon(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать всплывающую подсказку в трее
        public bool set_tray_tooltip(string tooltip)
        {
            string[,] aParams = new string[,] { { "tooltip", tooltip } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // вытащить окно программы наверх
        public bool set_foreground_window()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // сделать чтобы окно программы показывалось поверх всех окон
        public bool set_always_on_top(bool ontop)
        {
            string[,] aParams = new string[,] { { "ontop", ontop.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
	// получить тип курсора
	public string get_cursor_type(int x=-1,int y=-1)
	{
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	}

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // приостановить выполнени скрипта на заданное время (в минутах, если 0 - то бесконечно)
        public bool pause(int timeout = 0)
        {
            bool res = false;
            if (timeout == 0)
            {
                string[,] aParams = new string[,] { { "timeout", timeout.ToString() } };
                res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                
                if (CSHARP_Use_Trought_Shell)
                    Console.ReadLine();
            }
            else
            {
                res = true;
                Thread.Sleep(timeout);
            }

            return res;
        }
        // выйти из программы
        public bool exitapp()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // перезапустить программу
        public bool restart(string scriptpath = "", string params_ = "", string port = "", string cache_folder = "", string cookies_folder = "",int pause_before_start_s=0)
        {
            string[,] aParams = new string[,] { { "scriptpath", scriptpath }, { "params", params_ }, { "port", port }, { "cache_folder", cache_folder }, { "cookies_folder", cookies_folder }, { "pause_before_start_s", pause_before_start_s.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            // die
            /*if (System.Windows.Forms.Application.MessageLoop)
                System.Windows.Forms.Application.Exit();
            else*/
                Environment.Exit(1);

            return res;
        }
        // очистить папки портов и темп с логами
        public bool clear()
        {
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);
	        GetBrowser().clear_cookies("",true,true);
	        return res;
        }
        // остановить выполнение скрипта
        public bool quit()
        {
            Thread.Sleep(1000);
            if (enable_exit)
            {
                bool res = call_boolean(MethodBase.GetCurrentMethod().Name, null);

                Console.WriteLine("\nXWeb@exit");
                // die
                /*if (System.Windows.Forms.Application.MessageLoop)
                    System.Windows.Forms.Application.Exit();
                else*/
                    Environment.Exit(1);

                return res;
            }

            return false;
        }
        // зпдпть возможность остановки выполнения скрипта командой quit
        public bool enable_quit(bool enable_exit)
        {
            this.enable_exit = enable_exit;
            return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // получить порт на котором запущена программа
        public string get_port()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить ID инсталяции
        public string get_install_id()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить версию программы
        public string get_version(bool extended)
        {
            string[,] aParams = new string[,] { { "extended", extended.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        // получить путь к программе
        public string get_program_path()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить папку программы
        public string get_program_folder()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // получить содержимое файла с компьютера на котором запущен хуман эмулятор
        public string get_file_from_disk(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

	//////////////////////////////////////////////////////////////////////////////////////////////////

	// задать параметры поиска DOM объектов
   	public bool set_params_object_search(bool regsense=false)
   	{
            string[,] aParams = new string[,] { { "regsense", regsense.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
	// задать параметры того что будет делать хуман при переполнении памяти
   	public bool set_params_outofmemory_action(int restart_type=0)
   	{
            string[,] aParams = new string[,] { { "restart_type", restart_type.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}   
	// установить во все диалоги галочку - не спрашивать снова (выдавать OK,Yes)
   	public bool set_dont_ask_me_again_mode(bool mode=true)
   	{
            string[,] aParams = new string[,] { { "mode", mode.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}   
	// задать кодировку скрипта как юникод
   	public bool set_script_as_unicode(bool is_unicode = true)
   	{
            string[,] aParams = new string[,] { { "is_unicode", is_unicode.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}   

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // выполнить скрипт по заданному пути
        public string run_script(string path, string params_ = "")
        {
            string[,] aParams = new string[,] { { "path", path }, { "params_", params_ } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить содержимое, как bat-файл по заданному пути
        public bool run_as_bat(string content, string path, bool show = false)
        {
            string[,] aParams = new string[,] { { "content", content }, { "path", path }, { "show", show.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить содержимое, как php-файл по заданному пути
        public string run_as_php(string content, string path, bool show = false, string params_ = "")
        {
            string[,] aParams = new string[,] { { "content", content }, { "path", path }, { "show", show.ToString() }, { "params", params_ } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выполнить внешнюю программу по заданному пути
        public string shell_execute(string operat, string file, string param = "", string dir = "", int show = 1)
        {
            string[,] aParams = new string[,] { { "operat", operat }, { "file", file }, { "param", param }, { "dir", dir }, { "show", show.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // завершить процесс с заданным именем
        public bool kill_process(string exe_name)
        {
            string[,] aParams = new string[,] { { "exe_name", exe_name } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        // показать прогресс бар в строке статуса
        public bool show_progress_bar(bool show)
        {
            string[,] aParams = new string[,] { { "show", show.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать диапазон прогресс бара
        public bool set_progress_range(int min, int max, int step = 1)
        {
            string[,] aParams = new string[,] { { "min", min.ToString() }, { "max", max.ToString() }, { "step", step.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать позицию прогресс бара
        public bool set_progress_pos(int pos)
        {
            string[,] aParams = new string[,] { { "pos", pos.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // увеличить значение прогресс бара на 1 шаг
        public bool step_progress()
        {
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
    };
}