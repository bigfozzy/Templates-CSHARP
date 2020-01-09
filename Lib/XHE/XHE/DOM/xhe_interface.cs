using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using System.Threading;
using XHE;
using System.Reflection;
using XHE.XHE_Web;
using XHE.XHE_System;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////////////// Interface //////////////////////////////////////////////
    public class XHEInterface : XHEBaseInterface
    {        
        /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////

        // инициализация
        public XHEInterface(string inner_number, string server, string password = "")
            : base(server, password)
        {
            this.inner_number = inner_number;
            m_Server = server;
            m_Password = password;
            m_Prefix = "Interface";            
        }
        // деструктор (для очистки памяти)
        ~XHEInterface()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            call_boolean(MethodBase.GetCurrentMethod().Name, aParams);            
        }
        // клонировать интерфейс 
        public override XHEBaseInterface get_clone_()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            string clone_inner_number = call_get("get_clone", aParams);
            return new XHEInterface(clone_inner_number, m_Server, m_Password);
        }
        // клонировать интерфейс к DOM	
        public XHEInterface get_clone()
        {
            return (XHEInterface)get_clone_();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // щелчок
        public bool click()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == true)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // щелчок c фокусом и перемещением мыши
        public bool meta_click()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == true)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }        
        // послать событие
        public bool event_(string event_, bool wait_browser = true)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "event", event_ } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == true && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // чекнуть
        public bool check(bool needCheck=true)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "check", needCheck.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать фокус
        public bool focus()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // скроллировать страницу чтобы увидеть этот элемент
        public bool scroll_to_view(bool start)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "start", start.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // скроллировать 
        public bool scroll(string scroll_action)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "scroll_action", scroll_action } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // задать значение
        public bool set_value(string value)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "value", value } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать внутренний текст
        public bool set_inner_text(string inner_text)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_text", inner_text } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать внутренний хтмл
        public bool set_inner_html(string inner_html)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_html", inner_html } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить (или задать) аттрибут
        public bool add_attribute(string name_atr, string value_atr)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "name_atr", name_atr }, { "value_atr", value_atr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // задать аттрибут
        public bool set_attribute(string name_atr, string value_atr)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "name_atr", name_atr }, { "value_atr", value_atr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // убрать аттрибут
        public bool remove_attribute(string name_atr)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "name_atr", name_atr } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сделать скроиншот элемента в файл
        public bool screenshot(string file_path, bool as_gray = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "file_path", file_path } , { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // сохранить содержимое элемента в файл (картинка или флэш загружается с сайта)
        public bool save(string file_path)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "file_path", file_path } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить тэг
        public string get_tag()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить имя
        public string get_name()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить идентификатор
        public string get_id()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить номер
        public int get_number(string object_name="")
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "object_name", object_name }};
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить внутренний текст
        public string get_inner_text()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить внутренний хтмл
        public string get_inner_html()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить внешний  текст
        public string get_outer_text()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить внешний хтмл
        public string get_outer_html()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
	// получить вычисляемый стиль
	public string get_computed_style(string style_name="",string pseudo="")
	{
		string[,] aParams = new string[,] { { "inner_number", inner_number } , { "style_name", style_name } , { "pseudo", pseudo } };
		return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // получить значение
        public string get_value()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить href
        public string get_href()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить src
        public string get_src()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить alt
        public string get_alt()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить значение аттрибута
        public string get_attribute(string name_atr)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "name_atr", name_atr } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить номер фрейма
        public int get_frame_number()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить номер формы
        public int get_form_number()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить имена всех атрибутов
        public string get_all_attributes()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить значения всех атрибутов
        public string get_all_attributes_values()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить все события
        public string get_all_events()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверка недоступности
        public bool is_disabled()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверка чекнутости
        public bool is_checked()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверка существования
        public bool is_exist()
        {
            return inner_number != "-1";
        }
        // проверка видимости
        public bool is_visibled()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // проверка того что эелемнт сейчас попадает на страницу
        public bool is_view_now()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // сделать видимым (прокрутить до видимости)
        public bool ensure_visible()
        {
	        if (inner_number == "-1")
                	return false;
		if (!is_view_now())
		{
			int x=get_x();
			int y=get_y();		

			if (y>10)
                    GetBrowser().set_vertical_scroll_pos(y-10);
			if (x>10 && !is_view_now())
                    GetBrowser().set_horizontal_scroll_pos(x-10);

		}
		Thread.Sleep(1000);
		return true;
	}
        // получить номера дочерних элементов заданного типа
        public string get_numbers_child(string element_type = "",bool include_subchildren = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "element_type", element_type } , { "include_subchildren", include_subchildren.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить X координату
        public int get_x(bool in_view = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "in_view", in_view.ToString() } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить Y координату
        public int get_y(bool in_view = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } , { "in_view", in_view.ToString() } };
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

        // получить xpath
        public string get_xpath()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get parent interface
        public XHEInterface get_parent(int level=1)
        {
            string parent_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number } , { "level", level.ToString() } };
                parent_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(parent_inner_number, m_Server, m_Password);
        }
        // get parent interface by attribute
        public XHEInterface get_parent_by_attribute(string atr_name,string atr_value,int exactly=1)
        {
            string parent_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "atr_name", atr_name } , { "atr_value", atr_value }, { "exactly", exactly.ToString() }};
                parent_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(parent_inner_number, m_Server, m_Password);
        }
        // get next interface
        public XHEInterface get_next()
        {
            string parent_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number } };
                parent_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(parent_inner_number, m_Server, m_Password);
        }
        // get prev interface
        public XHEInterface get_prev()
        {
            string parent_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number } };
                parent_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(parent_inner_number, m_Server, m_Password);
        }
        // add child
        public XHEInterface add_child(string tag,string inner_html)
        {      
	    string child_inner_number = "-1";      
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number } , { "tag", tag }, { "inner_html", inner_html }};
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // insert before
        public XHEInterface insert_before(string tag,string inner_html)
        {      	     
	    string child_inner_number = "-1";      
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number } , { "tag", tag }, { "inner_html", inner_html }};
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // remove
        public bool remove()
        {      	     
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get child count
        public int get_child_count()
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get child interface
        public XHEInterface get_child_by_number(int number)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "number", number.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get child interface by inner text
        public XHEInterface get_child_by_inner_text(string inner_text, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_text", inner_text } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get child interface by inner html
        public XHEInterface get_child_by_inner_html(string inner_html, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_html", inner_html } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get child interface by outer text
        public XHEInterface get_child_by_outer_text(string outer_text, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "outer_text", outer_text } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get child interface by outer html
        public XHEInterface get_child_by_outer_html(string outer_html, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "outer_html", outer_html } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get child interface by atribute
        public XHEInterface get_child_by_attribute(string atr_name,string atr_value,int exactly=1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "atr_name", atr_name } , { "atr_value", atr_value } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterface(child_inner_number, m_Server, m_Password);
        }
        // get all child interfaces by inner text
        public XHEInterfaces get_all_child_by_inner_text(string inner_text, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_text", inner_text } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterfaces(child_inner_number, m_Server, m_Password);
        }
        // get all child interfaces by inner html
        public XHEInterfaces get_all_child_by_inner_html(string inner_html, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "inner_html", inner_html } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterfaces(child_inner_number, m_Server, m_Password);
        }
        // get all child interfaces by atribute
        public XHEInterfaces get_all_child_by_attribute(string atr_name,string atr_value, int exactly =1)
        {
            string child_inner_number = "-1";
            if (inner_number != "-1")
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "atr_name", atr_name } , { "atr_value", atr_value } , { "exactly", exactly.ToString() } };
                child_inner_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            }

            return new XHEInterfaces(child_inner_number, m_Server, m_Password);
        }
        // подвинуть мышку на элемент по заданной траектории
        public bool mouse_move_to(int dx = 1, int dy = 1, string type_="curve", int time = 1000  )
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() }, { "type_", type_.ToString() }, { "time", time.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // подвинуть мышку на элемент со смещением
        public bool mouse_move(int dx = 1, int dy = 1, int time = 0,int tremble = 0)
        {
            if (this==null)
                return false;

            if (time == 0)
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            else
            {
                double xc=Convert.ToDouble(GetMouse().get_x(true));
                double yc=Convert.ToDouble(GetMouse().get_y(true));
		
		        double sc_x= GetBrowser().get_horizontal_scroll_pos();
		        double sc_y= GetBrowser().get_vertical_scroll_pos();
		        xc+=sc_x;
		        yc+=sc_y;

                double x =get_x();
                double y=get_y();
                double StepX =(x-xc-0.0001)/time/50.0;
                double StepY=(y-yc-0.0001)/time/50.0;
                for (int i=0;i<50*time-1;i++)
                {
                    xc+=StepX;yc+=StepY;
                    string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", (xc- x).ToString() }, { "dy", (yc-y).ToString() } };
                    call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                    Thread.Sleep(20);
                }
                string[,] aParams1 = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams1);
            }

        }
        // кликнуть мышку на элементе со смещением
        public bool mouse_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // двойной щелчок мышкой на элементе со смещением
        public bool mouse_double_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением
        public bool mouse_left_down(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением
        public bool mouse_left_up(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // кликнуть мышку на элементе со смещением
        public bool mouse_right_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением
        public bool mouse_right_down(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением
        public bool mouse_right_up(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
   	// отправить касание пальцев
   	public bool send_touch(int id,int touch_type,int dx,int dy,int radiusX=0,int radiusY=0,float rotationAngle=0,float pressure=0,int modiefiers=0,int pointerType=0)
   	{
		string[,] aParams = new string[,] { { "inner_number", inner_number }, { "id", id.ToString() }, { "touch_type", touch_type.ToString() }, { "dx", dx.ToString() }, { "dy", dy.ToString() }, 
				{ "radiusX", radiusX.ToString() }, { "radiusY", radiusY.ToString() }, { "rotationAngle", rotationAngle.ToString() }, { "pressure", pressure.ToString() }, { "modiefiers", modiefiers.ToString() }, { "pointerType", pointerType.ToString() } };
		return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
   	}
        // подвинуть мышку на элемент по заданной траектории (через события)
        public bool send_mouse_move_to(int dx = 1, int dy = 1, string type_="curve", int time = 1000  )
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() }, { "type_", type_.ToString() }, { "time", time.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	}
        // подвинуть мышку на элемент со смещением (через события)
        public bool send_mouse_move(int dx = 1, int dy = 1, int time = 0,int tremble = 0, string buttons = "" )
        {
            if (time == 0)
            {
                string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } , { "buttons", buttons }};
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            }
            else
            {
                double xc=Convert.ToDouble(GetMouse().get_x(true,true));
                double yc=Convert.ToDouble(GetMouse().get_y(true,true));
		        double sc_x=GetBrowser().get_horizontal_scroll_pos();
		        double sc_y= GetBrowser().get_vertical_scroll_pos();
		        xc+=sc_x;
		        yc+=sc_y;
                double x=get_x();
                double y=get_y();
                double StepX=(x-xc-0.0001)/time/50.0;
                double StepY=(y-yc-0.0001)/time/50.0;
                for (int i=0;i<50*time-1;i++)
                {
                    xc+=StepX;yc+=StepY;
                    string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", (xc- x).ToString() }, { "dy", (yc- y).ToString() }, { "scroll", "1" } };
                    call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
                    Thread.Sleep(20);
                }
                string[,] aParams1 = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } , { "scroll", "1" }};
                return call_boolean(MethodBase.GetCurrentMethod().Name, aParams1);
            }
        }
        // кликнуть мышку на элементе со смещением (через события)
        public bool send_mouse_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // двойной щелчок мышкой на элементе со смещением (через события)
        public bool send_mouse_double_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением (через события)
        public bool send_mouse_left_down(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением (через события)
        public bool send_mouse_left_up(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // кликнуть мышку на элементе со смещением (через события)
        public bool send_mouse_right_click(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением (через события)
        public bool send_mouse_right_down(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // подвинуть мышку на элемент со смещением (через события)
        public bool send_mouse_right_up(int dx = 1, int dy = 1)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "dx", dx.ToString() }, { "dy", dy.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // посылает ввод строки в браузер, даже если он скрыт
        public bool send_input(string string_, int timeout = 60, bool inFlash = false, bool auto_change = true)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "string", string_ }, { "timeout", timeout.ToString() }, { "inFlash", inFlash.ToString() }, { "auto_change", auto_change.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            Thread.Sleep(1000);
            return res;
        }
        // посылает ввод клавиши в браузер, даже если он скрыт
        public bool send_key(string key, bool is_key = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "key", key }, { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // посылает нажатие клавиши в браузер, даже если он скрыт
        public bool send_key_down(string key, bool is_key = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "key", key }, { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // посылает отжатие клавиши в браузер, даже если он скрыт 
        public bool send_key_up(string key, bool is_key = false)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "key", key }, { "is_key", is_key.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // эммулирует ввод всех символов из переданной функции строки
        public bool input(string string_, int timeout=60, bool inFlash = false, bool auto_change = true)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "string", string_ }, { "timeout", timeout.ToString() }, { "inFlash", inFlash.ToString() }, { "auto_change", auto_change.ToString() } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);

            if (CSHARP_Use_Trought_Shell)
                Console.ReadLine();

            Thread.Sleep(1000);
            return res;
        }
        // эммулирует ввод одной кнопки по ее скан коду
        public bool key(int code)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // эммулирует ввод одной кнопки по ее скан коду (deprecated)
        public bool press_key_by_code(int code)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "code", code.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // эмулирует нажатие клавиши
        public bool key_down(string key)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // эмулирует отжатие клавиши
        public bool key_up(string key)
        {
            string[,] aParams = new string[,] { { "inner_number", inner_number }, { "key", key } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}