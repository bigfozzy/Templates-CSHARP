using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System;
using XHE;using System.Reflection;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////// Window ////////////////////////////////////////////////////////
    public class XHEWindow : XHEBaseObject
    {
        ////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////////
        // server initialization
        public XHEWindow(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Window";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить количество окон заданного типа
        public int get_count(bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить тексты всех окон заданного типа
        public string get_all_texts(bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст окна заданного типа по его номеру
        public string get_text_by_number(int number, bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить номер окна заданного типа по его тексту
        public int get_number_by_text(string text, bool exactly = false, bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить количество дочерних окон у окна заданного типа по его номеру
        public int get_child_count_by_number(int number, bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить тексты всех дочерних окон у окна с заданным типом по его номеру
        public string get_child_texts_by_number(int number, bool visibled = true, bool mained = true)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать текст в полее ввода текста дочернего окна хумана и нажать OK
        public bool execute_open_file(string text, string path, string btn_text, bool exactly = true, bool thread = false)
        {
            string[,] aParams = new string[,] { { "text", text }, { "btn_text", btn_text }, { "path", path }, { "exactly", exactly.ToString() }, { "thread", thread.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // нажимать кнопку 'Сохранить' в диалоге загрузки файла при появлении этого диалога
        public bool execute_download_file()
        { 
            return call_boolean(MethodBase.GetCurrentMethod().Name, null);
        }
        // эмулировать выполнение диалога prompt при появлении этого диалога
        public bool execute_prompt(string caption, string text = "", string btn_text = "OK", bool exactly = true)
        {
            string[,] aParams = new string[,] { { "caption", caption }, { "text", text }, { "btn_text", btn_text }, { "exactly", exactly.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // эмулировать выполнение диалога авторизации при появлении этого диалога
        public bool execute_authorization(string login, string password = "", string caption = "Безопасность Windows")
        {
            string[,] aParams = new string[,] { { "login", login }, { "password", password }, { "caption", caption } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // эмулировать выполнение диалога печати при появлении этого диалога
        public bool execute_print(string path)
        {
            string[,] aParams = new string[,] { { "path", path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить интерфейс окна по номеру окна
        public XHEWindowInterface get_by_number(int number, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }
        // получить интерфейс окна по его тексту (заголовку)
        public XHEWindowInterface get_by_text(string text, bool exactly = false, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }
        // получить интерфейс окна по его имени класса
        public XHEWindowInterface get_by_class(string class_name, bool exactly = false, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "class_name", class_name }, { "exactly", exactly.ToString() }, { "visibled", visibled.ToString() }, { "mained", mained.ToString() } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }
        // получить интерфейс окна по его точке
        public XHEWindowInterface get_by_point(int x, int y)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }

        // получить интерфейс окна где активен ввод пользователя
        public XHEWindowInterface get_foreground_window()
        {
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, null);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }
        // получить интерфейс окна с фокусом
        public XHEWindowInterface get_focused_window()
        {
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, null);

            return new XHEWindowInterface(internal_number, m_Server, m_Password);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить список интерфейсов всех окон заданного типа
        public XHEWindowInterfaces get_all(bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "mained", mained.ToString() }, { "visibled", visibled.ToString() } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterfaces(internal_numbers, m_Server, m_Password);
        }
        // получить список интерфейсов окон по номерам 
        public XHEWindowInterfaces get_all_by_number(string numbers, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "numbers", numbers }, { "mained", mained.ToString() }, { "visibled", visibled.ToString() } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterfaces(internal_numbers, m_Server, m_Password);
        }
        // получить список интерфейсов окон по их текстам (заголовкам)
        public XHEWindowInterfaces get_all_by_text(string text, bool exactly = false, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "mained", mained.ToString() }, { "visibled", visibled.ToString() } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterfaces(internal_numbers, m_Server, m_Password);
        }
        // получить список интерфейсов окон по их именам классов
        public XHEWindowInterfaces get_all_by_class(string class_name, bool exactly = false, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "class_name", class_name }, { "exactly", exactly.ToString() }, { "mained", mained.ToString() }, { "visibled", visibled.ToString() } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterfaces(internal_numbers, m_Server, m_Password);
        }
        // получить список интерфейсов окон в заданной точке
        public XHEWindowInterfaces get_all_by_point(int x, int y, bool mained = true, bool visibled = true)
        {
            string[,] aParams = new string[,] { { "x", x.ToString() }, { "y", y.ToString() }, { "mained", mained.ToString() }, { "visibled", visibled.ToString() } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEWindowInterfaces(internal_numbers, m_Server, m_Password);
        }
    };
}