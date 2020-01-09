using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.Threading;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////////////// Interface //////////////////////////////////////////////
    public class XHEWindowInterface : XHEBaseInterface
    {
	    /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////
	    // server initialization
	    public XHEWindowInterface(string inner_number,string server,string password=""):base(server,password)
	    {    
		    this.inner_number = inner_number;
		    m_Server = server;
		    m_Password = password;
		    m_Prefix = "WindowInterface";
	    }
        // деструктор
  	    ~XHEWindowInterface() 
	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	    }	
	    // клонировать интерфейс 
        public override XHEBaseInterface get_clone_() 
	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string clone_inner_number=call_get("get_clone", aParams);

		    return new XHEWindowInterface(clone_inner_number,m_Server,m_Password);
	    }
        // клонировать интерфейс к Window
        protected XHEWindowInterface get_clone()
        {
            return (XHEWindowInterface)get_clone_();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // задать текст
        public bool set_text(string text)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "text", text} };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // задать видимость
        public bool show(bool on = true)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // изменить доступность
        public bool enable(bool on)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "on", on.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // задать фокус
        public bool focus()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // в самый верх 
        public bool foreground()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // минимизирвоать
        public bool minimize()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // максимизировать
        public bool maximize()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // восстановить
        public bool restore()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // закрыть
        public bool close()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // передвинуть
        public bool move(int x = -1, int y = -1)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "x", x.ToString() } , { "y", y.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // изменить размер
        public bool resize(int width = -1, int height = -1)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "width", width.ToString() }, { "height", height.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // послать сообщение
        public int message(int type, int wparam, int lparam)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "type", type.ToString() } , { "wparam", wparam.ToString() } , { "lparam", lparam.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // скриншот
        public bool screenshot(string filepath, int x = -1, int y = -1, int width = -1, int height = -1, bool as_gray = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "filepath", filepath }, { "x", x.ToString() }, { "y", y.ToString() }, { "width", width.ToString() }, { "height", height.ToString() }, { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // получить число дочерних окон
        public int get_child_count()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить дочернее по номеру
        public XHEWindowInterface get_child_by_number(int number)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "number", number.ToString() }};
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить дочернее по тексту
        public XHEWindowInterface get_child_by_text(string text, bool exactly = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "text", text } , { "exactly", exactly.ToString() }};
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить дочернее по имени классу
        public XHEWindowInterface get_child_by_class(string class_name, bool exactly = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "class_name", class_name } , { "exactly", exactly.ToString() }};
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить слудующее
        public XHEWindowInterface get_next()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить предыдущее
        public XHEWindowInterface get_prev()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить родительское
        public XHEWindowInterface get_parent()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить владельца
        public XHEWindowInterface get_owner()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить список интерфейсов всех дочерних окон
        public XHEWindowInterfaces get_all_child()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterfaces(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить список интерфейсов всех следующих окон
        public XHEWindowInterfaces get_all_next()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_numbers=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterfaces(new_internal_numbers,m_Server,m_Password);
   	    }   
	    // получить список интерфейсов всех предыдущих окон
        public XHEWindowInterfaces get_all_prev()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_numbers=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterfaces(new_internal_numbers,m_Server,m_Password);
   	    }   
	    // получить список интерфейсов всех родительских окон
        public XHEWindowInterfaces get_all_parent()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_numbers=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterfaces(new_internal_numbers,m_Server,m_Password);
   	    }   
	    // получить наивысшего родителя
        public XHEWindowInterface get_top_parent()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   
	    // получить наивысшего владельца
        public XHEWindowInterface get_top_owner()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string new_internal_number=call_get(MethodBase.GetCurrentMethod().Name, aParams);
	
		    return new XHEWindowInterface(new_internal_number,m_Server,m_Password);
   	    }   

	    // получить текст
        public string get_text()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить номер
        public int get_number(bool visibled = true, bool mained = true)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "visibled", visibled.ToString() } ,{ "mained", mained.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить стиль (простой или расширенный)
        public string get_style(bool extended = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "extended", extended.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить имя класса
        public string get_class_name()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить дескриптор HWND
        public string get_hwnd()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить ID процесса
        public string get_process_id()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить ID потока
        public string get_thread_id()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // получить X
        public int get_x()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить Y
        public int get_y()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить ширину
        public int get_width()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // получить высоту
        public int get_height()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // существует ли
        public bool is_exist()
   	    {
            return (inner_number != "-1" && inner_number != "");
   	    }   
	    // видимо ли
        public bool is_visible()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // доступно ли
        public bool is_enable()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // есть ли фокус ввода
        public bool is_focus()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // есть ли пользовательский фокус ввода
        public bool is_foreground()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // дочернее ли
        public bool is_child()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // минимизировано ли
        public bool is_minimize()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // максимизировано ли
        public bool is_maximize()
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }

        // послать перемещение мышью
        public bool send_mouse_move(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать щелчок мышью
        public bool send_mouse_click(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать двойной щелчок мышью
        public bool send_mouse_double_click(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать нажатие левой кнопки мыши
        public bool send_mouse_left_down(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать отжатие левой кнопки мыши
        public bool send_mouse_left_up(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }

        // послать щелчок правой кнопки мыши
        public bool send_mouse_right_click(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать нажатие правой кнопки мыши
        public bool send_mouse_right_down(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
        // послать отжатие правой кнопки мыши
        public bool send_mouse_right_up(int dx=0,int dy=0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }

	    // перемещение мышью
        public bool mouse_move(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // щелчок мышью
        public bool mouse_click(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // двойной щелчок мышью
        public bool mouse_double_click(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // нажатие левой кнопки мыши
        public bool mouse_left_down(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // отжатие левой кнопки мыши
        public bool mouse_left_up(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    // щелчок правой кнопки мыши
        public bool mouse_right_click(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // нажатие правой кнопки мыши
        public bool mouse_right_down(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // отжатие правой кнопки мыши
        public bool mouse_right_up(int dx = 0, int dy = 0)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "dx", dx.ToString() } , { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   

	    /*// посылает ввод строки в браузер, даже если он скрыт
   	    function send_input($string,$timeout=INPUT_TIME,$inFlash=false)
   	    {
		    global $PHP_Use_Trought_Shell;

		    $params = array( "inner_number" => inner_number , "string" => $string , "timeout" => $timeout , "inFlash" => $inFlash );
		    $res=call_boolean(__FUNCTION__,$params);
		
		    if ($PHP_Use_Trought_Shell)
			    fgets(STDIN);

		    sleep(1);
		    return $res;
   	    }
	    // посылает ввод клавиши в браузер, даже если он скрыт
   	    function send_key($key,$is_key=false)
   	    {
		    $params = array( "inner_number" => inner_number , "key" => $key , "is_key" => $is_key);
		    return call_boolean(__FUNCTION__,$params);
   	    }
   	    */

	    // посылает нажатие клавиши
        public bool send_key_down(string key, bool is_key = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "key", key } , { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
	    // посылает отжатие клавиши
        public bool send_key_up(string key, bool is_key = false)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "key", key } , { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }

	    // эммулирует ввод всех символов из переданной функции строки
        public bool input(string string_, int timeout=100)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "string", string_ } , { "timeout", timeout.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

		    Thread.Sleep(1000);
		    return res;
   	    }
	    // эммулирует ввод одной кнопки по ее скан коду
        public bool key(int code)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // эммулирует ввод одной кнопки по ее скан коду (deprecated)
        public bool press_key_by_code(int code)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
	    // эмулирует нажатие клавиши
        public bool key_down(string key)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
	    // эмулирует отжатие клавиши
        public bool key_up(string key)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	    }
	    // эммулирует задание языка ввода
        public string set_current_language(string language)
   	    {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "language", language } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
   	    }   
    };		
}