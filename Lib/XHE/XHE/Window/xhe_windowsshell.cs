using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////// Windows ///////////////////////////////////////////////////////
    public class XHEWindowsShell : XHEBaseObject
    {
        ////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////////
        // server initialization
        public XHEWindowsShell(string server, string password, XHEScriptBase script) : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "WindowsShell";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить ширину экрана
        public int get_screen_width()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить высоту экрана
        public int get_screen_height()
        {
            return call_int(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать разрешение экрана
        public bool set_screen_resolution(int width, int height)
        {
            string[,] aParams = new string[,] { { "width", width.ToString() }, { "height", height.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // сохранить скриншот заданной части экрана в файл-картинку
        public bool screenshot(string path, int x = -1, int y = -1, int width = -1, int height = -1, bool as_gray = false, int screen = 0)
        {
            string[,] aParams = new string[,] { { "path", path }, { "x", x.ToString() }, { "y", y.ToString() }, { "width", width.ToString() }, { "height", height.ToString() }, { "as_gray", as_gray.ToString() }, { "screen", screen.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить название Windows
        public string get_windows_title()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить версию Windows
        public string get_windows_version()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить билд Windows
        public string get_windows_build()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить ID платформы Windows
        public string get_windows_platform_id()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить информацию о Windows SP
        public string get_windows_sp_info()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить имя компьютера
        public string get_computer_name()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить имя пользователя
        public string get_user_name()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // получить имя процессора
        public string get_cpu_name()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить системную дату
        public string get_system_date()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать системную дату
        public bool set_system_date(int year, int month, int day)
        {
            string[,] aParams = new string[,] { { "year", year.ToString() }, { "month", month.ToString() }, { "day", day.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить системное время
        public string get_system_time()
        {
            return call_get(MethodBase.GetCurrentMethod().Name, null);
        }
        // задать системное время
        public bool set_system_time(int hour, int minute, int second)
        {
            string[,] aParams = new string[,] { { "hour", hour.ToString() }, { "minute", minute.ToString() }, { "second", second.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать период синхронизации системного времени
        public bool set_system_time_synchro_period(int seconds)
        {
            string[,] aParams = new string[,] { { "seconds", seconds.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить системную дату
        public long get_disk_free_space(string disk)
        {
            string[,] aParams = new string[,] { { "disk", disk } };
            return call_long(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

	// начать запись видео части экрана
	public bool start_video_record(string path, int fps = 10, int quality = 70, int x = -1, int y = -1, int width = -1, int height = -1, bool as_gray = false)	
	{
		string[,] aParams = new string[,] { { "path" , path } , { "fps" , fps.ToString() } , { "quality" , quality.ToString() } , { "x" , x.ToString() } , { "y" , y.ToString() } , { "width" , width.ToString() } , { "height" , height.ToString() } , { "as_gray" , as_gray.ToString() } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
	// остановить запись видео части экрана
	public bool stop_video_record()	
	{
		return call_boolean(MethodBase.GetCurrentMethod().Name, null);
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////

    };
}