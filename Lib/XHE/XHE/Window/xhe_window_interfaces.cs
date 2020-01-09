using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;using System.Reflection;
using System.Threading;
using System.Collections.Generic;

namespace XHE.XHE_Window
{
    //////////////////////////////////////////////////// Interface //////////////////////////////////////////////
    public class XHEWindowInterfaces : XHEBaseList
    {
        /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////

        // server initialization
        public XHEWindowInterfaces(string inner_numbers, string server, string password = "")
            : base(inner_numbers, server, password)
	    {    
		    if (inner_numbers!="" && inner_numbers!="Ignore")
		    {
			    if (inner_numbers=="false")
				    return;			
			    string[] elms_nums=inner_numbers.Split(';');
			    for (int i=0;i<elms_nums.Length;i++) 
			    {
			         if (elms_nums[i].Trim()!="")
				         elements.Add(new XHEWindowInterface(elms_nums[i].Trim(),m_Server,m_Password));
			    }
		    }
	    }
        // получить элемент
        public XHEWindowInterface get(int index)
        {
            if (elements != null && index < elements.Count)
                return (XHEWindowInterface)elements[index];
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить интерфейс окна по его тексту
        public XHEWindowInterface get_by_text(string text, bool exactly = false)
        {
            int iNeedNum = -1;
            for (int i = 0; i < elements.Count; i++)
            {
                if (compare_string(exactly,((XHEWindowInterface)elements[i]).get_text(),text))
                {
                    iNeedNum=i;
                    break;
                }
            }

            // вернем элемент
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }
        // получить интерфейс окна по его классу
        public XHEWindowInterface get_by_class_name(string class_name_, bool exactly = false)
        {
            int iNeedNum = -1;            
            for (int i = 0; i < elements.Count; i++)
            {
                if (compare_string(exactly,((XHEWindowInterface)elements[i]).get_class_name(),class_name_))
                {
                    iNeedNum=i;
                    break;
                }
            }

            // вернем элемент
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }
        // получить интерфейс окна по его точке
        public XHEWindowInterface get_by_point(int x, int y)
        {
            int iNeedNum = -1;
            for (int i = 0; i < elements.Count; i++)
            {
                XHEWindowInterface window = (XHEWindowInterface)elements[i];
                int xw = window.get_x();
                if (x < xw)
                    continue;
                int yw = window.get_y();
                if (y < yw)
                    continue;
                int width = window.get_width();
                if (x > xw + width)
                    continue;
                int height = window.get_height();
                if (y > yw + height)
                    continue;
                iNeedNum = i;
                break;
            }

            // вернем элемент
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("",m_Server,m_Password);
        }

        ///////////////////////////////////////

        // задать текст
        public List<bool> set_text(string text)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.set_text(text));
            return res;
        }
        // задать видимость
        public List<bool> show(bool on = true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.show(on));
            return res;
        }
        // изменить доступность
        public List<bool> enable(bool on)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.enable(on));
            return res;
        }

        // задать фокус
        public List<bool> focus()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.focus());
            return res;
        }
        // в самый верх 
        public List<bool> foreground()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.foreground());
            return res;
        }
        // минимизирвоать
        public List<bool> minimize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.minimize());
            return res;
        }
        // максимизировать
        public List<bool> maximize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.maximize());
            return res;
        }
        // восстановить
        public List<bool> restore()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.restore());
            return res;
        }
        // закрыть
        public List<bool> close()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.close());
            return res;
        }

        // передвинуть
        public List<bool> move(int x = -1, int y = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.move(x,y));
            return res;
        }
        // изменить размер
        public List<bool> resize(int width = -1, int height = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.move(width, height));
            return res;
        }
        // послать сообщение
        public List<int> message(int type, int wparam, int lparam)
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.message(type, wparam, lparam));
            return res;
        }

        // скриншот
        public List<bool> screenshot(string filepath, int x = -1, int y = -1, int width = -1, int heigth = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.screenshot(filepath, x , y, width, heigth));
            return res;
        }

        // получить число дочерних окон
        public List<int> get_child_count()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_count());
            return res;
        }
        // получить дочернее по номеру
        public List<XHEWindowInterface> get_child_by_number(int number)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_number(number));
            return res;
        }
        // получить дочернее по тексту
        public List<XHEWindowInterface> get_child_by_text(string text, bool exactly = false)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_text(text, exactly));
            return res;
        }
        // получить дочернее по имени классу
        public List<XHEWindowInterface> get_child_by_class(string class_name, bool exactly = false)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_class(class_name, exactly));
            return res;
        }
        // получить слудующее
        public List<XHEWindowInterface> get_next()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_next());
            return res;
        }
        // получить предыдущее
        public List<XHEWindowInterface> get_prev()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_prev());
            return res;
        }
        // получить родительское
        public List<XHEWindowInterface> get_parent()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_parent());
            return res;
        }
        // получить владельца
        public List<XHEWindowInterface> get_owner()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_owner());
            return res;
        }
        // получить список интерфейсов всех дочерних окон
        public List<XHEWindowInterfaces> get_all_child()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_child());
            return res;
        }
        // получить список интерфейсов всех следующих окон
        public List<XHEWindowInterfaces> get_all_next()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_next());
            return res;
        }
        // получить список интерфейсов всех предыдущих окон
        public List<XHEWindowInterfaces> get_all_prev()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_prev());
            return res;
        }
        // получить список интерфейсов всех родительских окон
        public List<XHEWindowInterfaces> get_all_parent()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_parent());
            return res;
        }
        // получить наивысшего родителя
        public List<XHEWindowInterface> get_top_parent()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_top_parent());
            return res;
        }
        // получить наивысшего владельца
        public List<XHEWindowInterface> get_top_owner()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_top_owner());
            return res;
        }

        // получить текст
        public List<string> get_text()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_text());
            return res;
        }
        // получить номер
        public List<int> get_number(bool visibled = true, bool mained = true)
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_number(visibled, mained));
            return res;
        }
        // получить стиль (простой или расширенный)
        public List<string> get_style(bool extended = false)
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_style(extended));
            return res;
        }
        // получить имя класса
        public List<string> get_class_name()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_class_name());
            return res;
        }
        // получить дескриптор HWND
        public List<string> get_hwnd()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_hwnd());
            return res;
        }
        // получить ID процесса
        public List<string> get_process_id()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_process_id());
            return res;
        }
        // получить ID потока
        public List<string> get_thread_id()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_thread_id());
            return res;
        }

        // получить X
        public List<int> get_x()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_x());
            return res;
        }
        // получить Y
        public List<int> get_y()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_y());
            return res;
        }
        // получить ширину
        public List<int> get_width()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_width());
            return res;
        }
        // получить высоту
        public List<int> get_height()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_height());
            return res;
        }

        // существует ли
        public List<bool> is_exist()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_exist());
            return res;
        }
        // видимо ли
        public List<bool> is_visible()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_visible());
            return res;
        }
        // доступно ли
        public List<bool> is_enable()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_enable());
            return res;
        }
        // есть ли фокус ввода
        public List<bool> is_focus()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_focus());
            return res;
        }
        // дочернее ли
        public List<bool> is_child()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_child());
            return res;
        }
        // минимизировано ли
        public List<bool> is_minimize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_minimize());
            return res;
        }
        // максимизировано ли
        public List<bool> is_maximize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_maximize());
            return res;
        }

        /*// послать перемещение мышью
        function send_mouse_move($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   

        // послать щелчок мышью
        function send_mouse_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // послать двойной щелчок мышью
        function send_mouse_double_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // послать нажатие левой кнопки мыши
        function send_mouse_left_down($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // послать отжатие левой кнопки мыши
        function send_mouse_left_up($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   

        // послать щелчок правой кнопки мыши
        function send_mouse_right_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // послать нажатие правой кнопки мыши
        function send_mouse_right_down($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // послать отжатие правой кнопки мыши
        function send_mouse_right_up($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }*/

        // перемещение мышью
        public List<bool> mouse_move(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_move(dx,dy));
            return res;
        }

        // щелчок мышью
        public List<bool> mouse_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_click(dx, dy));
            return res;
        }
        // двойной щелчок мышью
        public List<bool> mouse_double_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_double_click(dx, dy));
            return res;
        }
        // нажатие левой кнопки мыши
        public List<bool> mouse_left_down(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_left_down(dx, dy));
            return res;
        }
        // отжатие левой кнопки мыши
        public List<bool> mouse_left_up(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_left_up(dx, dy));
            return res;
        }

        // щелчок правой кнопки мыши
        public List<bool> mouse_right_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_click(dx, dy));
            return res;
        }
        // нажатие правой кнопки мыши
        public List<bool> mouse_right_down(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_down(dx, dy));
            return res;
        }
        // отжатие правой кнопки мыши
        public List<bool> mouse_right_up(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_up(dx, dy));
            return res;
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
        public List<bool> send_key_down(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.send_key_down(key, is_key));
            return res;
        }
        // посылает отжатие клавиши
        public List<bool> send_key_up(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.send_key_down(key, is_key));
            return res;
        }

        // эммулирует ввод всех символов из переданной функции строки
        public List<bool> input(string string_, int timeout = 100)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.input(string_, timeout));
            return res;
        }
        // эммулирует ввод одной кнопки по ее скан коду
        public List<bool> key(int code)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.press_key_by_code(code));
            return res;
        }
        // эммулирует ввод одной кнопки по ее скан коду (deprecated)
        public List<bool> press_key_by_code(int code)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.press_key_by_code(code));
            return res;
        }
        // эмулирует нажатие клавиши
        public List<bool> key_down(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.key_down(key));
            return res;
        }
        // эмулирует отжатие клавиши
        public List<bool> key_up(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.key_up(key));
            return res;
        }
        // эммулирует задание языка ввода
        public List<string> set_current_language(string language)
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.set_current_language(language));
            return res;
        }   

    };
}