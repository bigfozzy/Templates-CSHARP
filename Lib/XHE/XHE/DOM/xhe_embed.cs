using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
    //////////////////////////////////////////////////// Embed //////////////////////////////////////////////////
    public class XHEEmbed : XHEBaseDOMVisual
    {
        ///////////////////////////////////// SERVICVE FUNCTIONS ////////////////////////////////////////////
        // server initialization
        public XHEEmbed(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "Embed";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // кликнуть внутри элемента с заданным номером
        public bool click_in_by_number(int number, int x = -1, int y = -1, string frame = "-1")
        {
            return z_click_in_by_number(number, x, y, frame);
        }
        // кликнуть внутри элемента с заданным имени
        public bool click_in_by_name(string name, int x = -1, int y = -1, string frame = "-1")
        {
            return z_click_in_by_name(name, x, y, frame);
        }
        // кликнуть внутри элемента с заданным src
        public bool click_in_by_src(string src, int exactly = 1, int x = -1, int y = -1, string frame = "-1")
        {
            return z_click_in_by_src(src, exactly, x, y, frame);
        }
        // кликнуть внутри элемента с заданным значением аттрибута
        public bool click_in_by_attribute(string attr_name, string attr_value, int exactly = 1, int x = -1, int y = -1, string frame = "-1")
        {
            return z_click_in_by_attribute(attr_name, attr_value, exactly, x, y, frame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}