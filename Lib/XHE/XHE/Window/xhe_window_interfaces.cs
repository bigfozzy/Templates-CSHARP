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
        // �������� �������
        public XHEWindowInterface get(int index)
        {
            if (elements != null && index < elements.Count)
                return (XHEWindowInterface)elements[index];
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ��������� ���� �� ��� ������
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

            // ������ �������
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }
        // �������� ��������� ���� �� ��� ������
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

            // ������ �������
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("", m_Server, m_Password);
        }
        // �������� ��������� ���� �� ��� �����
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

            // ������ �������
            if (iNeedNum != -1)
                return (XHEWindowInterface)elements[iNeedNum].get_clone_();
            else
                return new XHEWindowInterface("",m_Server,m_Password);
        }

        ///////////////////////////////////////

        // ������ �����
        public List<bool> set_text(string text)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.set_text(text));
            return res;
        }
        // ������ ���������
        public List<bool> show(bool on = true)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.show(on));
            return res;
        }
        // �������� �����������
        public List<bool> enable(bool on)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.enable(on));
            return res;
        }

        // ������ �����
        public List<bool> focus()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.focus());
            return res;
        }
        // � ����� ���� 
        public List<bool> foreground()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.foreground());
            return res;
        }
        // ��������������
        public List<bool> minimize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.minimize());
            return res;
        }
        // ���������������
        public List<bool> maximize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.maximize());
            return res;
        }
        // ������������
        public List<bool> restore()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.restore());
            return res;
        }
        // �������
        public List<bool> close()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.close());
            return res;
        }

        // �����������
        public List<bool> move(int x = -1, int y = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.move(x,y));
            return res;
        }
        // �������� ������
        public List<bool> resize(int width = -1, int height = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.move(width, height));
            return res;
        }
        // ������� ���������
        public List<int> message(int type, int wparam, int lparam)
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.message(type, wparam, lparam));
            return res;
        }

        // ��������
        public List<bool> screenshot(string filepath, int x = -1, int y = -1, int width = -1, int heigth = -1)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.screenshot(filepath, x , y, width, heigth));
            return res;
        }

        // �������� ����� �������� ����
        public List<int> get_child_count()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_count());
            return res;
        }
        // �������� �������� �� ������
        public List<XHEWindowInterface> get_child_by_number(int number)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_number(number));
            return res;
        }
        // �������� �������� �� ������
        public List<XHEWindowInterface> get_child_by_text(string text, bool exactly = false)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_text(text, exactly));
            return res;
        }
        // �������� �������� �� ����� ������
        public List<XHEWindowInterface> get_child_by_class(string class_name, bool exactly = false)
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_child_by_class(class_name, exactly));
            return res;
        }
        // �������� ���������
        public List<XHEWindowInterface> get_next()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_next());
            return res;
        }
        // �������� ����������
        public List<XHEWindowInterface> get_prev()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_prev());
            return res;
        }
        // �������� ������������
        public List<XHEWindowInterface> get_parent()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_parent());
            return res;
        }
        // �������� ���������
        public List<XHEWindowInterface> get_owner()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_owner());
            return res;
        }
        // �������� ������ ����������� ���� �������� ����
        public List<XHEWindowInterfaces> get_all_child()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_child());
            return res;
        }
        // �������� ������ ����������� ���� ��������� ����
        public List<XHEWindowInterfaces> get_all_next()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_next());
            return res;
        }
        // �������� ������ ����������� ���� ���������� ����
        public List<XHEWindowInterfaces> get_all_prev()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_prev());
            return res;
        }
        // �������� ������ ����������� ���� ������������ ����
        public List<XHEWindowInterfaces> get_all_parent()
        {
            List<XHEWindowInterfaces> res = new List<XHEWindowInterfaces>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_all_parent());
            return res;
        }
        // �������� ���������� ��������
        public List<XHEWindowInterface> get_top_parent()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_top_parent());
            return res;
        }
        // �������� ���������� ���������
        public List<XHEWindowInterface> get_top_owner()
        {
            List<XHEWindowInterface> res = new List<XHEWindowInterface>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_top_owner());
            return res;
        }

        // �������� �����
        public List<string> get_text()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_text());
            return res;
        }
        // �������� �����
        public List<int> get_number(bool visibled = true, bool mained = true)
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_number(visibled, mained));
            return res;
        }
        // �������� ����� (������� ��� �����������)
        public List<string> get_style(bool extended = false)
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_style(extended));
            return res;
        }
        // �������� ��� ������
        public List<string> get_class_name()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_class_name());
            return res;
        }
        // �������� ���������� HWND
        public List<string> get_hwnd()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_hwnd());
            return res;
        }
        // �������� ID ��������
        public List<string> get_process_id()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_process_id());
            return res;
        }
        // �������� ID ������
        public List<string> get_thread_id()
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_thread_id());
            return res;
        }

        // �������� X
        public List<int> get_x()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_x());
            return res;
        }
        // �������� Y
        public List<int> get_y()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_y());
            return res;
        }
        // �������� ������
        public List<int> get_width()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_width());
            return res;
        }
        // �������� ������
        public List<int> get_height()
        {
            List<int> res = new List<int>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.get_height());
            return res;
        }

        // ���������� ��
        public List<bool> is_exist()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_exist());
            return res;
        }
        // ������ ��
        public List<bool> is_visible()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_visible());
            return res;
        }
        // �������� ��
        public List<bool> is_enable()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_enable());
            return res;
        }
        // ���� �� ����� �����
        public List<bool> is_focus()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_focus());
            return res;
        }
        // �������� ��
        public List<bool> is_child()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_child());
            return res;
        }
        // �������������� ��
        public List<bool> is_minimize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_minimize());
            return res;
        }
        // ��������������� ��
        public List<bool> is_maximize()
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.is_maximize());
            return res;
        }

        /*// ������� ����������� �����
        function send_mouse_move($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   

        // ������� ������ �����
        function send_mouse_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // ������� ������� ������ �����
        function send_mouse_double_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // ������� ������� ����� ������ ����
        function send_mouse_left_down($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // ������� ������� ����� ������ ����
        function send_mouse_left_up($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   

        // ������� ������ ������ ������ ����
        function send_mouse_right_click($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // ������� ������� ������ ������ ����
        function send_mouse_right_down($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }   
        // ������� ������� ������ ������ ����
        function send_mouse_right_up($dx=0,$dy=0)
        {
            $params = array( "inner_number" => inner_number , "dx" => $dx , "dy" => $dy );
            return call_boolean(__FUNCTION__,$params);
        }*/

        // ����������� �����
        public List<bool> mouse_move(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_move(dx,dy));
            return res;
        }

        // ������ �����
        public List<bool> mouse_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_click(dx, dy));
            return res;
        }
        // ������� ������ �����
        public List<bool> mouse_double_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_double_click(dx, dy));
            return res;
        }
        // ������� ����� ������ ����
        public List<bool> mouse_left_down(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_left_down(dx, dy));
            return res;
        }
        // ������� ����� ������ ����
        public List<bool> mouse_left_up(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_left_up(dx, dy));
            return res;
        }

        // ������ ������ ������ ����
        public List<bool> mouse_right_click(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_click(dx, dy));
            return res;
        }
        // ������� ������ ������ ����
        public List<bool> mouse_right_down(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_down(dx, dy));
            return res;
        }
        // ������� ������ ������ ����
        public List<bool> mouse_right_up(int dx = 0, int dy = 0)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.mouse_right_up(dx, dy));
            return res;
        }

        /*// �������� ���� ������ � �������, ���� ���� �� �����
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
        // �������� ���� ������� � �������, ���� ���� �� �����
        function send_key($key,$is_key=false)
        {
            $params = array( "inner_number" => inner_number , "key" => $key , "is_key" => $is_key);
            return call_boolean(__FUNCTION__,$params);
        }
        */

        // �������� ������� �������
        public List<bool> send_key_down(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.send_key_down(key, is_key));
            return res;
        }
        // �������� ������� �������
        public List<bool> send_key_up(string key, bool is_key = false)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.send_key_down(key, is_key));
            return res;
        }

        // ���������� ���� ���� �������� �� ���������� ������� ������
        public List<bool> input(string string_, int timeout = 100)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.input(string_, timeout));
            return res;
        }
        // ���������� ���� ����� ������ �� �� ���� ����
        public List<bool> key(int code)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.press_key_by_code(code));
            return res;
        }
        // ���������� ���� ����� ������ �� �� ���� ���� (deprecated)
        public List<bool> press_key_by_code(int code)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.press_key_by_code(code));
            return res;
        }
        // ��������� ������� �������
        public List<bool> key_down(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.key_down(key));
            return res;
        }
        // ��������� ������� �������
        public List<bool> key_up(string key)
        {
            List<bool> res = new List<bool>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.key_up(key));
            return res;
        }
        // ���������� ������� ����� �����
        public List<string> set_current_language(string language)
        {
            List<string> res = new List<string>();
            foreach (XHEWindowInterface element in elements)
                res.Add(element.set_current_language(language));
            return res;
        }   

    };
}