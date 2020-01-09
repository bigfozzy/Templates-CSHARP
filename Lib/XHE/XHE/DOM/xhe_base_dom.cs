using System;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////// common for all DOM elements ////////////////////////////
    public class XHEBaseDOM : XHEBaseObject
    {
        // check exist of element before action
        public static bool bWaitElementExistBeforeAction=true;
        // time of waiting for element appearing (second)
        public static int  iSecondsWaitElementExistBeforeAction=15;

        // initialization
        public XHEBaseDOM(string server, string password = "")
            : base(server, password)
        {
        }

        // check and wait element exist by number
        public bool wait_element_exist_by_number(int number, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
               bool is_exist = z_is_exist_by_number(number,frame);
               while(!is_exist)
               {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_number(number,frame);
                    fSec+=0.500f;
                    if (fSec > iSecondsWaitElementExistBeforeAction)
                        return false;
               }
            }
            return true;
        }
        // check and wait element exist by name
        public bool wait_element_exist_by_name(string name, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_name(name,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_name(name,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;	
               }
            }
            return true;
        }
        // check and wait element exist by id
        public bool wait_element_exist_by_id(string id, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_id(id, exactly, frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_id(id, exactly, frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;	
               }
            }
            return true;
        }
        // check and wait element exist by inner text
        public bool wait_element_exist_by_inner_text(string inner_text, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_inner_text(inner_text,exactly,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_inner_text(inner_text,exactly,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        break;	
                }
            }
            return true;
        }
        // check and wait element exist by inner html
        public bool wait_element_exist_by_inner_html(string inner_html, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_inner_html(inner_html,exactly,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_inner_html(inner_html,exactly,frame);
                    fSec+=0.50f;
                    if (fSec > iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }
        // check and wait element exist by outer text
        public bool wait_element_exist_by_outer_text(string outer_text, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_outer_text(outer_text,exactly,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_outer_text(outer_text,exactly,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        break;	
                }
            }
            return true;
        }
        // check and wait element exist by outer html
        public bool wait_element_exist_by_outer_html(string outer_html, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_outer_html(outer_html,exactly,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_outer_html(outer_html,exactly,frame);
                    fSec+=0.50f;
                    if (fSec > iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }
        // check and wait element exist by attribute
        public bool wait_element_exist_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_attribute(attr_name,attr_value,exactly,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_attribute(attr_name,attr_value,exactly,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }
        // check and wait element exist by xpath
        public bool wait_element_exist_by_xpath(string xpath)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_xpath(xpath);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_xpath(xpath);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }
        // check and wait element exist by attribute in form by name
        public bool wait_element_exist_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string form_name, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_attribute_by_form_name(attr_name,attr_value,exactly,form_name,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_attribute_by_form_name(attr_name,attr_value,exactly,form_name,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }
        // check and wait element exist by attribute in form by number
        public bool wait_element_exist_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, int form_number, string frame)
        {
            float fSec=0;
            if (bWaitElementExistBeforeAction)
            {
                bool is_exist = z_is_exist_by_attribute_by_form_number(attr_name,attr_value,exactly,form_number,frame);
                while(!is_exist)
                {
                    Thread.Sleep(500);
                    is_exist = z_is_exist_by_attribute_by_form_number(attr_name,attr_value,exactly,form_number,frame);
                    fSec+=0.50f;
                    if (fSec>iSecondsWaitElementExistBeforeAction)
                        return false;
                }
            }
            return true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // click on element by name
        protected bool z_click_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by number 
        protected bool z_click_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by id
        protected bool z_click_by_id(string id, int exactly, string frame)
        {
            wait_element_exist_by_attribute("id", id, exactly, frame);

            string[,] aParams = new string[,] { { "id", id }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by value
        protected bool z_click_by_value(string value, int exactly, string frame)
        {
            wait_element_exist_by_attribute("value", value, exactly, frame);

            string[,] aParams = new string[,] { { "value", value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by href
        protected bool z_click_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by alt
        protected bool z_click_by_alt(string alt, int exactly, string frame)
        {
            wait_element_exist_by_attribute("alt", alt, exactly, frame);

            string[,] aParams = new string[,] { { "alt", alt }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by src
        protected bool z_click_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by inner text
        protected bool z_click_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by inner html
        protected bool z_click_by_inner_html(string inner_html, int exactly, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by any attribute
        protected bool z_click_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on all elements (no wait exist mode)
        protected bool z_click_all(string frame)
        {
            string[,] aParams = new string[,] { { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on random element (no wait exist mode)
        protected int z_click_random(string frame)
        {
            string[,] aParams = new string[,] { { "frame", frame } };
            int res = call_int(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == -1)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by name (no wait exist mode)
        protected bool z_click_by_name_and_value(string name, string value, string frame)
        {
            string[,] aParams = new string[,] { { "name", name }, { "value", value }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // click by name in form by name
        protected bool z_click_by_name_by_form_name(string name, string form_name, string frame)
        {
            string[,] aParams = new string[,] { { "name", name }, { "form_name", form_name }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by name in form by number
        protected bool z_click_by_name_by_form_number(string name, int form_number, string frame)
        {
            string[,] aParams = new string[,] { { "name", name }, { "form_number", form_number.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        // click by number in form by name (no wait exist mode)
        protected bool z_click_by_number_by_form_name(int number, string form_name, string frame)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "form_name", form_name }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by number in form by number (no wait exist mode)
        protected bool z_click_by_number_by_form_number(int number, int form_number, string frame)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        // click by attribute in form by name
        protected bool z_click_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string form_name, string frame)
        {
            wait_element_exist_by_attribute_by_form_name(attr_name, attr_value, exactly, form_name, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "form_name", form_name }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click by attribute in form by number
        protected bool z_click_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, int form_number, string frame)
        {
            wait_element_exist_by_attribute_by_form_number(attr_name, attr_value, exactly, form_number, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // click on element by name
        protected bool z_click_in_by_name(string name, int x, int y, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "x", x.ToString() }, { "y", y.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by number
        protected bool z_click_in_by_number(int number, int x, int y, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by src
        protected bool z_click_in_by_src(string src, int exactly, int x, int y, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // click on element by any attribute
        protected bool z_click_in_by_attribute(string attr_name, string attr_value, int exactly, int x, int y, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "x", x.ToString() }, { "y", y.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // send event to element by name
        protected bool z_send_event_by_name(string name, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by id
        protected bool z_send_event_by_id(string id, int exactly, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_id(id, exactly, frame);

            string[,] aParams = new string[,] { { "id", id }, { "exactly", exactly.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by number 
        protected bool z_send_event_by_number(int number, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by href
        protected bool z_send_event_by_href(string href, int exactly, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by inner text
        protected bool z_send_event_by_inner_text(string inner_text, int exactly, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by inner html
        protected bool z_send_event_by_inner_html(string inner_html, int exactly, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }
        // send event to element by any attribute
        protected bool z_send_event_by_attribute(string attr_name, string attr_value, int exactly, string event_, string frame, bool wait_browser)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "event", event_ }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
            if (res && wait_browser)
            {
                GetBrowser().wait_for();
                Thread.Sleep(1000);
            }
            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // set focus to element by name
        protected bool z_set_focus_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set focus to element by name
        protected bool z_set_focus_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set focus to element by inner text
        protected bool z_set_focus_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set focus to element by inner html
        protected bool z_set_focus_by_inner_html(string inner_html, int exactly, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set focus to element by href
        protected bool z_set_focus_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set focus to element by attribute
        protected bool z_set_focus_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // set value by name
        protected bool z_set_value_by_name(string name, string value, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "value", value }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set value by number
        protected bool z_set_value_by_number(int number, string value, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "value", value }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set value by attribute
        protected bool z_set_value_by_attribute(string attr_name, string attr_value, int exactly, string value, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "value", value }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        // set value by name in form by form name
        protected bool z_set_value_by_name_by_form_name(string name, string value, string form_name, string frame)
        {
            wait_element_exist_by_attribute_by_form_name("name", name, 1, form_name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "value", value }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set value byname in form by form number
        protected bool z_set_value_by_name_by_form_number(string name, string value, int form_number, string frame)
        {
            wait_element_exist_by_attribute_by_form_number("name", name, 1, form_number, frame);

            string[,] aParams = new string[,] { { "name", name }, { "value", value }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        // set value by number in form by form name (no wait exist mode)
        protected bool z_set_value_by_number_by_form_name(int number, string value, string form_name, string frame)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "value", value }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set value by number in form by form number (no wait exist mode)
        protected bool z_set_value_by_number_by_form_number(int number, string value, int form_number, string frame)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "value", value }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        // set value by attribute in form by form name
        protected bool z_set_value_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string value, string form_name, string frame)
        {
            wait_element_exist_by_attribute_by_form_name(attr_name, attr_value, exactly, form_name, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "value", value }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set value by attribute in form by form number
        protected bool z_set_value_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, string value, int form_number, string frame)
        {
            wait_element_exist_by_attribute_by_form_number(attr_name, attr_value, exactly, form_number, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "value", value }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // set inner text by name
        protected bool z_set_inner_text_by_name(string name, string inner_text, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "inner_text", inner_text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set inner text by number 
        protected bool z_set_inner_text_by_number(int number, string inner_text, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "inner_text", inner_text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set inner text by any attribute
        protected bool z_set_inner_text_by_attribute(string attr_name, string attr_value, int exactly, string inner_text, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "inner_text", inner_text }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        // set inner html by name
        protected bool z_set_inner_html_by_name(string name, string inner_html, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "inner_html", inner_html }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set inner html by number 
        protected bool z_set_inner_html_by_number(int number, string inner_html, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "inner_html", inner_html }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }
        // set inner html by any attribute
        protected bool z_set_inner_html_by_attribute(string attr_name, string attr_value, int exactly, string inner_html, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "inner_html", inner_html }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams, 600);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // add (or set) attribute by name
        protected bool z_add_attribute_by_name(string name, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // add (or set) attribute by number
        protected bool z_add_attribute_by_number(int number, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // add (or set) attribute by inner text
        protected bool z_add_attribute_by_inner_text(string inner_text, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // add (or set) attribute by inner html
        protected bool z_add_attribute_by_inner_html(string inner_html, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // add (or set) attribute by attribute
        protected bool z_add_attribute_by_attribute(string attr_name, string attr_value, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // set any attribute by name
        protected bool z_set_attribute_by_name(string name, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // set any attribute by number
        protected bool z_set_attribute_by_number(int number, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // set any attribute by inner text
        protected bool z_set_attribute_by_inner_text(string inner_text, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // set any attribute by inner html
        protected bool z_set_attribute_by_inner_html(string inner_html, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // set any attribute by any attribute
        protected bool z_set_attribute_by_attribute(string attr_name, string attr_value, int exactly, string name_attr, string value_attr, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "value_attr", value_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // remove attribute by name
        protected bool z_remove_attribute_by_name(string name, string name_attr, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "name_attr", name_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // remove attribute by number
        protected bool z_remove_attribute_by_number(int number, string name_attr, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // remove attribute by inner text
        protected bool z_remove_attribute_by_inner_text(string inner_text, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // remove attribute by inner html
        protected bool z_remove_attribute_by_inner_html(string inner_html, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // remove attribute by attribute 
        protected bool z_remove_attribute_by_attribute(string attr_name, string attr_value, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // save screenshot to file by name
        protected bool z_screenshot_by_name(string file_path, string name, string frame, bool as_gray = false)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "file_path", file_path }, { "name", name }, { "frame", frame } , { "as_gray", as_gray.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // save screenshot to file by number
        protected bool z_screenshot_by_number(string file_path, int number, string frame, bool as_gray = false)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "file_path", file_path }, { "number", number.ToString() }, { "frame", frame } , { "as_gray", as_gray.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // save image to file by src
        protected bool z_screenshot_by_src(string file_path, string src, int exactly, string frame, bool as_gray = false)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "file_path", file_path }, { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } , { "as_gray", as_gray.ToString() }};
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // save screenshot to file by attribute
        protected bool z_screenshot_by_attribute(string file_path, string atr_name, string atr_value, int exactly, string frame, bool as_gray = false)
        {
            wait_element_exist_by_attribute(atr_name, atr_value, exactly, frame);

            string[,] aParams = new string[,] { { "file_path", file_path }, { "atr_name", atr_name }, { "atr_value", atr_value }, { "exactly", exactly.ToString() }, { "frame", frame } , { "as_gray", as_gray.ToString() } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // is exist by number (no wait exist mode)
        protected bool z_is_exist_by_number(int number, string frame)
        {
            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is exist by name (no wait exist mode)
        protected bool z_is_exist_by_name(string name, string frame)
        {
            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is exist by id (no wait exist mode)
        protected bool z_is_exist_by_id(string id, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "id", id }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by href (no wait exist mode)
        protected bool z_is_exist_by_href(string href, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by alt (no wait exist mode)
        protected bool z_is_exist_by_alt(string alt, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "alt", alt }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by src (no wait exist mode)
        protected bool z_is_exist_by_src(string src, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by inner text (no wait exist mode)
        protected bool z_is_exist_by_inner_text(string inner_text, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by inner html (no wait exist mode)
        protected bool z_is_exist_by_inner_html(string inner_html, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by outer text (no wait exist mode)
        protected bool z_is_exist_by_outer_text(string outer_text, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "outer_text", outer_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by outer html (no wait exist mode)
        protected bool z_is_exist_by_outer_html(string outer_html, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "outer_html", outer_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by attribute (no wait exist mode)
        protected bool z_is_exist_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by xpath (no wait exist mode)
        protected bool z_is_exist_by_xpath(string xpath)
        {
            string[,] aParams = new string[,] { { "xpath", xpath } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // is element exist by attribute in form by number (no wait exist mode)
        protected bool z_is_exist_by_attribute_by_form_number(string attr_name, string attr_value, int exactly, int form_number, string frame)
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is element exist by attribute in form by name (no wait exist mode)
        protected bool z_is_exist_by_attribute_by_form_name(string attr_name, string attr_value, int exactly, string form_name, string frame)
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // get name by number
        protected string z_get_name_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get number by name
        protected int z_get_number_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by inner text
        protected int z_get_number_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by inner html
        protected int z_get_number_by_inner_html(string inner_html, int exactly, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by id
        protected int z_get_number_by_id(string id, string frame)
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by src
        protected int z_get_number_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by href
        protected int z_get_number_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get number by attribute
        protected int z_get_number_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get inner text by name
        protected string z_get_inner_text_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner text by number
        protected string z_get_inner_text_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner text by id
        protected string z_get_inner_text_by_id(string id, string frame)
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner text by name
        protected string z_get_inner_text_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner text by any attribute
        protected string z_get_inner_text_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get inner html by name
        protected string z_get_inner_html_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner html by number
        protected string z_get_inner_html_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner html of element by id
        protected string z_get_inner_html_by_id(string id, string frame)
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner html by any attribute
        protected string z_get_inner_html_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get value by name
        protected string z_get_value_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get value by number
        protected string z_get_value_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get value by attribute
        protected string z_get_value_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get src by name
        protected string z_get_src_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get src by number
        protected string z_get_src_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get alt by name
        protected string z_get_alt_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get alt by number
        protected string z_get_alt_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get href by name
        protected string z_get_href_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get href by number
        protected string z_get_href_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get href by inner text
        protected string z_get_href_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get attribute by name
        protected string z_get_attribute_by_name(string name, string name_attr, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get attribute by number
        protected string z_get_attribute_by_number(int number, string name_attr, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get attribute by src
        protected string z_get_attribute_by_src(string src, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get attribute by inner text
        protected string z_get_attribute_by_inner_text(string inner_text, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get attribute by inner html
        protected string z_get_attribute_by_inner_html(string inner_html, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get attribute by attribute
        protected string z_get_attribute_by_attribute(string attr_name, string attr_value, int exactly, string name_attr, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "name_attr", name_attr }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get all atributes names by name
        protected string z_get_all_attributes_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all atributes names by number
        protected string z_get_all_attributes_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all atributes names by src
        protected string z_get_all_attributes_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get all attributes values by name
        protected string z_get_all_attributes_values_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all attributes values by number
        protected string z_get_all_attributes_values_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all attributes values by src
        protected string z_get_all_attributes_values_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get all events by name
        protected string z_get_all_events_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all events by number
        protected string z_get_all_events_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get all events by src
        protected string z_get_all_events_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // is disabled by name
        protected bool z_is_disabled_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // is disabled by number
        protected bool z_is_disabled_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get numbers of child with setted type by name
        protected string z_get_numbers_child_by_name(string name, string element_type, string frame, bool include_subchildren = false)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "element_type", element_type }, { "frame", frame } , { "include_subchildren", include_subchildren.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get numbers of child with setted type by number
        protected string z_get_numbers_child_by_number(int number, string element_type, string frame, bool include_subchildren = false)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "element_type", element_type }, { "frame", frame } , { "include_subchildren", include_subchildren.ToString() }};
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get numbers of child with setted type by id
        protected string z_get_numbers_child_by_id(string id, string element_type, string frame, bool include_subchildren = false)
        {
            wait_element_exist_by_attribute("id", id, 1, frame);

            string[,] aParams = new string[,] { { "id", id }, { "element_type", element_type }, { "frame", frame } , { "include_subchildren", include_subchildren.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get numbers of child with setted type by attribute
        protected string z_get_numbers_child_by_attribute(string attr_name, string attr_value, int exactly, string element_type, string frame, bool include_subchildren = false)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "element_type", element_type }, { "frame", frame } , { "include_subchildren", include_subchildren.ToString() } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // send keyboard input by name
        protected bool z_send_keyboard_input_by_name(string name, string string_, int timeout, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "string", string_ }, { "timeout", timeout.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams,99999);

            //if (res && CSHARP_Use_Trought_Shell)
              //  Console.ReadLine();

            return res;
        }
        // send keyboard input by number
        protected bool z_send_keyboard_input_by_number(int number, string string_, int timeout, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "string", string_ }, { "timeout", timeout.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams,99999);

            //if (res && CSHARP_Use_Trought_Shell)
              //  Console.ReadLine();

            return res;
        }
        // send keyboard input by inner text
        protected bool z_send_keyboard_input_by_inner_text(string inner_text, int exactly, string string_, int timeout, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "string", string_ }, { "timeout", timeout.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams,99999);

            //if (res && CSHARP_Use_Trought_Shell)
              //  Console.ReadLine();

            return res;
        }
        // send keyboard input by inner html
        protected bool z_send_keyboard_input_by_inner_html(string inner_html, int exactly, string string_, int timeout, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "string", string_ }, { "timeout", timeout.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams,99999);

            //if (res && CSHARP_Use_Trought_Shell)
              //  Console.ReadLine();

            return res;
        }
        // send keyboard input by attribute
        protected bool z_send_keyboard_input_by_attribute(string attr_name, string attr_value, int exactly, string string_, int timeout, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "string", string_ }, { "timeout", timeout.ToString() }, { "frame", frame } };
            bool res = call_boolean(MethodBase.GetCurrentMethod().Name, aParams,99999);

            //if (res && CSHARP_Use_Trought_Shell)
              //  Console.ReadLine();

            return res;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // get x by name
        protected int z_get_x_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get x by number 
        protected int z_get_x_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get x by inner text
        protected int z_get_x_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get x by inner html
        protected int z_get_x_by_inner_html(string inner_html, int exactly, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get x by href
        protected int z_get_x_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get x by any attribute
        protected int z_get_x_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by name
        protected int z_get_y_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by number 
        protected int z_get_y_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by inner text
        protected int z_get_y_by_inner_text(string inner_text, int exactly, string frame)
        {
            wait_element_exist_by_inner_text(inner_text, exactly, frame);

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by inner html
        protected int z_get_y_by_inner_html(string inner_html, int exactly, string frame)
        {
            wait_element_exist_by_inner_html(inner_html, exactly, frame);

            string[,] aParams = new string[,] { { "inner_html", inner_html }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by href
        protected int z_get_y_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get y by any attribute
        protected int z_get_y_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // get count of elements on page (no wait exist mode)
        protected int z_get_count(string frame)
        {
            string[,] aParams = new string[,] { { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner texts of all elements on page (no wait exist mode)
        protected string z_get_all_inner_texts(string separator, string text_filter, string frame)
        {
            string[,] aParams = new string[,] { { "separator", separator }, { "text_filter", text_filter }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }


        // get inner texts of all elements on page by href (no wait exist mode)
        protected string z_get_all_inner_texts_by_href(string href, string separator, int exactly, string frame)
        {
            string[,] aParams = new string[,] { { "href", href }, { "separator", separator }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get inner texts of all elements on page in frame (no wait exist mode)
        protected string z_get_all_inner_texts_in_frame(string frame, string separator)
        {
            string[,] aParams = new string[,] { { "frame", frame }, { "separator", separator } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get all numbers by inner text (no wait exist mode)
        protected string[] z_get_all_numbers_by_inner_text(string text, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all numbers by inner html (no wait exist mode)
        protected string[] z_get_all_numbers_by_inner_html(string html, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "html", html }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all inner htmls by inner text (no wait exist mode)
        protected string[] z_get_all_inner_htmls_by_inner_text(string text, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "text", text }, { "exactly", exactly.ToString() }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all attribute values by inner text (no wait exist mode)
        protected string[] z_get_all_attributes_by_inner_text(string attr_name_need, string text, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "attr_name_need", attr_name_need }, { "text", text }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }

        // get all numbers by attribute (no wait exist mode)
        protected string[] z_get_all_numbers_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all inner text by attribute (no wait exist mode)
        protected string[] z_get_all_inner_texts_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all inner htmls by attribute (no wait exist mode)
        protected string[] z_get_all_inner_htmls_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }
        // get all attribute values by attribute (no wait exist mode)
        protected string[] z_get_all_attributes_by_attribute(string attr_name_need, string attr_name, string attr_value, int exactly, string frame)
        {
            char[] separator = new char[] { '\v' };

            string[,] aParams = new string[,] { { "attr_name_need", attr_name_need }, { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "separator", separator[0].ToString() }, { "frame", frame } };
            string res = call_get(MethodBase.GetCurrentMethod().Name, aParams);
            if (res == "")
                return null;

            return res.Split(separator);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // get width by number
        protected int z_get_width_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get width by name
        protected int z_get_width_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get width by href
        protected int z_get_width_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get width by src
        protected int z_get_width_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get width by attribute
        protected int z_get_width_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // get height by number
        protected int z_get_height_by_number(int number, string frame)
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get height by name
        protected int z_get_height_by_name(string name, string frame)
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get height by href
        protected int z_get_height_by_href(string href, int exactly, string frame)
        {
            wait_element_exist_by_attribute("href", href, exactly, frame);

            string[,] aParams = new string[,] { { "href", href }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get height by src
        protected int z_get_height_by_src(string src, int exactly, string frame)
        {
            wait_element_exist_by_attribute("src", src, exactly, frame);

            string[,] aParams = new string[,] { { "src", src }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // get height by attribute
        protected int z_get_height_by_attribute(string attr_name, string attr_value, int exactly, string frame)
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}