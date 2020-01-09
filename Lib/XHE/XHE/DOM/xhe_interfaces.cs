using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////////////// Interface //////////////////////////////////////////////
    public class XHEInterfaces : XHEBaseList
    {
	    /////////////////////////////////////// SERVICE FUNCTIONS ///////////////////////////////////////////

	    // server initialization
	    public XHEInterfaces(string inner_numbers,string server,string password=""):base(inner_numbers,server,password)
	    {    
		    if (inner_numbers!="" && inner_numbers!="Ignore")
		    {
			    if (inner_numbers==null)
				    return;			
			    string[] elms_nums=inner_numbers.Split(';');
			    for (int i=0;i<elms_nums.Length;i++) 
			    {
			         if (elms_nums[i].Trim()!="")
				         elements.Add(new XHEInterface(elms_nums[i].Trim(), m_Server,m_Password));
			    }
		    }
	    }
        // получить элемент
        public XHEInterface get(int index)
        {
            if (elements != null && index < elements.Count)
                return (XHEInterface)elements[index];
            else
                return new XHEInterface("", m_Server, m_Password);
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить интерфейс по заданному условию
        public XHEInterface get_by_xxx(string xxx, string condition, int exactly)
	    {
            Type thisType = typeof(XHEInterface);
            MethodInfo theMethod = thisType.GetMethod(xxx);
            int iNeedNum = -1;            
		    for (int i=0;i<elements.Count;i++) 
		    {                
			    if (compare_string(exactly==1,theMethod.Invoke(elements[i], null).ToString(),condition))
			    {
				    iNeedNum=i;
				    break;
			    }
		    }

		    // вернем элемент
		    if (iNeedNum!=-1)
                return (XHEInterface)elements[iNeedNum].get_clone_();
		    else
			    return new XHEInterface("",m_Server,m_Password);
	    }	

	    // получить интерфейс объекта по имени
        public XHEInterface get_by_name(string name, int exactly = 1)
	    {
		    return get_by_xxx("get_name",name,exactly);
	    }	
	    // получить интерфейс объекта по id
        public XHEInterface get_by_id(string id, int exactly = 1)
	    {
		    return get_by_xxx("get_id",id,exactly);
	    }	
	    // получить интерфейс объекта по внутреннему тексту
        public XHEInterface get_by_inner_text(string inner_text, int exactly = 1)
	    {
		    return get_by_xxx("get_inner_text",inner_text,exactly);
	    }	
	    // получить интерфейс объекта по внутреннему хтмл
        public XHEInterface get_by_inner_html(string inner_html, int exactly = 1)
	    {
		    return get_by_xxx("get_inner_html",inner_html,exactly);
	    }	
	    // получить интерфейс объекта по src
        public XHEInterface get_by_src(string src, int exactly = 1)
	    {
		    return get_by_xxx("get_src",src,exactly);
	    }	
	    // получить интерфейс объекта по href
        public XHEInterface get_by_href(string href, int exactly = 1)
	    {
		    return get_by_xxx("get_href",href,exactly);
	    }	
	    // получить интерфейс объекта по alt
        public XHEInterface get_by_alt(string alt, int exactly = 1)
	    {
		    return get_by_xxx("get_alt",alt,exactly);
	    }	
	    // получить интерфейс объекта по value
        public XHEInterface get_by_value(string value, int exactly = 1)
	    {
		    return get_by_xxx("get_value",value,exactly);
	    }	
	    // получить интерфейс объекта по значению аттрибута
        public XHEInterface get_by_attribute(string attr_name, string attr_value, int exactly = 1)
	    {
		    int iNeedNum=-1;
		    for (int i=0;i<elements.Count;i++) 
		    {
			    if (compare_string(exactly==1,((XHEInterface)elements[i]).get_attribute(attr_name),attr_value))
			    {
				    iNeedNum=i;
				    break;
			    }						
		    }

		    // вернем элемент
		    if (iNeedNum!=-1)
                return (XHEInterface)elements[iNeedNum].get_clone_();
		    else
			    return null;
	    }	

	    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить все интерфейсы по заданному условию
        public XHEInterfaces get_all_by_xxx(string xxx, string condition, int exactly)
	    {
            Type thisType = typeof(XHEInterface);
            MethodInfo theMethod = thisType.GetMethod(xxx);

            // получим номера элементов для нового списка
            List<int> aNeedNums = new List<int>();      
		    for (int i=0;i<elements.Count;i++) 
		    {
			    if (compare_string(exactly==1,theMethod.Invoke(elements[i], null).ToString(),condition))
			    	aNeedNums.Add(i);
		    }

		    // создадим новый список
		    XHEInterfaces new_interfaces=new XHEInterfaces("",m_Server,m_Password);

		    // заполним его клонами элементов
		    for (int i=0;i<aNeedNums.Count;i++)
		    {                
			    new_interfaces.elements.Add(elements[aNeedNums[i]].get_clone_());
                new_interfaces.inner_numbers = new_interfaces.inner_numbers + new_interfaces.elements[i].inner_number;                    
                if ((i + 1) != aNeedNums.Count)
                    new_interfaces.inner_numbers = new_interfaces.inner_numbers + ";";				
		    }				
		    return new_interfaces;
	    }	

        // получить все элементы c заданным именем
        public XHEInterfaces get_all_by_name(string name, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_name",name,exactly);
	    }	
        // получить все элементы c заданным id
        public XHEInterfaces get_all_by_id(string id, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_id",id,exactly);
	    }	
        // получить все элементы c заданным inner text
        public XHEInterfaces get_all_by_inner_text(string inner_text, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_inner_text",inner_text,exactly);
	    }	
        // получить все элементы c заданным inner html
        public XHEInterfaces get_all_by_inner_html(string inner_html, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_inner_html",inner_html,exactly);
	    }	
        // получить все элементы c заданным outer text
        public XHEInterfaces get_all_by_outer_text(string outer_text, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_outer_text",outer_text,exactly);
	    }	
        // получить все элементы c заданным outer html
        public XHEInterfaces get_all_by_outer_html(string outer_html, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_outer_html",outer_html,exactly);
	    }	
        // получить все элементы c заданным src
        public XHEInterfaces get_all_by_src(string src, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_src",src,exactly);
	    }	
        // получить все элементы c заданным href
        public XHEInterfaces get_all_by_href(string href, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_href",href,exactly);
	    }	
        // получить все элементы c заданным alt
        public XHEInterfaces get_all_by_alt(string alt, int exactly = 0, string frame = "-1")
	    {
		    return get_all_by_xxx("get_alt",alt,exactly);
	    }	
        // получить все элементы c заданным value
        public XHEInterfaces get_all_by_value(string value, int exactly = 0, string frame = "-1")
        {
	        return get_all_by_xxx("get_value",value,exactly);
        }
        // получить все элементы c заданным значением аттрибута
        public XHEInterfaces get_all_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
	        // получим номера элементов для нового списка
	        List<int> aNeedNums=new List<int>();
	        for (int i=0;i<elements.Count;i++) 
	        {
		        if (compare_string(exactly==1,((XHEInterface)elements[i]).get_attribute(attr_name),attr_value))
			        aNeedNums.Add(i);
	        }

	        // создадим новый список
	        XHEInterfaces new_interfaces=new XHEInterfaces("",m_Server,m_Password);
	        // заполним его клонами элементов
	        for (int i=0;i<aNeedNums.Count;i++)
	        {
		        new_interfaces.elements.Add(elements[aNeedNums[i]].get_clone_());
                new_interfaces.inner_numbers = new_interfaces.inner_numbers + new_interfaces.elements[i].inner_number;
		        if ((i+1)!=aNeedNums.Count)
                    new_interfaces.inner_numbers = new_interfaces.inner_numbers + ";";				
	        }				
	        return new_interfaces;
        }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // щелчок
        public List<bool> click()
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.click());
            return res;
        }
        // послать событие
        public List<bool> event_(string event_,bool wait_browser=true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.event_(event_,wait_browser));
            return res;
        }
        // чекнуть
        public List<bool> check(bool needCheck=true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.check(needCheck));
            return res;
        }
        // задать фокус
        public List<bool> focus()
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.focus());
            return res;
        }
        // скроллировать страницу чтобы увидеть этот элемент
        public List<bool> scroll_to_view(bool start)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.scroll_to_view(start));
            return res;
        }
        // скроллировать 
        public List<bool> scroll(string scroll_action)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.scroll(scroll_action));
            return res;
        }

        // задать значение
        public List<bool> set_value(string value)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.set_value(value));
            return res;
        }
        // задать внутренний текст
        public List<bool> set_inner_text(string inner_text)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.set_inner_text(inner_text));
            return res;
        }
        // задать внутренний хтмл
        public List<bool> set_inner_html(string inner_html)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.set_inner_html(inner_html));
            return res;
        }
        // добавить (или задать) аттрибут
        public List<bool> add_attribute(string name_atr, string value_atr)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.add_attribute(name_atr, value_atr));
            return res;
        }
        // задать аттрибут
        public List<bool> set_attribute(string name_atr, string value_atr)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.set_attribute(name_atr, value_atr));
            return res;
        }
        // убрать аттрибут
        public List<bool> remove_attribute(string name_atr)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.remove_attribute(name_atr));
            return res;
        }
        // сделать скроиншот элемента в файл
        public List<bool> screenshot(string file_path)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.screenshot(file_path));
            return res;
        }

        // получить тэг
        public List<string> get_tag()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_tag());
            return res;
        }
        // получить имя
        public List<string> get_name()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_name());
            return res;
        }
        // получить идентификатор
        public List<string> get_id()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_id());
            return res;
        }
        // получить номер
        public List<int> get_number()
        {
            List<int> res = new List<int>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_number());
            return res;
        }
        // получить внутренний текст
        public List<string> get_inner_text()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_inner_text());
            return res;
        }
        // получить внутренний хтмл
        public List<string> get_inner_html()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_inner_html());
            return res;
        }
        // получить значение
        public List<string> get_value()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_value());
            return res;
        }
        // получить href
        public List<string> get_href()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_href());
            return res;
        }
        // получить src
        public List<string> get_src()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_src());
            return res;
        }
        // получить alt
        public List<string> get_alt()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_alt());
            return res;
        }
        // получить значение аттрибута
        public List<string> get_attribute(string name_atr)
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_attribute(name_atr));
            return res;
        }
        // получить имена всех атрибутов
        public List<string> get_all_attributes()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_all_attributes());
            return res;
        }
        // получить значения всех атрибутов
        public List<string> get_all_attributes_values()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_all_attributes_values());
            return res;
        }
        // получить все события
        public List<string> get_all_events()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_all_events());
            return res;
        }
        // проверка недоступности
        public List<bool> is_disabled()
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.is_disabled());
            return res;
        }
        // проверка существования
        public List<bool> is_exist()
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.is_exist());
            return res;
        }
        // провекра видимости
        public List<bool> is_visibled()
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.is_visibled());
            return res;
        }
        // получить номера дочерних элементов заданного типа
        public List<string> get_numbers_child(string element_type = "",bool include_subchildren = false)
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_numbers_child(element_type,include_subchildren));
            return res;
        }

        // получить X координату
        public List<int> get_x()
        {
            List<int> res = new List<int>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_x());
            return res;
        }
        // получить Y координату
        public List<int> get_y()
        {
            List<int> res = new List<int>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_y());
            return res;
        }
        // получить ширину
        public List<int> get_width()
        {
            List<int> res = new List<int>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_width());
            return res;
        }
        // получить высоту
        public List<int> get_height()
        {
            List<int> res = new List<int>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_height());
            return res;
        }
        // получить xpath
        public List<string> get_xpath()
        {
            List<string> res = new List<string>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_xpath());
            return res;
        }

        // get parent interface
        public List<XHEInterface> get_parent()
        {
            List<XHEInterface> res = new List<XHEInterface>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_parent());
            return res;
        }
        // get prev interface
        public List<XHEInterface> get_prev()
        {
            List<XHEInterface> res = new List<XHEInterface>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_prev());
            return res;
        }
        // get next interface
        public List<XHEInterface> get_next()
        {
            List<XHEInterface> res = new List<XHEInterface>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_next());
            return res;
        }
        // get child count
        public List<XHEInterface> get_child_count()
        {
            List<XHEInterface> res = new List<XHEInterface>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_parent());
            return res;
        }
        // get child interface
        public List<XHEInterface> get_child_by_number(int number)
        {
            List<XHEInterface> res = new List<XHEInterface>();
            foreach (XHEInterface element in elements)
                res.Add(element.get_child_by_number(number));
            return res;
        }
        // подвинуть мышку на элемент со смещением
        public List<bool> mouse_move(int dx = 1, int dy = 1, int time = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_move(dx, dy, time));
            return res;
        }
        // кликнуть мышку на элементе со смещением
        public List<bool> mouse_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_click(dx, dy));
            return res;
        }
        // двойной щелчок мышкой на элементе со смещением
        public List<bool> mouse_double_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_double_click(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением
        public List<bool> mouse_left_down(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_left_down(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением
        public List<bool> mouse_left_up(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_left_up(dx, dy));
            return res;
        }

        // кликнуть мышку на элементе со смещением
        public List<bool> mouse_right_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_right_click(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением
        public List<bool> mouse_right_down(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_right_down(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением
        public List<bool> mouse_right_up(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.mouse_right_up(dx, dy));
            return res;
        }

        // подвинуть мышку на элемент со смещением (через события)
        public List<bool> send_mouse_move(int dx = 1, int dy = 1, int time = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_move(dx, dy,time));
            return res;
        }
        // кликнуть мышку на элементе со смещением (через события)
        public List<bool> send_mouse_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_click(dx, dy));
            return res;
        }
        // двойной щелчок мышкой на элементе со смещением (через события)
        public List<bool> send_mouse_double_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_double_click(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением (через события)
        public List<bool> send_mouse_left_down(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_left_down(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением (через события)
        public List<bool> send_mouse_left_up(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_left_up(dx, dy));
            return res;
        }

        // кликнуть мышку на элементе со смещением (через события)
        public List<bool> send_mouse_right_click(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_right_click(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением (через события)
        public List<bool> send_mouse_right_down(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_right_down(dx, dy));
            return res;
        }
        // подвинуть мышку на элемент со смещением (через события)
        public List<bool> send_mouse_right_up(int dx = 1, int dy = 1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_mouse_right_up(dx, dy));
            return res;
        }

        // посылает ввод строки в браузер, даже если он скрыт
        public List<bool> send_input(string string_, int timeout = 60, bool inFlash = false, bool auto_change = true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element. send_input(string_, timeout, inFlash, auto_change));
            return res;
        }
        // посылает ввод клавиши в браузер, даже если он скрыт
        public List<bool> send_key(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_key(key, is_key));
            return res;
        }
        // посылает нажатие клавиши в браузер, даже если он скрыт
        public List<bool> send_key_down(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_key_down(key, is_key));
            return res;
        }
        // посылает отжатие клавиши в браузер, даже если он скрыт 
        public List<bool> send_key_up(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.send_key_up(key, is_key));
            return res;
        }

        // эммулирует ввод всех символов из переданной функции строки
        public List<bool> input(string string_, int timeout = 60, bool inFlash = false, bool auto_change = true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.input(string_, timeout , inFlash ,auto_change ));
            return res;
        }
        // эммулирует ввод одной кнопки по ее скан коду
        public List<bool> press_key_by_code(int code)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.press_key_by_code(code));
            return res;
        }
        // эмулирует нажатие клавиши
        public List<bool> key_down(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.key_down(key));
            return res;
        }
        // эмулирует отжатие клавиши
        public List<bool> key_up(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEInterface element in elements)
                res.Add(element.key_up(key));
            return res;
        }

    };		
}