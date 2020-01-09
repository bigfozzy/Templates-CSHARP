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
    ///////////////////////////////////////////// Общее для всех DOM ////////////////////////////////////////////
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

        // нажать, используя номер
        public bool click_by_number(int number, string frame = "-1")
        {
            return z_click_by_number(number, frame);
        }
        // нажать, используя имя
        public bool click_by_name(string name, string frame = "-1")
        {
            return z_click_by_name(name, frame);
        }
        // нажать, используя id
        public bool click_by_id(string id, int exactly = 1, string frame = "-1")
        {
            return z_click_by_id(id, exactly, frame);
        }
        // нажать, используя value
        public bool click_by_value(string value, int exactly = 1, string frame = "-1")
        {
            return z_click_by_value(value, exactly, frame);
        }
        // нажать, используя alt
        public bool click_by_alt(string alt, int exactly = 1, string frame = "-1")
        {
            return z_click_by_alt(alt, exactly, frame);
        }
        // нажать, используя src
        public bool click_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_click_by_src(src, exactly, frame);
        }
        // нажать, используя href
        public bool click_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_click_by_href(href, exactly, frame);
        }
        // нажать, используя внутренний текст
        public bool click_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_click_by_inner_text(text, exactly, frame);
        }
        // нажать, используя внутренний хтмл
        public bool click_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_click_by_inner_html(inner_html, exactly, frame);
        }
        // нажать, используя значение атрибута
        public bool click_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_click_by_attribute(attr_name, attr_value, exactly, frame);
        }
        // нажать, используя номер, в форме с заданным номером
        public bool click_by_number_by_form_number(int number, int form_number, string frame = "-1")
        {
            return z_click_by_number_by_form_number(number, form_number, frame);
        }
        // нажать, используя имя, в форме с заданным номером
        public bool click_by_name_by_form_number(string name, int form_number, string frame = "-1")
        {
            return z_click_by_name_by_form_number(name, form_number, frame);
        }
        // нажать, используя значение аттрибута, в форме с заданным номером
        public bool click_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, int form_number, string frame = "-1")
        {
            return z_click_by_attribute_by_form_number(attr_name, attr_value, exactly, form_number, frame);
        }
        // нажать, используя номер, в форме с заданным именем
        public bool click_by_number_by_form_name(int number, string form_name, string frame = "-1")
        {
            return z_click_by_number_by_form_name(number, form_name, frame);
        }
        // нажать, используя имя, в форме с заданным именем
        public bool click_by_name_by_form_name(string name, string form_name, string frame = "-1")
        {
            return z_click_by_name_by_form_name(name, form_name, frame);
        }
        // нажать, используя значение аттрибута, в форме с заданным именем
        public bool click_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string form_name, string frame = "-1")
        {
            return z_click_by_attribute_by_form_name(attr_name, attr_value, exactly, form_name, frame);
        }

        // нажать случайный элемент
        public int click_random(string frame = "-1")
        {
            return z_click_random(frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // послать событие по номеру
        public bool send_event_by_number(int number, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_number(number, event_, frame, wait_browser);
        }
        // послать событие по имени
        public bool send_event_by_name(string name, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_name(name, event_, frame, wait_browser);
        }
        // послать событие по id
        public bool send_event_by_id(string id, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_id(id, exactly, event_, frame, wait_browser);
        }
        // послать событие по урлу
        public bool send_event_by_href(string url, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_href(url, exactly, event_, frame, wait_browser);
        }
        // послать событие по внутреннему тексту
        public bool send_event_by_inner_text(string text, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_inner_text(text, exactly, event_, frame, wait_browser);
        }
        // послать событие по внутреннему хтмл
        public bool send_event_by_inner_html(string html, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_inner_html(html, exactly, event_, frame, wait_browser);
        }
        // послать событие по атрибуту
        public bool send_event_by_attribute(string atr_name, string atr_value, int exactly, string event_, string frame = "-1",bool wait_browser=true)
        {
            return z_send_event_by_attribute(atr_name, atr_value, exactly, event_, frame, wait_browser);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // установить фокус, используя номер
        public bool set_focus_by_number(int number, string frame = "-1")
        {
            return z_set_focus_by_number(number, frame);
        }
        // установить фокус, используя имя
        public bool set_focus_by_name(string name, string frame = "-1")
        {
            return z_set_focus_by_name(name, frame);
        }
        // установить фокус, используя href
        public bool set_focus_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_href(href, exactly, frame);
        }
        // установить фокус, используя внутренний текст
        public bool set_focus_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_inner_text(inner_text, exactly, frame);
        }
        // установить фокус, используя внутренний хтмл
        public bool set_focus_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_inner_html(inner_html, exactly, frame);
        }
        // установить фокус, используя значение аттрибута
        public bool set_focus_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_set_focus_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // задать значение элементу по его номеру
        public bool set_value_by_number(int number, string value, string frame = "-1")
        {
            return z_set_value_by_number(number, value, frame);
        }
        // задать значение элементу по его имени
        public bool set_value_by_name(string name, string value, string frame = "-1")
        {
            return z_set_value_by_name(name, value, frame);
        }
        // задать значение элементу по его аттрибуту
        public bool set_value_by_attribute(string attr_name, string attr_value, int exactly, string value, string frame = "-1")
        {
            return z_set_value_by_attribute(attr_name, attr_value, exactly, value, frame);
        }

        // задать значение элементу по номеру, в форме с заданным номером
        public bool set_value_by_number_by_form_number(int number, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_number_by_form_number(number, value, form_number, frame);
        }
        // задать значение элементу по имени, в форме с заданным номером
        public bool set_value_by_name_by_form_number(string name, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_name_by_form_number(name, value, form_number, frame);
        }
        // задать значение элементу по значению аттрибута, в форме с заданным номером
        public bool set_value_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, string value, int form_number, string frame = "-1")
        {
            return z_set_value_by_attribute_by_form_number(attr_name, attr_value, exactly, value, form_number, frame);
        }

        // задать значение элементу по номеру, в форме с заданным именем
        public bool set_value_by_number_by_form_name(int number, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_number_by_form_name(number, value, form_name, frame);
        }
        // задать значение элементу по имени, в форме с заданным именем
        public bool set_value_by_name_by_form_name(string name, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_name_by_form_name(name, value, form_name, frame);
        }
        // задать значение элементу по значению аттрибута, в форме с заданным именем
        public bool set_value_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string value, string form_name, string frame = "-1")
        {
            return z_set_value_by_attribute_by_form_name(attr_name, attr_value, exactly, value, form_name, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // установить внутренний текст, используя номер
        public bool set_inner_text_by_number(int number, string text, string frame = "-1")
        {
            return z_set_inner_text_by_number(number, text, frame);
        }
        // установить внутренний текст, используя имя
        public bool set_inner_text_by_name(string name, string text, string frame = "-1")
        {
            return z_set_inner_text_by_name(name, text, frame);
        }
        // установить внутренний текст, используя значение аттрибута
        public bool set_inner_text_by_attribute(string attr_name, string attr_value, string text, int exactly = 1, string frame = "-1")
        {
            return z_set_inner_text_by_attribute(attr_name, attr_value, exactly, text, frame);
        }

        // установить внутренний html, используя номер
        public bool set_inner_html_by_number(int number, string html, string frame = "-1")
        {
            return z_set_inner_html_by_number(number, html, frame);
        }
        // установить внутренний html, используя имя
        public bool set_inner_html_by_name(string name, string html, string frame = "-1")
        {
            return z_set_inner_html_by_name(name, html, frame);
        }
        // установить внутренний html, используя значение аттрибута
        public bool set_inner_html_by_attribute(string attr_name, string attr_value, string html, int exactly = 1, string frame = "-1")
        {
            return z_set_inner_html_by_attribute(attr_name, attr_value, exactly, html, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // добавить атрибут, используя номер
        public bool add_attribute_by_number(int number, string name_attr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_number(number, name_attr, value_attr, frame);
        }
        // добавить атрибут, используя имя
        public bool add_attribute_by_name(string name, string name_attr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_name(name, name_attr, value_attr, frame);
        }
        // добавить аттрибут, используя внутренний текст
        public bool add_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_inner_text(inner_text, exactly, name_atr, value_attr, frame);
        }
        // добавить аттрибут, используя внутренний html
        public bool add_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_inner_html(inner_html, exactly, name_atr, value_attr, frame);
        }
        // добавить аттрибут, используя значение аттрибута
        public bool add_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string value_attr, string frame = "-1")
        {
            return z_add_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, value_attr, frame);
        }

        //  задать значение аттрибута, используя номер
        public bool set_attribute_by_number(int number, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_number(number, name_atr, value_atr, frame);
        }
        // задать значение аттрибута, используя имя
        public bool set_attribute_by_name(string name, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_name(name, name_atr, value_atr, frame);
        }
        // задать значение аттрибута, используя внутренний текст
        public bool set_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_inner_text(inner_text, exactly, name_atr, value_atr, frame);
        }
        // задать значение аттрибута, используя внутренний html
        public bool set_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_inner_html(inner_html, exactly, name_atr, value_atr, frame);
        }
        // задать значение аттрибута, используя значение аттрибута
        public bool set_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string value_atr, string frame = "-1")
        {
            return z_set_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, value_atr, frame);
        }

        // удалить атрибут, используя номер
        public bool remove_attribute_by_number(int number, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_number(number, name_atr, frame);
        }
        // удалить атрибут, используя имя
        public bool remove_attribute_by_name(string name, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_name(name, name_atr, frame);
        }
        // удалить аттрибут, используя внутренний текст
        public bool remove_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_inner_text(inner_text, exactly, name_atr, frame);
        }
        // удалить аттрибут, используя внутренний html
        public bool remove_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_inner_html(inner_html, exactly, name_atr, frame);
        }
        // удалить аттрибут, используя значение аттрибута
        public bool remove_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string frame = "-1")
        {
            return z_remove_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // скриншот, используя номер
        public bool screenshot_by_number(string file_path, int number, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_number(file_path, number, frame, as_gray);
        }
        // скриншот, используя имя
        public bool screenshot_by_name(string file_path, string name, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_name(file_path, name, frame, as_gray);
        }
        // скриншот, используя src
        public bool screenshot_by_src(string file_path, string src, int exactly = 1, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_src(file_path, src, exactly, frame, as_gray);
        }
        // скриншот, используя значение аттрибута
        public bool screenshot_by_attribute(string file_path, string atr_name, string atr_value, int exactly = 1, string frame = "-1", bool as_gray = false)
        {
            return z_screenshot_by_attribute(file_path, atr_name, atr_value, exactly, frame, as_gray);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить, есть ли элемент с заданным номером
        public bool is_exist_by_number(int number, string frame = "-1")
        {
            return z_is_exist_by_number(number, frame);
        }
        // проверить, есть ли элемент с заданным именем
        public bool is_exist_by_name(string name, string frame = "-1")
        {
            return z_is_exist_by_name(name, frame);
        }
        // проверить, есть ли элемент с заданным id
        public bool is_exist_by_id(string id, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_id(id, exactly, frame);
        }
        // проверить, есть ли элемент с заданным href
        public bool is_exist_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_href(href, exactly, frame);
        }
        // проверить, есть ли элемент с заданным alt
        public bool is_exist_by_alt(string alt, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_alt(alt, exactly, frame);
        }
        // проверить, есть ли элемент с заданным src
        public bool is_exist_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_src(src, exactly, frame);
        }
        // проверить, есть ли элемент с заданным внутренним текстом 
        public bool is_exist_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_inner_text(inner_text, exactly, frame);
        }
        // проверить, есть ли элемент с заданным внутренним хтмл 
        public bool is_exist_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_inner_html(inner_html, exactly, frame);
        }
        // проверить есть ли элемент с заданным значением атрибута
        public bool is_exist_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_is_exist_by_attribute(atr_name, atr_value, exactly, frame);
        }
        // проверить есть ли элемент с заданным xpath
        public bool is_exist_by_xpath(string xpath)
        {
            return z_is_exist_by_xpath(xpath);
        }

        // проверить есть ли элемент с заданным значением атрибута в форме с заданным номером
        public bool is_exist_by_attribute_by_form_number(string atr_name, string atr_value, int exactly, int form_number, string frame = "-1")
        {
            return z_is_exist_by_attribute_by_form_number(atr_name, atr_value, exactly, form_number, frame);
        }
        // проверить есть ли элемент с заданным значением атрибута в форме с заданным именем
        public bool is_exist_by_attribute_by_form_name(string atr_name, string atr_value, int exactly, string form_name, string frame = "-1")
        {
            return z_is_exist_by_attribute_by_form_name(atr_name, atr_value, exactly, form_name, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить номер по имени
        public int get_number_by_name(string name, string frame = "-1")
        {
            return z_get_number_by_name(name, frame);
        }
        // получить номер по id
        public int get_number_by_id(string id, string frame = "-1")
        {
            return z_get_number_by_id(id, frame);
        }
        // получить номер по src
        public int get_number_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_src(src, exactly, frame);
        }
        // получить номер по href
        public int get_number_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_href(href, exactly, frame);
        }
        // получить номер по внутреннему тексту
        public int get_number_by_inner_text(string innertext, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_inner_text(innertext, exactly, frame);
        }
        // получить номер по внутреннему html
        public int get_number_by_inner_html(string innerhtml, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_inner_html(innerhtml, exactly, frame);
        }
        // получить номер по значению атрибута
        public int get_number_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_number_by_attribute(atr_name, atr_value, exactly, frame);
        }

        // получить имя по номеру
        public string get_name_by_number(int number, string frame = "-1")
        {
            return z_get_name_by_number(number, frame);
        }

        // получить значение атрибута по номеру
        public string get_attribute_by_number(int number, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_number(number, name_atr, frame);
        }
        // получить значение атрибута по имени
        public string get_attribute_by_name(string name, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_name(name, name_atr, frame);
        }
        // получить значение атрибута по src
        public string get_attribute_by_src(string src, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_src(src, exactly, name_atr, frame);
        }
        // получить значение атрибута по внутреннему тексту
        public string get_attribute_by_inner_text(string inner_text, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_inner_text(inner_text, exactly, name_atr, frame);
        }
        // получить значение атрибута по внутреннему html
        public string get_attribute_by_inner_html(string inner_html, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_inner_html(inner_html, exactly, name_atr, frame);
        }
        // получить значение атрибута по атрибуту
        public string get_attribute_by_attribute(string atr_name, string atr_value, int exactly, string name_atr, string frame = "-1")
        {
            return z_get_attribute_by_attribute(atr_name, atr_value, exactly, name_atr, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить value по номеру
        public string get_value_by_number(int number, string frame = "-1")
        {
            return z_get_value_by_number(number, frame);
        }
        // получить value по имени
        public string get_value_by_name(string name, string frame = "-1")
        {
            return z_get_value_by_name(name, frame);
        }
        // получить value по аттрибуту
        public string get_value_by_attribute(string atr_name, string atr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_value_by_attribute(atr_name, atr_value, exactly, frame);
        }

        // получить src по номеру
        public string get_src_by_number(int number, string frame = "-1")
        {
            return z_get_src_by_number(number, frame);
        }
        // получить src по имени
        public string get_src_by_name(string name, string frame = "-1")
        {
            return z_get_src_by_name(name, frame);
        }

        // получить alt по номеру
        public string get_alt_by_number(int number, string frame = "-1")
        {
            return z_get_alt_by_number(number, frame);
        }
        // получить alt по имени
        public string get_alt_by_name(string name, string frame = "-1")
        {
            return z_get_alt_by_name(name, frame);
        }

        // получить href по номеру
        public string get_href_by_number(int number, string frame = "-1")
        {
            return z_get_href_by_number(number, frame);
        }
        // получить href по имени
        public string get_href_by_name(string name, string frame = "-1")
        {
            return z_get_href_by_name(name, frame);
        }
        // получить href по внутреннему тексту
        public string get_href_by_inner_text(string inner_text, int exactly = 1, string frame = "-1")
        {
            return z_get_href_by_inner_text(inner_text, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить внутренний текст по номеру
        public string get_inner_text_by_number(int number, string frame = "-1")
        {
            return z_get_inner_text_by_number(number, frame);
        }
        // получить внутренний текст по имени
        public string get_inner_text_by_name(string name, string frame = "-1")
        {
            return z_get_inner_text_by_name(name, frame);
        }
        // получить внутренний текст по id
        public string get_inner_text_by_id(string id, string frame = "-1")
        {
            return z_get_inner_text_by_id(id, frame);
        }
        // получить внутренний текст по href
        public string get_inner_text_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_text_by_href(href, exactly, frame);
        }
        // получить внутренний текст по значению аттрибута
        public string get_inner_text_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_text_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить внутренний html по номеру
        public string get_inner_html_by_number(int number, string frame = "-1")
        {
            return z_get_inner_html_by_number(number, frame);
        }
        // получить внутренний html по имени
        public string get_inner_html_by_name(string name, string frame = "-1")
        {
            return z_get_inner_html_by_name(name, frame);
        }
        // получить внутренний html по id
        public string get_inner_html_by_id(string id, string frame = "-1")
        {
            return z_get_inner_html_by_id(id, frame);
        }
        // получить внутренний html по значению аттрибута
        public string get_inner_html_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_inner_html_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // проверить доступность элемента по номеру
        public bool is_disabled_by_number(int number, string frame = "-1")
        {
            return z_is_disabled_by_number(number, frame);
        }
        // проверить доступность элемента по имени
        public bool is_disabled_by_name(string name, string frame = "-1")
        {
            return z_is_disabled_by_name(name, frame);
        }

        // получить все аттрибуты элемента по его номеру
        public string get_all_attributes_by_number(int number, string frame = "-1")
        {
            return z_get_all_attributes_by_number(number, frame);
        }
        // получить все аттрибуты элемента по его имени
        public string get_all_attributes_by_name(string name, string frame = "-1")
        {
            return z_get_all_attributes_by_name(name, frame);
        }
        // получить все аттрибуты элемента по src
        public string get_all_attributes_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_attributes_by_src(src, exactly, frame);
        }

        // получить все значения атрибутов элемента по его номеру
        public string get_all_attributes_values_by_number(int number, string frame = "-1")
        {
            return z_get_all_attributes_values_by_number(number, frame);
        }
        // получить все значения атрибутов элемента по его имени
        public string get_all_attributes_values_by_name(string name, string frame = "-1")
        {
            return z_get_all_attributes_values_by_name(name, frame);
        }
        // получить все значения атрибутов элемента по src
        public string get_all_attributes_values_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_attributes_values_by_src(src, exactly, frame);
        }

        // получить все события элемента по его номеру
        public string get_all_events_by_number(int number, string frame = "-1")
        {
            return z_get_all_events_by_number(number, frame);
        }
        // получить все события элемента по его имени
        public string get_all_events_by_name(string name, string frame = "-1")
        {
            return z_get_all_events_by_name(name, frame);
        }
        // получить все события элемента по src
        public string get_all_events_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_all_events_by_src(src, exactly, frame);
        }

        // получить номера дочерних элементов по его номеру
        public string get_numbers_child_by_number(int number, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_number(number, element_type, frame, include_subchildren);
        }
        // получить номера дочерних элементов по его имени
        public string get_numbers_child_by_name(string name, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_name(name, element_type, frame, include_subchildren);
        }
        // получить номера дочерних элементов по его id
        public string get_numbers_child_by_id(string id, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_id(id, element_type, frame, include_subchildren);
        }
        // получить номера дочерних элементов по значению его аттрибута
        public string get_numbers_child_by_attribute(string attr_name, string attr_value, int exactly = 1, string element_type = "", string frame = "-1", bool include_subchildren = false)
        {
            return z_get_numbers_child_by_attribute(attr_name, attr_value, exactly, element_type, frame, include_subchildren);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить X левого верхнего угла элемента по номеру
        public int get_x_by_number(int number, string frame = "-1")
        {
            return z_get_x_by_number(number, frame);
        }
        // получить X левого верхнего угла элемента по имени
        public int get_x_by_name(string name, string frame = "-1")
        {
            return z_get_x_by_name(name, frame);
        }
        // получить X левого верхнего угла элемента по href
        public int get_x_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_href(href, exactly, frame);
        }
        // получить X левого верхнего угла элемента по внутрененму тексту
        public int get_x_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_inner_text(text, exactly, frame);
        }
        // получить X левого верхнего угла элемента по внутреннему html
        public int get_x_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_inner_html(inner_html, exactly, frame);
        }
        // получить X левого верхнего угла элемента по значению атрибута
        public int get_x_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_x_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить Y левого верхнего угла элемента по номеру
        public int get_y_by_number(int number, string frame = "-1")
        {
            return z_get_y_by_number(number, frame);
        }
        // получить Y левого верхнего угла элемента по имени
        public int get_y_by_name(string name, string frame = "-1")
        {
            return z_get_y_by_name(name, frame);
        }
        // получить Y левого верхнего угла элемента по href
        public int get_y_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_href(href, exactly, frame);
        }
        // получить Y левого верхнего угла элемента по внутрененму тексту
        public int get_y_by_inner_text(string text, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_inner_text(text, exactly, frame);
        }
        // получить Y левого верхнего угла элемента по внутреннему html
        public int get_y_by_inner_html(string inner_html, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_inner_html(inner_html, exactly, frame);
        }
        // получить Y левого верхнего угла элемента по значению атрибута
        public int get_y_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_y_by_attribute(attr_name, attr_value, exactly, frame);
        }

        //////////////////////////////////// GET SIZES /////////////////////////////////////////

        // получить ширину элемента по номеру
        public int get_width_by_number(int number, string frame = "-1")
        {
            return z_get_width_by_number(number, frame);
        }
        // получить ширину элемента по имени
        public int get_width_by_name(string name, string frame = "-1")
        {
            return z_get_width_by_name(name, frame);
        }
        // получить ширину элемента по src
        public int get_width_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_src(src, exactly, frame);
        }
        // получить ширину элемента по href
        public int get_width_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_href(href, exactly, frame);
        }
        // получить ширину элемента по значению атрибута
        public int get_width_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_width_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить высоту элемента по номеру
        public int get_height_by_number(int number, string frame = "-1")
        {
            return z_get_height_by_number(number, frame);
        }
        // получить высоту элемента по имени
        public int get_height_by_name(string name, string frame = "-1")
        {
            return z_get_height_by_name(name, frame);
        }
        // получить высоту элемента по src
        public int get_height_by_src(string src, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_src(src, exactly, frame);
        }
        // получить высоту элемента по href
        public int get_height_by_href(string href, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_href(href, exactly, frame);
        }
        // получить высоту элемента по значению атрибута
        public int get_height_by_attribute(string attr_name, string attr_value, int exactly = 1, string frame = "-1")
        {
            return z_get_height_by_attribute(attr_name, attr_value, exactly, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // эмуляция ввода с клавиатуры в элемент с заданным номером
        public bool send_keyboard_input_by_number(int number, string string_, int timeout=60, string frame = "-1")
        {
            return z_send_keyboard_input_by_number(number, string_, timeout, frame);
        }
        // эмуляция ввода с клавиатуры в элемент с заданным именем
        public bool send_keyboard_input_by_name(string name, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_name(name, string_, timeout, frame);
        }
        // эмуляция ввода с клавиатуры в элемент по внутреннему тексту
        public bool send_keyboard_input_by_inner_text(string inner_text, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_inner_text(inner_text, exactly, string_, timeout, frame);
        }
        // эмуляция ввода с клавиатуры в элемент по внутреннему html
        public bool send_keyboard_input_by_inner_html(string inner_html, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_inner_html(inner_html, exactly, string_, timeout, frame);
        }
        // эмуляция ввода с клавиатуры в элемент по значению аттрибута
        public bool send_keyboard_input_by_attribute(string attr_name, string attr_value, int exactly, string string_, int timeout = 60, string frame = "-1")
        {
            return z_send_keyboard_input_by_attribute(attr_name, attr_value, exactly, string_, timeout, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить число элементов на странице
        public int get_count(string frame = "-1")
        {
            return z_get_count(frame);
        }
        // получить число элементов на странице c заданным значением аттрибута
        public int get_count_by_attribute(string attr_name, string attr_value, int exactly = 0,string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить номера всех элементов с заданным внутренним текстом
        public string[] get_all_numbers_by_inner_text(string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_inner_text(text, exactly, frame);
        }
        // получить номера всех элементов с заданным внутренним хтмл
        public string[] get_all_numbers_by_inner_html(string html, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_inner_html(html, exactly, frame);
        }
        // получить номера всех элементов с заданным значением аттрибута
        public string[] get_all_numbers_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_numbers_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить все внутренние тексты всех элементов с заданным внутренним текстом
        public string get_all_inner_texts(string separator = "<br>", string text_filter = "", string frame = "-1")
        {
            return z_get_all_inner_texts(separator, text_filter, frame);
        }
        // получить все внутренние тексты всех элементов с зададнным значением аттрибутов
        public string[] get_all_inner_texts_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_texts_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить все внутренние html всех элементов с заданным внутренним текстом
        public string[] get_all_inner_htmls_by_inner_text(string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_htmls_by_inner_text(text, exactly, frame);
        }
        // получить все внутренние html всех элементов с заданным значением аттрибута
        public string[] get_all_inner_htmls_by_attribute(string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_inner_htmls_by_attribute(attr_name, attr_value, exactly, frame);
        }

        // получить все значения аттрибута всех элементов с заданным внутренним текстом
        public string[] get_all_attributes_by_inner_text(string attr_name_need, string text, int exactly = 0, string frame = "-1")
        {
            return z_get_all_attributes_by_inner_text(attr_name_need, text, exactly, frame);
        }
        // получить все значения аттрибута всех элементов по значению аттрибута
        public string[] get_all_attributes_by_attribute(string attr_name_need, string attr_name, string attr_value, int exactly = 0, string frame = "-1")
        {
            return z_get_all_attributes_by_attribute(attr_name_need, attr_name, attr_value, exactly, frame);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить интерфейс объекта по номеру
        public XHEInterface get_by_number(int number,string frame="-1")
        {
            wait_element_exist_by_number(number,frame);

            string[,] aParams = new string[,] { { "number", number.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по имени
        public XHEInterface get_by_name(string name,string frame="-1")
        {
            wait_element_exist_by_name(name,frame);

            string[,] aParams = new string[,] { { "name", name },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по внутреннему тексту
        public XHEInterface get_by_inner_text(string inner_text, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_inner_text(inner_text,exactly,frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по внутреннему хтмл
        public XHEInterface get_by_inner_html(string inner_html, int exactly =0,string frame="-1")
        {
            wait_element_exist_by_inner_html(inner_html,exactly,frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по внешнему тексту
        public XHEInterface get_by_outer_text(string outer_text, int exactly = 0,string frame="-1")
        {
            wait_element_exist_by_outer_text(outer_text,exactly,frame);

            string[,] aParams = new string[,] { { "outer_text", outer_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по внешнему хтмл
        public XHEInterface get_by_outer_html(string outer_html, int exactly = 0,string frame="-1")
        {
            wait_element_exist_by_outer_html(outer_html,exactly,frame);

            string[,] aParams = new string[,] { { "outer_html", outer_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по id
        public XHEInterface get_by_id(string id, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("id",id,exactly,frame);

            string[,] aParams = new string[,] { { "id", id }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по src
        public XHEInterface get_by_src(string src, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("src",src,exactly,frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по href
        public XHEInterface get_by_href(string href, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("href",href,exactly,frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number, m_Server, m_Password);
        }	
        // получить интерфейс объекта по alt
        public XHEInterface get_by_alt(string alt, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("alt",alt,exactly,frame);

            string[,] aParams = new string[,] { { "alt", alt }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по value
        public XHEInterface get_by_value(string value, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute("value",value,exactly,frame);

            string[,] aParams = new string[,] { { "value", value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
        // получить интерфейс объекта по значению аттрибута
        public XHEInterface get_by_attribute(string attr_name,string attr_value, int exactly = 1,string frame="-1")
        {
            wait_element_exist_by_attribute(attr_name,attr_value,exactly,frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	
	// получить интерфейс объекта по значению свойств : name1;value1;exactly1; ... nameN;valueN;exactlyN;
	public XHEInterface get_by_properties(string properties,string frame="-1")
	{
            	string[,] aParams = new string[,] { { "properties", properties } ,  { "frame", frame } };
            	string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            	return new XHEInterface(internal_number,m_Server,m_Password);
	}	
        // получить интерфейс объекта по xpath
        public XHEInterface get_by_xpath(string xpath)
        {
            wait_element_exist_by_xpath(xpath);

            string[,] aParams = new string[,] { { "xpath", xpath } };
            string internal_number = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterface(internal_number,m_Server,m_Password);
        }	


        // получить все элементы
        public XHEInterfaces get_all(string frame="-1")
        {
            string[,] aParams = new string[,] {  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }

        // получить все элементы c заданными номерами
        public XHEInterfaces get_all_by_number(string numbers,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "numbers", numbers }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным inner text
        public XHEInterfaces get_all_by_inner_text(string inner_text, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "inner_text", inner_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным inner html
        public XHEInterfaces get_all_by_inner_html(string inner_html, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "inner_html", inner_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным outer text
        public XHEInterfaces get_all_by_outer_text(string outer_text, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "outer_text", outer_text }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным outer html
        public XHEInterfaces get_all_by_outer_html(string outer_html, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "outer_html", outer_html }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным именем
        public XHEInterfaces get_all_by_name(string name, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] { { "name", name }, { "exactly", exactly.ToString() }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
            // получить все элементы c заданным id
        public XHEInterfaces get_all_by_id(string id, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "id", id }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным src
        public XHEInterfaces get_all_by_src(string src, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "src", src }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным href
        public XHEInterfaces get_all_by_href(string href, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "href", href }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
            // получить все элементы c заданным alt
        public XHEInterfaces get_all_by_alt(string alt, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "alt", alt }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }	
        // получить все элементы c заданным value
        public XHEInterfaces get_all_by_value(string value, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] {  { "value", value }, { "exactly", exactly.ToString() },  { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // получить все элементы c заданным значением аттрибута
        public XHEInterfaces get_all_by_attribute(string attr_name,string attr_value, int exactly =0,string frame="-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // получить все элементы по xparg
        public XHEInterfaces get_all_by_xpath(string xpath)
        {
            string[,] aParams = new string[,] { { "xpath", xpath } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }
        // получить все элементы c заданными значениями свойств
        public XHEInterfaces get_all_by_properties(string properties,string frame="-1")
        {
	    string[,] aParams = new string[,] { { "properties", properties }, { "frame", frame } };
            string internal_numbers = call_get(MethodBase.GetCurrentMethod().Name, aParams);

            return new XHEInterfaces(internal_numbers,m_Server,m_Password);
        }

    };
}