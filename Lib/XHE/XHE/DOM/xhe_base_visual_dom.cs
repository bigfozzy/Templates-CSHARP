using System;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    ///////////////////////////////////////////// ����� ��� ���� DOM ////////////////////////////////////////////
    public class XHEBaseDOMVisual : XHEBaseDOM
    {
        ////////////////////////////////////// SERVICVE FUNCTIONS ///////////////////////////////////////////
        // server initialization
        public XHEBaseDOMVisual(string server, string password = "")
            : base(server, password)
        {
            m_Prefix = "-bvd-";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������, ��������� �����
        public bool click_by_number(int number, string frame = "-1")
        {
            return z_click_by_number(number, frame);
        }
        // ������, ��������� ���
        public bool click_by_name(string name, string frame = "-1")
        {
            return z_click_by_name(name, frame);
        }
        // ������, ��������� id
        public bool click_by_id(string id, int exactly = 1, string frame = "-1")
        {
            return z_click_by_id(id, exactly, frame);
        }
        // ������, ��������� value
        public bool click_by_value(string value, int exactly = 1, string frame = "-1")
        {
            return z_click_by_value(value, exactly, frame);
        }
        // ������, ��������� alt
        public bool click_by_alt(string alt, int exactly = 1, string frame = "-1")
        {
            return z_click_by_alt(alt, exactly, frame);
        }
        // ������, ��������� src
        public bool click_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_click_by_src(src, exactly, frame);
        }
        // ������, ��������� href
        public bool click_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_click_by_href(href, exactly, frame);
        }
        // ������, ��������� ���������� �����
        public bool click_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_click_by_inner_text(text, exactly, frame);
        }
        // ������, ��������� ���������� ����
        public bool click_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_click_by_inner_html(inner_html, exactly, frame);
        }
        // ������, ��������� �������� ��������
        public bool click_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_click_by_attribute(attr_name, attr_value, exactly, frame);
        }
        // ������, ��������� �����, � ����� � �������� �������
        public bool click_by_number_by_form_number(int number, int form_number, string frame = "-1")
        {
            return z_click_by_number_by_form_number(number, form_number, frame);
        }
        // ������, ��������� ���, � ����� � �������� �������
        public bool click_by_name_by_form_number(string name, int form_number, string frame = "-1")
        {
            return z_click_by_name_by_form_number(name, form_number, frame);
        }
        // ������, ��������� �������� ���������, � ����� � �������� �������
        public bool click_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, int form_number, string frame = "-1")
        {
            return z_click_by_attribute_by_form_number(attr_name, attr_value, exactly, form_number, frame);
        }
        // ������, ��������� �����, � ����� � �������� ������
        public bool click_by_number_by_form_name(int number, string form_name, string frame = "-1")
        {
            return z_click_by_number_by_form_name(number, form_name, frame);
        }
        // ������, ��������� ���, � ����� � �������� ������
        public bool click_by_name_by_form_name(string name, string form_name, string frame = "-1")
        {
            return z_click_by_name_by_form_name(name, form_name, frame);
        }
        // ������, ��������� �������� ���������, � ����� � �������� ������
        public bool click_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string form_name, string frame = "-1")
        {
            return z_click_by_attribute_by_form_name(attr_name, attr_value, exactly, form_name, frame);
        }

        // ������ ��������� �������
        public int click_random(string frame = "-1")
        {
            return z_click_random(frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������� ������� �� ������
        public bool send_event_by_number(int number, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_number(number, event_, frame, wait_browser);
        }
        // ������� ������� �� �����
        public bool send_event_by_name(string name, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_name(name, event_, frame, wait_browser);
        }
        // ������� ������� �� id
        public bool send_event_by_id(string id, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_id(id, exactly, event_, frame, wait_browser);
        }
        // ������� ������� �� ����
        public bool send_event_by_href(string url, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_href(url, exactly, event_, frame, wait_browser);
        }
        // ������� ������� �� ����������� ������
        public bool send_event_by_inner_text(string text, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_inner_text(text, exactly, event_, frame, wait_browser);
        }
        // ������� ������� �� ����������� ����
        public bool send_event_by_inner_html(string html, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_inner_html(html, exactly, event_, frame, wait_browser);
        }
        // ������� ������� �� ��������
        public bool send_event_by_attribute(string atr_name, string atr_value, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_attribute(atr_name, atr_value, exactly, event_, frame, wait_browser);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� �����, ��������� �����
        public bool set_focus_by_number(int number, string frame = "-1")
        {
            return z_set_focus_by_number(number, frame);
        }
        // ���������� �����, ��������� ���
        public bool set_focus_by_name(string name, string frame = "-1")
        {
            return z_set_focus_by_name(name, frame);
        }
        // ���������� �����, ��������� href
        public bool set_focus_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_href(href, exactly, frame);
        }
        // ���������� �����, ��������� ���������� �����
        public bool set_focus_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_inner_text(inner_text, exactly, frame);
        }
        // ���������� �����, ��������� ���������� ����
        public bool set_focus_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_inner_html(inner_html, exactly, frame);
        }
        // ���������� �����, ��������� �������� ���������
        public bool set_focus_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ������ �������� �������� �� ��� ������
        public bool set_value_by_number(int number, string value, string frame = "-1")
        {
            return z_set_value_by_number(number, value, frame);
        }
        // ������ �������� �������� �� ��� �����
        public bool set_value_by_name(string name, string value, string frame = "-1")
        {
            return z_set_value_by_name(name, value, frame);
        }
        // ������ �������� �������� �� ��� ���������
        public bool set_value_by_attribute(string attr_name, string attr_value, int exactly, string value, string frame = "-1")
        {
            return z_set_value_by_attribute(attr_name, attr_value, exactly, value, frame);
        }

        // ������ �������� �������� �� ������, � ����� � �������� �������
        public bool set_value_by_number_by_form_number(int number, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_number_by_form_number(number, value, form_number, frame);
        }
        // ������ �������� �������� �� �����, � ����� � �������� �������
        public bool set_value_by_name_by_form_number(string name, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_name_by_form_number(name, value, form_number, frame);
        }
        // ������ �������� �������� �� �������� ���������, � ����� � �������� �������
        public bool set_value_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_attribute_by_form_number(attr_name, attr_value, exactly, value, form_number, frame);
        }

        // ������ �������� �������� �� ������, � ����� � �������� ������
        public bool set_value_by_number_by_form_name(int number, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_number_by_form_name(number, value, form_name, frame);
        }
        // ������ �������� �������� �� �����, � ����� � �������� ������
        public bool set_value_by_name_by_form_name(string name, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_name_by_form_name(name, value, form_name, frame);
        }
        // ������ �������� �������� �� �������� ���������, � ����� � �������� ������
        public bool set_value_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_attribute_by_form_name(attr_name, attr_value, exactly, value, form_name, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������� ���������� �����, ��������� �����
        public bool set_inner_text_by_number(int number, string text, string frame = "-1")
        {
            return z_set_inner_text_by_number(number, text, frame);
        }
        // ���������� ���������� �����, ��������� ���
        public bool set_inner_text_by_name(string name, string text, string frame = "-1")
        {
            return z_set_inner_text_by_name(name, text, frame);
        }
        // ���������� ���������� �����, ��������� �������� ���������
        public bool set_inner_text_by_attribute(string attr_name, string attr_value, string text, int exactly = 1, string frame = "-1")
        {
            return z_set_inner_text_by_attribute(attr_name, attr_value, exactly, text, frame);
        }

        // ���������� ���������� html, ��������� �����
        public bool set_inner_html_by_number(int number, string html, string frame = "-1")
        {
            return z_set_inner_html_by_number(number, html, frame);
        }
        // ���������� ���������� html, ��������� ���
        public bool set_inner_html_by_name(string name, string html, string frame = "-1")
        {
            return z_set_inner_html_by_name(name, html, frame);
        }
        // ���������� ���������� html, ��������� �������� ���������
        public bool set_inner_html_by_attribute(string attr_name, string attr_value, string html, int exactly = 1, string frame = "-1")
        {
            return z_set_inner_html_by_attribute(attr_name, attr_value, exactly, html, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� �������, ��������� �����
        public bool add_attribute_by_number(int number, string name_attr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_number(number, name_attr, value_attr, frame);
        }
        // �������� �������, ��������� ���
        public bool add_attribute_by_name(string name, string name_attr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_name(name, name_attr, value_attr, frame);
        }
        // �������� ��������, ��������� ���������� �����
        public bool add_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_inner_text(inner_text, exactly, name_atr, value_attr, frame);
        }
        // �������� ��������, ��������� ���������� html
        public bool add_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_inner_html(inner_html, exactly, name_atr, value_attr, frame);
        }
        // �������� ��������, ��������� �������� ���������
        public bool add_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, value_attr, frame);
        }

        //  ������ �������� ���������, ��������� �����
        public bool set_attribute_by_number(int number, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_number(number, name_atr, value_atr, frame);
        }
        // ������ �������� ���������, ��������� ���
        public bool set_attribute_by_name(string name, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_name(name, name_atr, value_atr, frame);
        }
        // ������ �������� ���������, ��������� ���������� �����
        public bool set_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_inner_text(inner_text, exactly, name_atr, value_atr, frame);
        }
        // ������ �������� ���������, ��������� ���������� html
        public bool set_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_inner_html(inner_html, exactly, name_atr, value_atr, frame);
        }
        // ������ �������� ���������, ��������� �������� ���������
        public bool set_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, value_atr, frame);
        }

        // ������� �������, ��������� �����
        public bool remove_attribute_by_number(int number, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_number(number, name_atr, frame);
        }
        // ������� �������, ��������� ���
        public bool remove_attribute_by_name(string name, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_name(name, name_atr, frame);
        }
        // ������� ��������, ��������� ���������� �����
        public bool remove_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_inner_text(inner_text, exactly, name_atr, frame);
        }
        // ������� ��������, ��������� ���������� html
        public bool remove_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_inner_html(inner_html, exactly, name_atr, frame);
        }
        // ������� ��������, ��������� �������� ���������
        public bool remove_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������, ��������� �����
        public bool screenshot_by_number(string file_path, int number, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_number(file_path, number, frame, as_gray);
        }
        // ��������, ��������� ���
        public bool screenshot_by_name(string file_path, string name, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_name(file_path, name, frame, as_gray);
        }
        // ��������, ��������� src
        public bool screenshot_by_src(string file_path, string src, int exactly = 1, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_src(file_path, src, exactly, frame, as_gray);
        }
        // ��������, ��������� �������� ���������
        public bool screenshot_by_attribute(string file_path, string atr_name, string atr_value, int exactly = 1, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_attribute(file_path, atr_name, atr_value, exactly, frame, as_gray);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ���������, ���� �� ������� � �������� �������
        public bool is_exist_by_number(int number, string frame = "-1")
        {
            return z_is_exist_by_number(number, frame);
        }
        // ���������, ���� �� ������� � �������� ������
        public bool is_exist_by_name(string name, string frame = "-1")
        {
            return z_is_exist_by_name(name, frame);
        }
        // ���������, ���� �� ������� � �������� id
        public bool is_exist_by_id(string id, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_id(id, exactly, frame);
        }
        // ���������, ���� �� ������� � �������� href
        public bool is_exist_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_href(href, exactly, frame);
        }
        // ���������, ���� �� ������� � �������� alt
        public bool is_exist_by_alt(string alt, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_alt(alt, exactly, frame);
        }
        // ���������, ���� �� ������� � �������� src
        public bool is_exist_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_src(src, exactly, frame);
        }
        // ���������, ���� �� ������� � �������� ���������� ������� 
        public bool is_exist_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_inner_text(inner_text, exactly, frame);
        }
        // ���������, ���� �� ������� � �������� ���������� ���� 
        public bool is_exist_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_inner_html(inner_html, exactly, frame);
        }
        // ��������� ���� �� ������� � �������� ��������� ��������
        public bool is_exist_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_attribute(atr_name, atr_value, exactly, frame);
        }
        // ��������� ���� �� ������� � �������� xpath
        public bool is_exist_by_xpath(string xpath)
        {
            return z_is_exist_by_xpath(xpath);
        }

        // ��������� ���� �� ������� � �������� ��������� �������� � ����� � �������� �������
        public bool is_exist_by_attribute_by_form_number(string atr_name, string atr_value, int exactly, int form_number, string frame = "-1")
        {
            return z_is_exist_by_attribute_by_form_number(atr_name, atr_value, exactly, form_number, frame);
        }
        // ��������� ���� �� ������� � �������� ��������� �������� � ����� � �������� ������
        public bool is_exist_by_attribute_by_form_name(string atr_name, string atr_value, int exactly, string form_name, string frame = "-1")
        {
            return z_is_exist_by_attribute_by_form_name(atr_name, atr_value, exactly, form_name, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ����� �� �����
        public int get_number_by_name(string name, string frame = "-1")
        {
            return z_get_number_by_name(name, frame);
        }
        // �������� ����� �� id
        public int get_number_by_id(string id, string frame = "-1")
        {
            return z_get_number_by_id(id, frame);
        }
        // �������� ����� �� src
        public int get_number_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_src(src, exactly, frame);
        }
        // �������� ����� �� href
        public int get_number_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_href(href, exactly, frame);
        }
        // �������� ����� �� ����������� ������
        public int get_number_by_inner_text(string innertext, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_inner_text(innertext, exactly, frame);
        }
        // �������� ����� �� ����������� html
        public int get_number_by_inner_html(string innerhtml, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_inner_html(innerhtml, exactly, frame);
        }
        // �������� ����� �� �������� ��������
        public int get_number_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_attribute(atr_name, atr_value, exactly, frame);
        }

        // �������� ��� �� ������
        public string get_name_by_number(int number, string frame = "-1")
        {
            return z_get_name_by_number(number, frame);
        }

        // �������� �������� �������� �� ������
        public string get_attribute_by_number(int number, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_number(number, name_atr, frame);
        }
        // �������� �������� �������� �� �����
        public string get_attribute_by_name(string name, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_name(name, name_atr, frame);
        }
        // �������� �������� �������� �� src
        public string get_attribute_by_src(string src, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_src(src, exactly, name_atr, frame);
        }
        // �������� �������� �������� �� ����������� ������
        public string get_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_inner_text(inner_text, exactly, name_atr, frame);
        }
        // �������� �������� �������� �� ����������� html
        public string get_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_inner_html(inner_html, exactly, name_atr, frame);
        }
        // �������� �������� �������� �� ��������
        public string get_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� value �� ������
        public string get_value_by_number(int number, string frame = "-1")
        {
            return z_get_value_by_number(number, frame);
        }
        // �������� value �� �����
        public string get_value_by_name(string name, string frame = "-1")
        {
            return z_get_value_by_name(name, frame);
        }
        // �������� value �� ���������
        public string get_value_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_value_by_attribute(atr_name, atr_value, exactly, frame);
        }

        // �������� src �� ������
        public string get_src_by_number(int number, string frame = "-1")
        {
            return z_get_src_by_number(number, frame);
        }
        // �������� src �� �����
        public string get_src_by_name(string name, string frame = "-1")
        {
            return z_get_src_by_name(name, frame);
        }

        // �������� alt �� ������
        public string get_alt_by_number(int number, string frame = "-1")
        {
            return z_get_alt_by_number(number, frame);
        }
        // �������� alt �� �����
        public string get_alt_by_name(string name, string frame = "-1")
        {
            return z_get_alt_by_name(name, frame);
        }

        // �������� href �� ������
        public string get_href_by_number(int number, string frame = "-1")
        {
            return z_get_href_by_number(number, frame);
        }
        // �������� href �� �����
        public string get_href_by_name(string name, string frame = "-1")
        {
            return z_get_href_by_name(name, frame);
        }
        // �������� href �� ����������� ������
        public string get_href_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_get_href_by_inner_text(inner_text, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ���������� ����� �� ������
        public string get_inner_text_by_number(int number, string frame = "-1")
        {
            return z_get_inner_text_by_number(number, frame);
        }
        // �������� ���������� ����� �� �����
        public string get_inner_text_by_name(string name, string frame = "-1")
        {
            return z_get_inner_text_by_name(name, frame);
        }
        // �������� ���������� ����� �� id
        public string get_inner_text_by_id(string id, string frame = "-1")
        {
            return z_get_inner_text_by_id(id, frame);
        }
        // �������� ���������� ����� �� href
        public string get_inner_text_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_text_by_href(href, exactly, frame);
        }
        // �������� ���������� ����� �� �������� ���������
        public string get_inner_text_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_text_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� ���������� html �� ������
        public string get_inner_html_by_number(int number, string frame = "-1")
        {
            return z_get_inner_html_by_number(number, frame);
        }
        // �������� ���������� html �� �����
        public string get_inner_html_by_name(string name, string frame = "-1")
        {
            return z_get_inner_html_by_name(name, frame);
        }
        // �������� ���������� html �� id
        public string get_inner_html_by_id(string id, string frame = "-1")
        {
            return z_get_inner_html_by_id(id, frame);
        }
        // �������� ���������� html �� �������� ���������
        public string get_inner_html_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_html_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��������� ����������� �������� �� ������
        public bool is_disabled_by_number(int number, string frame = "-1")
        {
            return z_is_disabled_by_number(number, frame);
        }
        // ��������� ����������� �������� �� �����
        public bool is_disabled_by_name(string name, string frame = "-1")
        {
            return z_is_disabled_by_name(name, frame);
        }

        // �������� ��� ��������� �������� �� ��� ������
        public string get_all_attributes_by_number(int number, string frame = "-1")
        {
            return z_get_all_attributes_by_number(number, frame);
        }
        // �������� ��� ��������� �������� �� ��� �����
        public string get_all_attributes_by_name(string name, string frame = "-1")
        {
            return z_get_all_attributes_by_name(name, frame);
        }
        // �������� ��� ��������� �������� �� src
        public string get_all_attributes_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_attributes_by_src(src, exactly, frame);
        }

        // �������� ��� �������� ��������� �������� �� ��� ������
        public string get_all_attributes_values_by_number(int number, string frame = "-1")
        {
            return z_get_all_attributes_values_by_number(number, frame);
        }
        // �������� ��� �������� ��������� �������� �� ��� �����
        public string get_all_attributes_values_by_name(string name, string frame = "-1")
        {
            return z_get_all_attributes_values_by_name(name, frame);
        }
        // �������� ��� �������� ��������� �������� �� src
        public string get_all_attributes_values_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_attributes_values_by_src(src, exactly, frame);
        }

        // �������� ��� ������� �������� �� ��� ������
        public string get_all_events_by_number(int number, string frame = "-1")
        {
            return z_get_all_events_by_number(number, frame);
        }
        // �������� ��� ������� �������� �� ��� �����
        public string get_all_events_by_name(string name, string frame = "-1")
        {
            return z_get_all_events_by_name(name, frame);
        }
        // �������� ��� ������� �������� �� src
        public string get_all_events_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_events_by_src(src, exactly, frame);
        }

        // �������� ������ �������� ��������� �� ��� ������
        public string get_numbers_child_by_number(int number, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_number(number, element_type, frame, include_subchildren);
        }
        // �������� ������ �������� ��������� �� ��� �����
        public string get_numbers_child_by_name(string name, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_name(name, element_type, frame, include_subchildren);
        }
        // �������� ������ �������� ��������� �� ��� id
        public string get_numbers_child_by_id(string id, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_id(id, element_type, frame, include_subchildren);
        }
        // �������� ������ �������� ��������� �� �������� ��� ���������
        public string get_numbers_child_by_attribute(string attr_name, string attr_value, int exactly = 1, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_attribute(attr_name, attr_value, exactly, element_type, frame, include_subchildren);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� X ������ �������� ���� �������� �� ������
        public int get_x_by_number(int number, string frame = "-1")
        {
            return z_get_x_by_number(number, frame);
        }
        // �������� X ������ �������� ���� �������� �� �����
        public int get_x_by_name(string name, string frame = "-1")
        {
            return z_get_x_by_name(name, frame);
        }
        // �������� X ������ �������� ���� �������� �� href
        public int get_x_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_href(href, exactly, frame);
        }
        // �������� X ������ �������� ���� �������� �� ����������� ������
        public int get_x_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_inner_text(text, exactly, frame);
        }
        // �������� X ������ �������� ���� �������� �� ����������� html
        public int get_x_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_inner_html(inner_html, exactly, frame);
        }
        // �������� X ������ �������� ���� �������� �� �������� ��������
        public int get_x_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� Y ������ �������� ���� �������� �� ������
        public int get_y_by_number(int number, string frame = "-1")
        {
            return z_get_y_by_number(number, frame);
        }
        // �������� Y ������ �������� ���� �������� �� �����
        public int get_y_by_name(string name, string frame = "-1")
        {
            return z_get_y_by_name(name, frame);
        }
        // �������� Y ������ �������� ���� �������� �� href
        public int get_y_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_href(href, exactly, frame);
        }
        // �������� Y ������ �������� ���� �������� �� ����������� ������
        public int get_y_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_inner_text(text, exactly, frame);
        }
        // �������� Y ������ �������� ���� �������� �� ����������� html
        public int get_y_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_inner_html(inner_html, exactly, frame);
        }
        // �������� Y ������ �������� ���� �������� �� �������� ��������
        public int get_y_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_attribute(attr_name, attr_value, exactly, frame);
        }

        //////////////////////////////////// GET SIZES /////////////////////////////////////////

        // �������� ������ �������� �� ������
        public int get_width_by_number(int number, string frame = "-1")
        {
            return z_get_width_by_number(number, frame);
        }
        // �������� ������ �������� �� �����
        public int get_width_by_name(string name, string frame = "-1")
        {
            return z_get_width_by_name(name, frame);
        }
        // �������� ������ �������� �� src
        public int get_width_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_src(src, exactly, frame);
        }
        // �������� ������ �������� �� href
        public int get_width_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_href(href, exactly, frame);
        }
        // �������� ������ �������� �� �������� ��������
        public int get_width_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� ������ �������� �� ������
        public int get_height_by_number(int number, string frame = "-1")
        {
            return z_get_height_by_number(number, frame);
        }
        // �������� ������ �������� �� �����
        public int get_height_by_name(string name, string frame = "-1")
        {
            return z_get_height_by_name(name, frame);
        }
        // �������� ������ �������� �� src
        public int get_height_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_src(src, exactly, frame);
        }
        // �������� ������ �������� �� href
        public int get_height_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_href(href, exactly, frame);
        }
        // �������� ������ �������� �� �������� ��������
        public int get_height_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ����� � ���������� � ������� � �������� �������
        public bool send_keyboard_input_by_number(int number, string string_, int timeout=60, string frame = "-1")
        {
            return z_send_keyboard_input_by_number(number, string_, timeout, frame);
        }
        // �������� ����� � ���������� � ������� � �������� ������
        public bool send_keyboard_input_by_name(string name, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_name(name, string_, timeout, frame);
        }
        // �������� ����� � ���������� � ������� �� ����������� ������
        public bool send_keyboard_input_by_inner_text(string inner_text, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_inner_text(inner_text, exactly, string_, timeout, frame);
        }
        // �������� ����� � ���������� � ������� �� ����������� html
        public bool send_keyboard_input_by_inner_html(string inner_html, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_inner_html(inner_html, exactly, string_, timeout, frame);
        }
        // �������� ����� � ���������� � ������� �� �������� ���������
        public bool send_keyboard_input_by_attribute(string attr_name, string attr_value, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_attribute(attr_name, attr_value, exactly, string_, timeout, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ����� ��������� �� ��������
        public int get_count(string frame = "-1")
        {
            return z_get_count(frame);
        }
        // �������� ����� ��������� �� �������� c �������� ��������� ���������
        public int get_count_by_attribute(string attr_name, string attr_value, int exactly = 0,string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // �������� ������ ���� ��������� � �������� ���������� �������
        public string[] get_all_numbers_by_inner_text(string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_inner_text(text, exactly, frame);
        }
        // �������� ������ ���� ��������� � �������� ���������� ����
        public string[] get_all_numbers_by_inner_html(string html, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_inner_html(html, exactly, frame);
        }
        // �������� ������ ���� ��������� � �������� ��������� ���������
        public string[] get_all_numbers_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� ��� ���������� ������ ���� ��������� � �������� ���������� �������
        public string get_all_inner_texts(string separator = "<br>", string text_filter = "", string frame = "-1")
        {
            return z_get_all_inner_texts(separator, text_filter, frame);
        }
        // �������� ��� ���������� ������ ���� ��������� � ��������� ��������� ����������
        public string[] get_all_inner_texts_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_texts_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� ��� ���������� html ���� ��������� � �������� ���������� �������
        public string[] get_all_inner_htmls_by_inner_text(string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_htmls_by_inner_text(text, exactly, frame);
        }
        // �������� ��� ���������� html ���� ��������� � �������� ��������� ���������
        public string[] get_all_inner_htmls_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_htmls_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // �������� ��� �������� ��������� ���� ��������� � �������� ���������� �������
        public string[] get_all_attributes_by_inner_text(string attr_name_need, string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_attributes_by_inner_text(attr_name_need, text, exactly, frame);
        }
        // �������� ��� �������� ��������� ���� ��������� �� �������� ���������
        public string[] get_all_attributes_by_attribute(string attr_name_need, string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_attributes_by_attribute(attr_name_need, attr_name, attr_value, exactly, frame);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        // �������� ��������� ������� �� ������
        public XHEInterface get_by_number(int number,string frame="-1")
        {
            wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� �����
        public XHEInterface get_by_name(string name,string frame="-1")
        {
            wait_element_exist_by_name(name,frame);

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� ����������� ������
        public XHEInterface get_by_inner_text(string inner_text, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_inner_text(inner_text,exactly,frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� ����������� ����
        public XHEInterface get_by_inner_html(string inner_html, int exactly =0,string frame="-1")
        {
            wait_element_exist_by_inner_html(inner_html,exactly,frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� �������� ������
        public XHEInterface get_by_outer_text(string outer_text, int exactly = 0,string frame="-1")
        {
            wait_element_exist_by_outer_text(outer_text,exactly,frame);

            string[,] aParams = new string[,] { { "outer_text", outer_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� �������� ����
        public XHEInterface get_by_outer_html(string outer_html, int exactly = 0,string frame="-1")
        {
            wait_element_exist_by_outer_html(outer_html,exactly,frame);

            string[,] aParams = new string[,] { { "outer_html", outer_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� id
        public XHEInterface get_by_id(string id, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("id",id,exactly,frame);

            string[,] aParams = new string[,] { { "id", id }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� src
        public XHEInterface get_by_src(string src, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("src",src,exactly,frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� href
        public XHEInterface get_by_href(string href, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("href",href,exactly,frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number, m_Server, m_Password);
        }	
        // �������� ��������� ������� �� alt
        public XHEInterface get_by_alt(string alt, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("alt",alt,exactly,frame);

            string[,] aParams = new string[,] { { "alt", alt }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� value
        public XHEInterface get_by_value(string value, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("value",value,exactly,frame);

            string[,] aParams = new string[,] { { "value", value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // �������� ��������� ������� �� �������� ���������
        public XHEInterface get_by_attribute(string attr_name,string attr_value, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute(attr_name,attr_value,exactly,frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
	// �������� ��������� ������� �� �������� ������� : name1;value1;exactly1; ... nameN;valueN;exactlyN;
	public XHEInterface get_by_properties(string properties,string frame="-1")
	{
            	string[,] aParams = new string[,] { { "properties", properties } ,  { "frame", frame } };
            	string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            	return new XHEInterface(internal_number,m_Server,m_Password);
	}	
        // �������� ��������� ������� �� xpath
        public XHEInterface get_by_xpath(string xpath)
        {
            wait_element_exist_by_xpath(xpath);

            string[,] aParams = new string[,] { { "xpath", xpath } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	


        // �������� ��� ��������
        public XHEInterfaces get_all(string frame="-1")
        {
            string[,] aParams = new string[,] {  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }

        // �������� ��� �������� c ��������� ��������
        public XHEInterfaces get_all_by_number(string numbers,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "numbers", numbers }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� inner text
        public XHEInterfaces get_all_by_inner_text(string inner_text, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "inner_text", inner_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� inner html
        public XHEInterfaces get_all_by_inner_html(string inner_html, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "inner_html", inner_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� outer text
        public XHEInterfaces get_all_by_outer_text(string outer_text, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "outer_text", outer_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� outer html
        public XHEInterfaces get_all_by_outer_html(string outer_html, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "outer_html", outer_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� ������
        public XHEInterfaces get_all_by_name(string name, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] { { "name", name }, { "exactly", exactly.ToString() }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
            // �������� ��� �������� c �������� id
        public XHEInterfaces get_all_by_id(string id, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "id", id }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� src
        public XHEInterfaces get_all_by_src(string src, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "src", src }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� href
        public XHEInterfaces get_all_by_href(string href, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "href", href }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
            // �������� ��� �������� c �������� alt
        public XHEInterfaces get_all_by_alt(string alt, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "alt", alt }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // �������� ��� �������� c �������� value
        public XHEInterfaces get_all_by_value(string value, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "value", value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // �������� ��� �������� c �������� ��������� ���������
        public XHEInterfaces get_all_by_attribute(string attr_name,string attr_value, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // �������� ��� �������� �� xparg
        public XHEInterfaces get_all_by_xpath(string xpath)
        {
            string[,] aParams = new string[,] { { "xpath", xpath } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // �������� ��� �������� c ��������� ���������� �������
        public XHEInterfaces get_all_by_properties(string properties,string frame="-1")
        {
	    string[,] aParams = new string[,] { { "properties", properties }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }

    };
}